// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// The Range chart type displays a range of data by plotting two Y values per data point, with each Y value being drawn as a line chart. The range between the Y values can then be filled with color, or an image.
    /// This chart is similar to the Spline Range chart type, except that the line tension cannot be adjusted in this chart.
    /// Each data point must consist of two Y values. Otherwise, an exception is thrown.
    /// http://msdn.microsoft.com/en-us/library/dd456630
    /// </summary>
    public partial class Range : Series<Range.DataPoint>
    {
        public Range()
        {
            ChartType = SeriesChartType.Range;
        }
    }

}
