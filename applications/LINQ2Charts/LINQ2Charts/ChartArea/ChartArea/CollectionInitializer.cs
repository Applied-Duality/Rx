// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    partial class ChartArea : IEnumerable<Series>
    {
        public IEnumerator<Series> GetEnumerator() { return _series.GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }
}