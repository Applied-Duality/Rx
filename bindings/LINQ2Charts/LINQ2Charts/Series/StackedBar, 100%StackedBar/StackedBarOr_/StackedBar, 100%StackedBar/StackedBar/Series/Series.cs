// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// The Stacked Bar chart type displays series of the same chart type as stacked bars.
    /// Stacked series must be aligned. 
    /// Otherwise, data points will be rendered incorrectly. For more information, see Aligning Data.
    /// http://msdn.microsoft.com/en-us/library/dd456771
    /// </summary>
    public partial class StackedBar : StackedBarOr_<StackedBar.DataPoint>
    {
        public StackedBar()
        {
            ChartType = SeriesChartType.StackedBar;
        }
    }

}
