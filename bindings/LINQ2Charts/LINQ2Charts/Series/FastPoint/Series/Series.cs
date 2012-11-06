// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// The FastPoint chart type is a variation of the Point chart type that significantly reduces the drawing time of a series that contains a very large number of data points.
    /// Some charting features are omitted in this chart type to improve performance. 
    /// The features omitted include control of point level visual attributes, markers, data point labels, and shadows.
    /// http://msdn.microsoft.com/en-us/library/dd489215
    /// </summary>
    public partial class FastPoint : Series<FastPoint.DataPoint>
    {
        public FastPoint()
        {
            ChartType = SeriesChartType.FastPoint;
        }
    }

}
