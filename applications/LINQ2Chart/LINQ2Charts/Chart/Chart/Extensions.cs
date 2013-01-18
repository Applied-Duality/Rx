// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    partial class Chart 
    {
        public void Add(Series series) { Add(new ChartArea{series}); }

        public void Add(IEnumerable<Series> series) { foreach(var serie in series) Add(serie); }
        public void Add(IEnumerable<ChartArea> areas) { foreach(var area in areas) Add(area); } 

        /// <summary>
        /// Dump chart as Windows Forms window.
        /// </summary>
        public Chart Dump(string label)
        {
            this.Dock = DockStyle.Fill;
            var form = new Form { Controls = { this }, Text = label };
            new Thread(() => Application.Run(form)).Start();
            return this;
        }
    }
}