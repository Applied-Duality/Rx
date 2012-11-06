using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// The Spline chart type is a Line chart that plots a fitted curve through each data point in a series.
    /// http://msdn.microsoft.com/en-us/library/dd456646
    /// </summary>
    public partial class Spline : SplineOr_<Spline.DataPoint>
    {
        public Spline()
        {
            ChartType = SeriesChartType.Spline;
        }
    }

}
