// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Linq.Charting
{
    partial class SplineRange
    {
        /// <summary>
        /// Specifies the line tension for the drawing of curves between data points.
        /// </summary>
        public double LineTension
        {
            get { return this.Get<double>("LineTension"); }
            set { this.Set("LineTension", value.Between(0, 2) ? value : 0.8); }
        }
    }

}
