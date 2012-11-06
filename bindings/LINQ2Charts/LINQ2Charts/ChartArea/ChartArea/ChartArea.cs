// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// Represents a chart area on the chart image.
    /// http://msdn.microsoft.com/en-us/library/system.windows.forms.datavisualization.charting.chartarea
    /// </summary>
    public partial class ChartArea : System.Windows.Forms.DataVisualization.Charting.ChartArea
    {

        readonly List<Series> _series = new List<Series>();

        public ChartArea(): base(Guid.NewGuid().ToString())
        {
            Series = new Data(this);
            Legend = new Legend(Guid.NewGuid().ToString());
        }

        public Data Series { get; private set; }
        public Legend Legend { get; private set; }

        /// <summary>
        /// Add series to area.
        /// </summary>
        public void Add(Series series)
        {
            if (!string.IsNullOrWhiteSpace(series.LegendText))
            {
                series.Legend = this.Legend.Name;
            }
            else
            {
                series.IsVisibleInLegend = false;
            }
            series.ChartArea = this.Name;
            _series.Add(series); 
        }

        
    }
}
