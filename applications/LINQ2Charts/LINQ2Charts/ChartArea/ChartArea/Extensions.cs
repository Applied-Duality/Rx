// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    partial class ChartArea
    {
        /// <summary>
        /// Add multiple series to area.
        /// </summary>
        public void Add(IEnumerable<Series> items) { foreach (var item in items) Add(item); }

        /// <summary>
        /// Dump ChartArea as Windows Forms window.
        /// </summary>
        public ChartArea Dump(string label)
        {
            new Chart{this}.Dump(label);
            return this;
        }
    }
}