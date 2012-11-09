namespace System.Reactive.Tx
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public partial class PullMergeSort<T> : IEnumerable<T>
    {
        Func<T, DateTime> _keyFunction;
        List<IEnumerator<T>> _inputs;

        public PullMergeSort(Func<T, DateTime> keyFunction, IEnumerable<IEnumerator<T>> inputs)
        {
            _keyFunction = keyFunction;
            _inputs = new List<IEnumerator<T>>(inputs);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this, _inputs);
        }

        Collections.IEnumerator Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        class Enumerator : IEnumerator<T>
        {
            PullMergeSort<T> _parent;
            List<IEnumerator<T>> _inputs;
            T _current;
            bool _firstMove;

            public Enumerator(PullMergeSort<T> parent, IEnumerable<IEnumerator<T>> inputs)
            {
                _parent = parent;
                _inputs = new List<IEnumerator<T>>(inputs);
                _firstMove = true;
            }

            public bool MoveNext()
            {
                if (_firstMove)
                {
                    _firstMove = false; 
                    return FirstMove();
                }
                else
                {
                    return SubsequentMove();
                }
            }

            public T Current
            {
                get { return _current; }
            }

            public void Dispose()
            {
                foreach (var input in _inputs)
                {
                    input.Dispose();
                }
            }

            object System.Collections.IEnumerator.Current
            {
                get { throw new NotImplementedException(); }
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

            bool FirstMove()
            {
                Queue<IEnumerator<T>> inputsToRemove = new Queue<IEnumerator<T>>();

                foreach (IEnumerator<T> input in _inputs)
                {
                    if (!input.MoveNext())
                    {
                        inputsToRemove.Enqueue(input);
                    }
                }

                foreach (IEnumerator<T> input in inputsToRemove)
                {
                    _inputs.Remove(input);
                }

                if (_inputs.Count == 0)
                    return false;

                IEnumerator<T> streamToRead = FindStreamToRead();
                _current = streamToRead.Current;

                return true;
            }

            bool SubsequentMove()
            {
                IEnumerator<T> streamToRead = FindStreamToRead(); 
            
                if (streamToRead.MoveNext())
                {
                    _current = streamToRead.Current;
                    return true;
                }
                else
                {
                    _inputs.Remove(streamToRead);
                    return _inputs.Count > 0;
                }
            }

            IEnumerator<T> FindStreamToRead()
            {
                IEnumerator<T> streamToRead = null;
                DateTime earliestTimestamp = DateTime.MaxValue;

                foreach (IEnumerator<T> s in _inputs)
                {
                    DateTime timestamp = _parent._keyFunction(s.Current);
                    if (timestamp < earliestTimestamp)
                    {
                        earliestTimestamp = timestamp;
                        streamToRead = s;
                    }
                }

                return streamToRead;
            }
        }
    }
}
