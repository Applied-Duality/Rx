namespace System.Reactive.Tx
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    
    class BufferQueue<T> : IObserver<T>, IEnumerator<T>
    {
        BlockingCollection<T> _queue = new BlockingCollection<T>();
        T _current;

        public void OnCompleted()
        {
            _queue.CompleteAdding();
        }

        public void OnError(Exception error)
        {
            throw error;
        }

        public void OnNext(T value)
        {
            _queue.Add(value);
        }

        public T Current
        {
            get { return _current; }
        }

        public void Dispose()
        {
            _queue.Dispose();
        }

        object System.Collections.IEnumerator.Current
        {
            get { return _current; }
        }

        public bool MoveNext()
        {
            // Bart, I tried with TryTake, and it sometimes returns immediately on empty queue (so tests fail)
            try
            {
                _current = _queue.Take();
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
