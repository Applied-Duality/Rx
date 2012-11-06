using System.Collections.Generic;

namespace System.Reactive.Tx
{
    public interface INormalizationPlugin<TInput, TKey, TOutputBase>
    {
        IEqualityComparer<TKey> Comparer { get; }
        Func<TInput, DateTimeOffset> TimeFunction { get; }
        Action<TInput, TKey> UpdateAction { get; }

        TKey GetKey<TOutput>() where TOutput : TOutputBase, new();
        Func<TInput, object> GetTransform<TOutput>() where TOutput : TOutputBase, new();
    }
}
