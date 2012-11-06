// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// The Pie chart type shows how proportions of data, shown as pie-shaped pieces, contribute to the data as a whole.
    /// To change the size of the Pie chart, change the ChartArea object's Position property, InnerPlotPosition property, or both.
    /// http://msdn.microsoft.com/en-us/library/dd456674
    /// </summary>
    public partial class Pie : PieOr_<Pie.DataPoint>
    {
        public Pie()
        {
            ChartType = SeriesChartType.Pie;
        }
    }

}
