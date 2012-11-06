// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Linq
{
    static partial class Grouping
    {
        class _Grouping<K, V> : IGrouping<K, V>
        {
            readonly IEnumerable<V> _values;
            public K Key { get; private set; }

            public _Grouping(K key, IEnumerable<V> values)
            {
                Key = key;
                _values = values;
            }

            public IEnumerator<V> GetEnumerator()
            {
                return _values.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
