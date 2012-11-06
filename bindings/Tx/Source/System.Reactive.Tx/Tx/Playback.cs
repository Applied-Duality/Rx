using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Reactive.Concurrency;
using System.Reactive.Subjects;
using System.Linq.Expressions;

namespace System.Reactive.Tx
{
    public class Playback : ITimeSource, IPlaybackConfiguration
    {
        readonly List<InputStream> _inputs;
        PullMergeSort<Timestamped<object>> _mergesort;
        OutputPump<Timestamped<object>> _pump;
        ManualResetEvent _pumpStart;
        Subject<Timestamped<object>> _subject = new Subject<Timestamped<object>>();
        TimeSource<Timestamped<object>> _timeSource;
        Demultiplexor _demux;
        IDisposable _toDemux;

        List<IDisposable> _outputBuffers; 

        /// <summary>
        /// Represents sequance of events comming from various sources, and of various static types
        /// Pattern of usage:
        ///     1. Add files or real-time sources
        ///     2. build one or more queries
        ///     3. Call Start (returns immediately) or Run (blocks until the processing is done)
        /// </summary>
        public Playback()
        {
            _inputs = new List<InputStream>();
            _demux = new Demultiplexor();
            _timeSource = new TimeSource<Timestamped<object>>(_subject, e => e.Timestamp);
            _toDemux = _timeSource
                .Select(e => e.Value)
                .Subscribe(_demux);

            _outputBuffers = new List<IDisposable>();
        }

        /// <summary>
        /// Gets or sets the start time for the playback
        /// The setter must be called before any operators that take Scheduler are used
        /// </summary>
        public DateTimeOffset StartTime
        {
            get { return _timeSource.StartTime; }
            set { _timeSource.StartTime = value; }
        }

        public Type[] KnownTypes { get; set; }

        /// <summary>
        /// Low level method for adding input sequence to the playback
        /// Usually, this will be called only from extension methods of Playback
        /// </summary>
        /// <typeparam name="TInput">Universal type that can can contain events of different actual (static) types</typeparam>
        /// <param name="createInput">How to create the input observalbe</param>
        /// <param name="createDeserializers">How to create the deserializers that understand TInput</param>
        void IPlaybackConfiguration.AddInput<TInput>(
            Expression<Func<IObservable<TInput>>> createInput,
            params Type[] typeMaps)
        {
            var input = new InputStream<TInput>(this, createInput, typeMaps);
            _inputs.Add(input);
        }

        /// <summary>
        /// Gets a stream of output (static) type instances
        /// These streams are the input of the queries
        /// </summary>
        /// <typeparam name="TOutput">The type of interest</typeparam>
        /// <returns>Sequence of instances of TOutput that are recognized from any input sequence added to the playback</returns>
        public IObservable<TOutput> GetObservable<TOutput>()
        {
            foreach (var i in _inputs)
            {
                i.AddKnownType(typeof(TOutput));
            }
            return _demux.GetObservable<TOutput>();
        }

        /// <summary>
        /// Starts the playback and returns immediately
        /// </summary>
        public void Start()
        {
            if (KnownTypes != null)
            {
                foreach (Type t in KnownTypes)
                {
                    foreach (InputStream i in _inputs)
                    {
                        i.AddKnownType(t);
                    }
                }
            }

            var queues = (from i in _inputs select i.Output).ToArray();
            _mergesort = new PullMergeSort<Timestamped<object>>(e => e.Timestamp.DateTime, queues);
            _timeSource.Connect();
            _pumpStart = new ManualResetEvent(false);
            _pump = new OutputPump<Timestamped<object>>(_mergesort, _subject, _pumpStart);
            _pumpStart.Set();
            
            foreach (InputStream i in _inputs)
            {
                i.Start();
            }
        }

        /// <summary>
        /// Starts the playback, and blocks until it is completed
        /// This is useful to fill collections as output of the sequence processing 
        /// </summary>
        public void Run()
        {
            Start();

            _pump.Completed.WaitOne();
        }

        public IScheduler Scheduler
        {
            get { return _timeSource.Scheduler; }
        }

        public IEnumerable<TOutput> BufferOutput<TOutput>(IObservable<TOutput> observavle)
        {
            var list = new List<TOutput>();
            IDisposable d = observavle.Subscribe(o => list.Add(o));
            _outputBuffers.Add(d);
            return list;
        }

        interface InputStream
        {
            void AddKnownType(Type t);
            IEnumerator<Timestamped<object>> Output { get; }
            WaitHandle Completed { get; }
            void Start();
        }

        class InputStream<TInput> : InputStream
        {
            Playback _parent;
            IObservable<TInput> _source;
            IObserver<TInput> _deserializer;
            BufferQueue<Timestamped<object>> _output;
            ManualResetEvent _completed;

            public InputStream(
                Playback parent, 
                Expression<Func<IObservable<TInput>>> createInput,
                params Type[] typeMaps)
            {
                _parent = parent;
                _source = createInput.Compile()();
                _output = new BufferQueue<Timestamped<object>>();
                _deserializer = new CompositeDeserializer<TInput>(_output, typeMaps);
            }

            public void AddKnownType(Type t)
            {
                ((IDeserializer)_deserializer).AddKnownType(t);
            }

            public IEnumerator<Timestamped<object>> Output
            {
                get { return _output; }
            }

            public WaitHandle Completed
            {
                get { return _completed; }
            }

            public void Start()
            {
                _source.Subscribe(_deserializer);
            }
        }
    }
}
