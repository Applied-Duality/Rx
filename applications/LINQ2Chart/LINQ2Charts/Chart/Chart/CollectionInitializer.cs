// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Collections;
using System.Collections.Generic;

namespace System.Linq.Charting
{
    partial class Chart : IEnumerable<System.Windows.Forms.DataVisualization.Charting.ChartArea>
    {
        public IEnumerator<Windows.Forms.DataVisualization.Charting.ChartArea> GetEnumerator()
        {
            return base.ChartAreas.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
