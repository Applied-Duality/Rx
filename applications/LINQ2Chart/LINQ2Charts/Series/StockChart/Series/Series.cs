// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// A Stock chart is typically used to illustrate significant stock price points including a stock's open, close, high, and low price points. 
    /// However, this type of chart can also be used to analyze scientific data, because each series of data displays high, low, open, and close values, which are typically lines or triangles. 
    /// The opening values are shown by the markers on the left, and the closing values are shown by the markers on the right.
    /// The open and close markers can be specified using the ShowOpenClose custom attribute.
    /// http://msdn.microsoft.com/en-us/library/dd456733
    /// </summary>
    public partial class Stock : Series<Stock.DataPoint>
    {
        public Stock()
        {
            ChartType = SeriesChartType.Stock;
        }
    }

}
