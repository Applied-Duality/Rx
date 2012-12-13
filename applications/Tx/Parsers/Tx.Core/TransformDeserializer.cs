using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Reactive
{
    public sealed class TransformDeserializer<TInput, TOutputBase> : IDeserializer, IObserver<TInput> where TOutputBase : new()
    {
        IObserver<Timestamped<object>> _observer;
        Func<TInput, DateTimeOffset> _timeFunction;
        Func<TInput, object> _transform;


        public TransformDeserializer(ITypeMap<TInput> typeMap, IObserver<Timestamped<object>> observer)
        {
            _observer = observer;
            _transform = typeMap.GetTransform(typeof(TOutputBase));
            _timeFunction = typeMap.TimeFunction;
        }

        public void AddKnownType(Type type)
        {
            // irrelevant, as this deserializer expects all events to have the same schema
        }

        public void OnCompleted()
        {
            _observer.OnCompleted();
        }

        public void OnError(Exception error)
        {
            _observer.OnError(error);
        }

        public void OnNext(TInput value)
        {
             object o = _transform(value);
            Timestamped<object> ts = new Timestamped<object>(o, _timeFunction(value));
            _observer.OnNext(ts);
        }
    }
}
