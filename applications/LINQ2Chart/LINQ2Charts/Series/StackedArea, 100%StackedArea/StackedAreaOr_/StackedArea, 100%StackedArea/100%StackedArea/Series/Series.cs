// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// The 100% Stacked Area chart type displays multiple series of data as stacked areas. 
    /// The cumulative proportion of each stacked element is always 100% of the Y axis.
    /// Stacked series must be aligned. Otherwise, data points will be rendered incorrectly. For more information, see Aligning Data.
    /// http://msdn.microsoft.com/en-us/library/dd456756
    /// </summary>
    public partial class StackedArea100 : StackedAreaOr_<StackedArea100.DataPoint>
    {
        public StackedArea100()
        {
            ChartType = SeriesChartType.StackedArea100;
        }
    }

}
