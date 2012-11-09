// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// The Column chart type uses a sequence of columns to compare values across categories.
    /// http://msdn.microsoft.com/en-us/library/dd489240
    /// </summary>
    public partial class Column : Series<Column.DataPoint>
    {
        public Column()
        {
            ChartType = SeriesChartType.Column;
        }
    }

}
