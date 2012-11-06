// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// The Range Bar chart type displays separate events that have beginning and end values. 
    /// Data can be plotted using either a date and time or numerical scale. Use this chart type when planning the use of resources.
    /// Multiple data sets are represented as series, and each series can represent one or more tasks.
    /// Data labels cannot be drawn outside the bars. This means that setting the BarLabelStyle custom attribute to Outside has no effect.
    /// http://msdn.microsoft.com/en-us/library/dd456745
    /// </summary>
    public partial class RangeBar : Series<RangeBar.DataPoint>
    {
        public RangeBar()
        {
            ChartType = SeriesChartType.RangeBar;
        }
    }

}
