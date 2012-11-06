// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// The Renko chart type displays a series of connecting vertical lines where the thickness and direction of the lines are dependent on the action of the price value. 
    /// This chart ignores the passage of time, and is used to mark out changes in data trends, such as the trend of the stock market. 
    /// This is similar to the Kagi, Point and Figure, and Three Line Break chart types.
    /// http://msdn.microsoft.com/en-us/library/dd489246
    /// </summary>
    public partial class Renko : Series<Renko.DataPoint>
    {
        public Renko()
        {
            ChartType = SeriesChartType.Renko;
        }
    }

}
