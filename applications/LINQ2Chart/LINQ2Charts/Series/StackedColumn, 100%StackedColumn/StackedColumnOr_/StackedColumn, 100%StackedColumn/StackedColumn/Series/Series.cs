// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// The Stacked Column chart type is used to compare the contribution of each value to a total across categories.
    /// Stacked series must be aligned. Otherwise, data points will be rendered incorrectly.
    /// http://msdn.microsoft.com/en-us/library/dd489221
    /// </summary>
    public partial class StackedColumn : StackedColumnOr_<StackedColumn.DataPoint>
    {
        public StackedColumn()
        {
            ChartType = SeriesChartType.StackedColumn;
        }
    }

}
