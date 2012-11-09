// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// The Doughnut chart type is similar to the Pie chart type, except that it has a hole in the center.
    /// http://msdn.microsoft.com/en-us/library/dd456717
    /// </summary>
    public partial class Doughnut : PieOr_<Doughnut.DataPoint>
    {
        public Doughnut()
        {
            ChartType = SeriesChartType.Doughnut;
        }
    }

}
