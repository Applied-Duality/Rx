// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Linq.Charting
{
    public partial class Series<S>
    {
        /// <summary>
        /// Dump Series as Windows Forms window.
        /// </summary>
        public Series<S> Dump(string label)
        {
            new ChartArea { this }.Dump(label);
            return this;
        }
    }
}