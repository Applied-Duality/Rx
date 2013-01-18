using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
     partial class ChartArea
    {
        partial class Data
        {
            public void Add(IEnumerable<Series> series) { foreach(var serie in series) Add(serie); }
        }
    }
}
