// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// The Area chart type emphasizes the degree of change over time. 
    /// It also shows the relationship of the parts to a whole.
    /// http://msdn.microsoft.com/en-us/library/dd456698
    /// </summary>
    public partial class Area : LineOr_<Area.DataPoint>
    {
        public Area()
        {
            ChartType = SeriesChartType.Area;
        }
    }

}
