// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// The Bar chart type illustrates comparisons among individual items. 
    /// Categories are organized horizontally while values are displayed vertically in order to place more emphasis on comparing values and less emphasis on time.
    /// http://msdn.microsoft.com/en-us/library/dd456715
    /// </summary>
    public partial class Bar : Series<Bar.DataPoint>
    {
        public Bar()
        {
            ChartType = SeriesChartType.Bar;
        }
    }

}
