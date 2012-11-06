// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    partial class Chart
    {
        public partial class Data 
        {
            readonly Chart _chart;
            internal Data(Chart chart) { _chart = chart; }

            public void Add(ChartArea area) { _chart.Add(area); }
            public void Add(Series series) { _chart.Add(series); }
        }
    }
}
