// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// The Radar chart type is a circular chart that is used primarily as a data comparison tool. 
    /// It is sometimes called a spider chart or a star chart. The plot area can also be displayed as a polygon.
    /// Unlike most other chart types, the Radar chart type uses the circumference of the chart as the X axis.
    /// 3D is not supported when the AreaDrawingStyle custom attribute is set to Circle (the default value). 
    /// When the AreaDrawingStyle custom attribute is set to Polygon, only the Area3DStyle.Enable3D property has any effect on this chart. 
    /// If you set Area3DStyle.Enable3D to true, the drawing style of the area background changes to give the appearance of looking down on a 3D cone.
    /// http://msdn.microsoft.com/en-us/library/dd489241
    /// </summary>
    public partial class Radar : Series<Radar.DataPoint>
    {
        public Radar()
        {
            ChartType = SeriesChartType.Radar;
        }
    }

}
