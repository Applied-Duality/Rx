// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// he Bubble chart type is a variation of the Point Chart (Chart Controls) chart type, where the data points are replaced by bubbles of different sizes. 
    /// The second Y value controls the size of the bubble. 
    /// This chart type can display different shapes, such as square and diamond. 
    /// You can specify the shape using the Series.MarkerStyle property.
    /// http://msdn.microsoft.com/en-us/library/dd456684
    /// </summary>
    public partial class Bubble : PointOr_<Bubble.DataPoint>
    {
        public Bubble()
        {
            ChartType = SeriesChartType.Bubble;
        }
    }

}
