// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// The Pyramid chart type displays data that, when combined, equals 100%. 
    /// These charts are single series charts representing data as portions of a 100% total, and do not use an axis.
    /// When in 3D, you can specify a pyramid or conical form for the chart using the Pyramid3DDrawingStyle custom property.
    /// http://msdn.microsoft.com/en-us/library/dd456749
    /// </summary>
    public partial class Pyramid : Series<Pyramid.DataPoint>
    {
        public Pyramid()
        {
            ChartType = SeriesChartType.Funnel;
        }
    }

}
