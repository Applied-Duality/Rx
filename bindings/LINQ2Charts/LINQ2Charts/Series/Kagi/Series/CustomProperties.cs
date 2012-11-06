// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Drawing;

namespace System.Linq.Charting
{
    partial class Kagi
    {
        /// <summary>
        /// Specifies the 3D series depth in pixels.
        /// </summary>
        public int PixelPointDepth
        {
            get { return this.Get<int>("PixelPointDepth"); }
            set { this.Set("PixelPointDepth", value > 0 ? value : 0); }
        }

        /// <summary>
        /// Specifies the 3D gap depth in pixels. 
        /// </summary>
        public int PixelPointGapDepth
        {
            get { return this.Get<int>("PixelPointGapDepth"); }
            set { this.Set("PixelPointGapDepth", value > 0 ? value : 0); }
        }

        /// <summary>
        /// Specifies the data point color that indicates an increasing trend.
        /// A price is considered increasing when the close value is greater than the open value.
        /// </summary>
        public Color PriceUpColor
        {
            get { return this.Get<Color>("PriceUpColor"); }
            set { this.Set("PriceUpColor", value.ToArgb()); }
        }

        /// <summary>
        /// Specifies the reversal amount for the chart as a percentage.
        /// Defines when a new Kagi line should be drawn.
        /// </summary>
        public int ReversalAmountPercent
        {
            get { return Int32.Parse(this.Get<string>("ReversalAmount ").TrimEnd('%')); }
            set { this.Set("ReversalAmount ", string.Format("{0}%", value.Between(0, 100) ? value : 3)); }
        }

        /// <summary>
        /// Specifies the reversal amount for the chart as a fixed value.
        /// Defines when a new Kagi line should be drawn.
        /// </summary>
        public double ReversalAmount 
        {
            get { return this.Get<double>("ReversalAmount "); }
            set { this.Set("ReversalAmount ", value > 0 ? value : 0); }
        }

        /// <summary>
        /// Specifies the index of the Y value to use to plot the Kagi, Renko, or Three Line Break chart.
        /// </summary>
        public int UsedYValue
        {
            get { return this.Get<int>("UsedYValue"); }
            set { this.Set("UsedYValue", 0); }
        }
    }
}
