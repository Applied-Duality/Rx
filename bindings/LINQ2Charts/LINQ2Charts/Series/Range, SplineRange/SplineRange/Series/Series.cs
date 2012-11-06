// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// The Spline Range chart type displays a range of data by plotting two Y values per data point, with each Y value drawn as a line chart. 
    /// The range between the Y values can be filled with color, information, or even an image.
    /// This chart type is similar to the Range chart type. 
    /// The difference is that the line tension in this chart can be adjusted using the LineTension custom attribute.
    /// http://msdn.microsoft.com/en-us/library/dd456651
    /// </summary>
    public partial class SplineRange : RangeOr_<SplineRange.DataPoint>
    {
        public SplineRange()
        {
            ChartType = SeriesChartType.SplineRange;
        }
    }

}
