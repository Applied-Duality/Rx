using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    partial class ChartArea
    {
        public partial class Data 
        {
            readonly ChartArea _area;
            internal Data(ChartArea area){ _area = area; }

            public void Add(Series series) { _area.Add(series); }
        }
    }
}
