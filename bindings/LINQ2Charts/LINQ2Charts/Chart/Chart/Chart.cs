// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// Serves as the root class of the Chart control.
    /// http://msdn.microsoft.com/en-us/library/system.windows.forms.datavisualization.charting.chart
    /// </summary>
    public partial class Chart : System.Windows.Forms.DataVisualization.Charting.Chart
    {
        public Chart()
        {
            ChartAreas = new Data(this);
        }

        public new Data ChartAreas { get; private set; }

        public void Add(ChartArea area)
        {
            foreach (var series in area) base.Series.Add(series);
            this.Legends.Add(area.Legend);
            base.ChartAreas.Add(area);
        }
    }
}