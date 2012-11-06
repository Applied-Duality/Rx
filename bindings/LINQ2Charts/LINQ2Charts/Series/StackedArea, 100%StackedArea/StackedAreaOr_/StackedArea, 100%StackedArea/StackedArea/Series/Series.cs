// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// The Stacked Area chart type is an Area chart that stacks two or more data series on top of one another.
    /// Stacked series must be aligned. 
    /// Otherwise, data points will be rendered incorrectly. For more information, see Aligning Data.
    /// http://msdn.microsoft.com/en-us/library/dd456720
    /// </summary>
    public partial class StackedArea : StackedAreaOr_<StackedArea.DataPoint>
    {
        public StackedArea()
        {
            ChartType = SeriesChartType.StackedArea;
        }
    }

}
