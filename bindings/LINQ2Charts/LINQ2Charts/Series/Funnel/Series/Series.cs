// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// The Funnel chart type displays in a funnel shape data that equals 100% when totaled. 
    /// It is a single series chart representing the data as portions of 100%, and it does not use any axes.
    /// This chart treats negative X and Y values as positive values.
    /// http://msdn.microsoft.com/en-us/library/dd456679
    /// </summary>
    public partial class Funnel : Series<Funnel.DataPoint>
    {
        public Funnel()
        {
            ChartType = SeriesChartType.Funnel;
        }
    }

}
