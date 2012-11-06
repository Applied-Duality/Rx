// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// The Point chart type uses value points to represent its data.
    /// http://msdn.microsoft.com/en-us/library/dd456684
    /// </summary>
    public partial class Point : PointOr_<Point.DataPoint>
    {
        public Point()
        {
            ChartType = SeriesChartType.Point;
        }
    }

}
