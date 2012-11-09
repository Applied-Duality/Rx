// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// This chart type displays multiple data series as stacked bars, and the cumulative proportion of each stacked element always totals 100%.
    /// The 100% stacked bar chart is useful for measuring multiple series as a proportion vs. time. 
    /// For example, use this chart type for displaying the proportion of a monthly mortgage payment that is applied to interest and principal over time. 
    /// In this example, the mortgage payment amount represents 100%, while the interest and the principal values are the two stacked elements that make up one bar.
    /// Stacked series must be aligned. Otherwise, data points will be rendered incorrectly. For more information, see Aligning Data.
    /// http://msdn.microsoft.com/en-us/library/dd489229
    /// </summary>
    public partial class StackedBar100 : StackedBarOr_<StackedBar100.DataPoint>
    {
        public StackedBar100()
        {
            ChartType = SeriesChartType.StackedBar100;
        }
    }

}
