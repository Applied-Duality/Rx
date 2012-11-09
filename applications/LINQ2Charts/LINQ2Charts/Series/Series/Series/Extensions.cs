// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Collections;
using System.Collections.Generic;

namespace System.Linq.Charting
{
    public partial class Series<S>
    {
        public void Add(object yValue){ Add((S)CreateDataPoint(yValue)); }
        public void Add(object xValue, params object[] yValues) { Add(xValue, (S)CreateDataPoint(yValues));}

        public void Add(KeyValuePair<double, double> pair) { Add((object)pair.Key, (object)pair.Value); }
        public void Add(KeyValuePair<double, S> pair) { Add((object)pair.Key, pair.Value); }
        public void Add(KeyValuePair<Decimal, S> pair) { Add((object)pair.Key, pair.Value); }
        public void Add(KeyValuePair<Single, S> pair) { Add((object)pair.Key, pair.Value); }
        public void Add(KeyValuePair<int, S> pair) { Add((object)pair.Key, pair.Value); }
        public void Add(KeyValuePair<long, S> pair) { Add((object)pair.Key, pair.Value); }
        public void Add(KeyValuePair<uint, S> pair) { Add((object)pair.Key, pair.Value); }
        public void Add(KeyValuePair<ulong, S> pair) { Add((object)pair.Key, pair.Value); }
        public void Add(KeyValuePair<string, S> pair) { Add((object)pair.Key, pair.Value); }
        public void Add(KeyValuePair<DateTime, S> pair) { Add((object)pair.Key, pair.Value); }
        public void Add(KeyValuePair<short, S> pair) { Add((object)pair.Key, pair.Value); }
        public void Add(KeyValuePair<ushort, S> pair) { Add((object)pair.Key, pair.Value); }

        public void Add(IEnumerable<KeyValuePair<double, S>> pairs) { foreach (var pair in pairs) Add(pair); }
        public void Add(IEnumerable<KeyValuePair<Decimal, S>> pairs) { foreach (var pair in pairs) Add(pair); }
        public void Add(IEnumerable<KeyValuePair<Single, S>> pairs) { foreach (var pair in pairs) Add(pair); }
        public void Add(IEnumerable<KeyValuePair<int, S>> pairs) { foreach (var pair in pairs) Add(pair); }
        public void Add(IEnumerable<KeyValuePair<long, S>> pairs) { foreach (var pair in pairs) Add(pair); }
        public void Add(IEnumerable<KeyValuePair<uint, S>> pairs) { foreach (var pair in pairs) Add(pair); }
        public void Add(IEnumerable<KeyValuePair<ulong, S>> pairs){  foreach (var pair in pairs) Add(pair); }
        public void Add(IEnumerable<KeyValuePair<string, S>> pairs) { foreach (var pair in pairs) Add(pair); }
        public void Add(IEnumerable<KeyValuePair<DateTime, S>> pairs) { foreach (var pair in pairs) Add(pair); }
        public void Add(IEnumerable<KeyValuePair<short, S>> pairs) { foreach (var pair in pairs) Add(pair); }
        public void Add(IEnumerable<KeyValuePair<ushort, S>> pairs) { foreach (var pair in pairs) Add(pair); }

        public void Add(IEnumerable<object> values)  { foreach (var value in values) Add(value); }
        public void Add(IEnumerable values) { foreach (var value in values) Add(value); }

        public void Add(IEnumerable<S> values) { foreach (var value in values) Add(value); }

        public void Add(IEnumerable<double> values) { foreach (var value in values) Add(value); }
        public void Add(IEnumerable<Decimal> values) { foreach (var value in values) Add(value); }
        public void Add(IEnumerable<Single> values) { foreach (var value in values) Add(value); }
        public void Add(IEnumerable<int> values) { foreach (var value in values) Add(value); }
        public void Add(IEnumerable<long> values) { foreach (var value in values) Add(value); }
        public void Add(IEnumerable<uint> values) { foreach (var value in values) Add(value); }
        public void Add(IEnumerable<ulong> values) { foreach (var value in values) Add(value); }
        public void Add(IEnumerable<string> values) { foreach (var value in values) Add((object)value); }
        public void Add(IEnumerable<DateTime> values) { foreach (var value in values) Add(value); }
        public void Add(IEnumerable<short> values) { foreach (var value in values) Add(value); }
        public void Add(IEnumerable<ushort> values) { foreach (var value in values) Add(value); }
    }
}