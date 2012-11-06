using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// The Line chart type can be used to illustrate trends in data with the passing of time.
    /// http://msdn.microsoft.com/en-us/library/dd489252
    /// </summary>
    public partial class Line : LineOr_<Line.DataPoint>
    {
        public Line()
        {
            ChartType = SeriesChartType.Line;
        }
    }

}
