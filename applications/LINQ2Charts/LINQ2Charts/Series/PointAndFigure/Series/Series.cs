// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// The Point and Figure chart type differs from traditional price charts in that it disregards the passage of time and only displays changes in prices. 
    /// This is similar to the Kagi, Renko, and Three Line Break chart types.
    /// This chart type displays the underlying supply and demand as reflected in the price values. 
    /// A column of Xs shows that demand is exceeding supply, which is known as a rally, a column of Os shows that supply is exceeding demand, 
    /// which is known as a decline, and a series of short columns shows that supply and demand are relatively equal, which represents a market equilibrium.
    /// http://msdn.microsoft.com/en-us/library/dd456746.aspx
    /// </summary>
    public partial class PointAndFigure : Series<PointAndFigure.DataPoint>
    {
        public PointAndFigure()
        {
            ChartType = SeriesChartType.PointAndFigure;
        }
    }

}
