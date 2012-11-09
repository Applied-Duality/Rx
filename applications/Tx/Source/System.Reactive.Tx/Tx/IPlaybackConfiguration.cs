using System.Linq.Expressions;

namespace System.Reactive.Tx
{
    public interface IPlaybackConfiguration
    {
        void AddInput<TInput>(
            Expression<Func<IObservable<TInput>>> createInput, 
            params Type[] typeMaps);
    }
}
