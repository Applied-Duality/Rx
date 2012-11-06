// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace System.Linq
{
    public static partial class Grouping
    {
        public static IGrouping<K, V> Create<K, V>(K key, IEnumerable<V> values)
        {
            return new _Grouping<K, V>(key, values);
        }

        public static IGrouping<K, T> Select<K, S, T>(this IGrouping<K, S> source, Func<S, T> selector)
        {
            return new _Grouping<K, T>(source.Key, (source as IEnumerable<S>).Select(selector));
        }

        public static IEnumerable<IGrouping<K, IGrouping<L, S>>>
            ThenBy<S, K, L>(this IEnumerable<IGrouping<K, S>> source, Func<S, L> keySelector)
        {
            return source.Select(g => Grouping.Create(g.Key, g.GroupBy(keySelector)));
        }

        public static IEnumerable<IGrouping<K, IGrouping<L, R>>>
            ThenBy<S, K, L, R>
            (this IEnumerable<IGrouping<K, S>> source
            , Func<S, L> keySelector
            , Func<S, R> elementSelector
            )
        {
            return source.Select(g => Grouping.Create(g.Key, g.GroupBy(keySelector, elementSelector)));
        }
    }
}