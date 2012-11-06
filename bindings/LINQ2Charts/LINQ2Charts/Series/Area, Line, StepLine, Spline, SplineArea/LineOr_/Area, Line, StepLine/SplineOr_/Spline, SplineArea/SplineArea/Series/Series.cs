using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// The Spline Area chart type is an Area chart that plots a fitted curve through each data point in a series.
    /// http://msdn.microsoft.com/en-us/library/dd489217
    /// </summary>
    public partial class SplineArea : SplineOr_<SplineArea.DataPoint>
    {
        public SplineArea()
        {
            ChartType = SeriesChartType.SplineArea;
        }
    }

}
