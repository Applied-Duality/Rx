// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// The Error Bar chart type consists of lines with markers that are used to display statistical information about the data displayed in a graph. 
    /// </summary>
    public partial class ErrorBar : Series<ErrorBar.DataPoint>
    {
        public ErrorBar()
        {
            ChartType = SeriesChartType.ErrorBar;
            this.ErrorBarSeries = base.Name;
        }
    }

}
