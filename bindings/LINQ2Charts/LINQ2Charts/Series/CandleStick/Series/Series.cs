// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// The Candlestick chart type is used to display stock information using high, low, open and close values. 
    /// The size of the line is determined by the high and low values, while the size of the bar is determined by the open and close values. 
    /// The open and close bars are displayed using different colors. 
    /// The color used depends on whether the stock's price has gone up or down.
    /// If the close value is higher than the open value than the color of the bar is determined by the PriceUpColor custom attribute. 
    /// If the close value is lower than the open value than the color of the bar is determined by the PriceDownColor custom attribute. 
    /// Note that these custom attributes must be set explicitly (by default they are not set).
    /// http://msdn.microsoft.com/en-us/library/dd456671
    /// </summary>
    public partial class Candlestick : Series<Candlestick.DataPoint>
    {
        public Candlestick()
        {
            ChartType = SeriesChartType.Candlestick;
        }
    }

}
