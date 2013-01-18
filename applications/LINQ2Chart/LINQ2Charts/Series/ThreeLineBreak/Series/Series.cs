// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// The Three Line Break chart type displays a series of vertical boxes, or lines, that reflect changes in price values. 
    /// Similar to Kagi, Point and Figure, and Renko chart types, this chart type ignores the passage of time and emphasizes the changes in data trends.
    /// This chart type is different from the Kagi, Point and Figure, and Renko chart types because there is no predetermined price change amount. 
    /// It is the price action which gives the indication of a price change. 
    /// The criterion for a new line on the chart requires that the data value breaks the high or the low of the preceding three lines by default. 
    /// You can change this amount using the NumberOfLinesInBreak custom attribute.
    /// http://msdn.microsoft.com/en-us/library/dd456721
    /// </summary>
    public partial class ThreeLineBreak : Series<ThreeLineBreak.DataPoint>
    {
        public ThreeLineBreak()
        {
            ChartType = SeriesChartType.ThreeLineBreak;
        }
    }

}
