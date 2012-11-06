// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace System.Linq
{
    public static class Extensions
    {
        public static IEnumerable<KeyValuePair<int, T>> WithIndex<T>(this IEnumerable<T> source)
        {
            return source.Select((x, i) => new KeyValuePair<int,T>(i, x));
        }
    }
}