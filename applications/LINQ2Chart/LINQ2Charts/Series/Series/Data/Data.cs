// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Linq.Charting
{
    partial class Series<S>
    {
        public partial class Data 
        {
            private readonly Series<S> _series;

            internal Data(Series<S> series) { _series = series; }

            public void Add(object yValue) {  _series.Add(yValue); }
            public void Add(object xValue, params object[] yValues) {  _series.Add(xValue, yValues); }
            public void Add(S value) { _series.Add(value); }
            public void Add(object key, S value) { _series.Add(key, value); }
        }
    }
}
