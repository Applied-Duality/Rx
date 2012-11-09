// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    partial class Chart
    {
        partial class Data
        {
            public void Add(IEnumerable<Series> series) { foreach (var serie in series) Add(serie); }
            public void Add(IEnumerable<ChartArea> areas) { foreach(var area in areas) Add(area); }
        }
    }
}
