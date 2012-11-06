// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// The Polar chart type is a circular graph on which data points are displayed using the angle, and the distance from the center point. 
    /// The X axis is located on the boundaries of the circle and the Y axis connects the center of the circle with the X axis.
    /// http://msdn.microsoft.com/en-us/library/dd456623
    /// </summary>
    public partial class Polar : Series<Polar.DataPoint>
    {
        public Polar()
        {
            ChartType = SeriesChartType.Polar;
        }
    }

}
