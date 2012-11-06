// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// The FastLine chart type is a variation of the Line chart that significantly reduces the drawing time of a series that contains a very large number of data points. 
    /// Use this chart in situations where very large data sets are used and rendering speed is critical.
    /// Some charting features are omitted from the FastLine chart to improve performance. The features omitted include control of point level visual attributes, markers, data point labels, and shadows.
    /// http://msdn.microsoft.com/en-us/library/dd489249
    /// </summary>
    public partial class FastLine : Series<FastLine.DataPoint>
    {
        public FastLine()
        {
            ChartType = SeriesChartType.FastLine;
        }
    }

}
