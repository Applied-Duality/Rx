// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace System.Linq.Charting
{
    partial class Series<S>
    {
        partial class Data
        {
            public void Add(KeyValuePair<double, S> pair) { _series.Add(pair); }
            public void Add(KeyValuePair<Decimal, S> pair) { _series.Add(pair); }
            public void Add(KeyValuePair<Single, S> pair) { _series.Add(pair); }
            public void Add(KeyValuePair<int, S> pair) { _series.Add(pair); }
            public void Add(KeyValuePair<long, S> pair) { _series.Add(pair); }
            public void Add(KeyValuePair<uint, S> pair) { _series.Add(pair); }
            public void Add(KeyValuePair<ulong, S> pair) { _series.Add(pair); }
            public void Add(KeyValuePair<string, S> pair) { _series.Add(pair); }
            public void Add(KeyValuePair<DateTime, S> pair) { _series.Add(pair); }
            public void Add(KeyValuePair<short, S> pair) { _series.Add(pair); }
            public void Add(KeyValuePair<ushort, S> pair) { _series.Add(pair); }

            public void Add(IEnumerable<KeyValuePair<double, S>> pairs) { _series.Add(pairs); }
            public void Add(IEnumerable<KeyValuePair<Decimal, S>> pairs) { _series.Add(pairs); }
            public void Add(IEnumerable<KeyValuePair<Single, S>> pairs) { _series.Add(pairs); }
            public void Add(IEnumerable<KeyValuePair<int, S>> pairs) { _series.Add(pairs); }
            public void Add(IEnumerable<KeyValuePair<long, S>> pairs) { _series.Add(pairs); }
            public void Add(IEnumerable<KeyValuePair<uint, S>> pairs) { _series.Add(pairs); }
            public void Add(IEnumerable<KeyValuePair<ulong, S>> pairs) { _series.Add(pairs); }
            public void Add(IEnumerable<KeyValuePair<string, S>> pairs) { _series.Add(pairs); }
            public void Add(IEnumerable<KeyValuePair<DateTime, S>> pairs) { _series.Add(pairs); }
            public void Add(IEnumerable<KeyValuePair<short, S>> pairs) { _series.Add(pairs); }
            public void Add(IEnumerable<KeyValuePair<ushort, S>> pairs) { _series.Add(pairs); }

            public void Add(IEnumerable<object> values) { _series.Add(values); }
            public void Add(IEnumerable<double> values) { _series.Add(values); }
            public void Add(IEnumerable<Decimal> values) { _series.Add(values); }
            public void Add(IEnumerable<Single> values) { _series.Add(values); }
            public void Add(IEnumerable<int> values) { _series.Add(values); }
            public void Add(IEnumerable<long> values) { _series.Add(values); }
            public void Add(IEnumerable<uint> values) { _series.Add(values); }
            public void Add(IEnumerable<ulong> values) { _series.Add(values); }
            public void Add(IEnumerable<string> values) { _series.Add(values); }
            public void Add(IEnumerable<DateTime> values) { _series.Add(values); }
            public void Add(IEnumerable<short> values) { _series.Add(values); }
            public void Add(IEnumerable<ushort> values) { _series.Add(values); }

            public void Add(IEnumerable<S> values) { _series.Add(values); }
        }
    }
}
