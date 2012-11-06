using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    /// <summary>
    /// The Step Line chart type is similar to the Line chart type, but it does not use the shortest distance to connect two data points. 
    /// Instead, this chart type uses vertical and horizontal lines to connect the data points in a series forming a step-like progression.
    /// http://msdn.microsoft.com/en-us/library/dd456618
    /// </summary>
    public partial class StepLine : LineOr_<StepLine.DataPoint>
    {
        public StepLine()
        {
            ChartType = SeriesChartType.StepLine;
        }
    }

}
