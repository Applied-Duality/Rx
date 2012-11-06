using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    partial class ChartArea
    {
        partial class Data : IEnumerable<Series>
        {
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public IEnumerator<Series> GetEnumerator()
            {
                return _area.GetEnumerator();
            }
        }
    }
}
