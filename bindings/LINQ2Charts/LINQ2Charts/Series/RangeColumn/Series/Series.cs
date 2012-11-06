// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// The Range Column chart type displays a range of data by plotting two Y values per data point. Each Y value used is drawn as the upper, and lower bounds of a column. This is similar to the Range Bar chart, except the columns are positioned vertically. 
    /// The range between the Y values can be filled with color, information, or even an image.
    /// http://msdn.microsoft.com/en-us/library/dd456683
    /// </summary>
    public partial class RangeColumn : Series<RangeColumn.DataPoint>
    {
        public RangeColumn()
        {
            ChartType = SeriesChartType.RangeColumn;
        }
    }

}
