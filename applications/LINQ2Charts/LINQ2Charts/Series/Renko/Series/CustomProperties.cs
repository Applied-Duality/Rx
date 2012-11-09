// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Drawing;

namespace System.Linq.Charting
{
    partial class Renko
    {
        /// <summary>
        /// Specifies the box size of the Renko or Point and Figure chart as a percentage.
        /// </summary>
        public int BoxSizePercent
        {
            get { return Int32.Parse(this.Get<string>("BoxSize").TrimEnd('%')); }
            set { this.Set("BoxSize", string.Format("{0}%", value.Between(0,100) ? value : 4)); }
        }

        /// <summary>
        /// Specifies the box size of the Renko or Point and Figure chart as a fixed value.
        /// </summary>
        public double BoxSize
        {
            get { return this.Get<double>("BoxSize"); }
            set { this.Set("BoxSize", value > 0 ? value : 0); }
        }

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
        /// Specifies whether the Point and Figure chart should draw the X and O values proportionally.
        /// </summary>
        public bool ProportionalSymbols
        {
            get { return this.Get<bool>("ProportionalSymbols"); }
            set { this.Set("ProportionalSymbols", value); }
        }


        /// <summary>
        /// Specifies the reversal amount for the chart as a percentage.
        /// </summary>
        public int ReversalAmountPercent
        {
            get { return Int32.Parse(this.Get<string>("ReversalAmount ").TrimEnd('%')); }
            set { this.Set("ReversalAmount ", string.Format("{0}%", value.Between(0, 100) ? value : 3)); }
        }

        /// <summary>
        /// Specifies the reversal amount for the chart as a fixed value.
        /// </summary>
        public double ReversalAmount 
        {
            get { return this.Get<double>("ReversalAmount "); }
            set { this.Set("ReversalAmount ", value > 0 ? value : 0); }
        }

        /// <summary>
        /// Specifies the index of the Y value to use for the high price in the Point and Figure chart, with the first Y value at index 0.
        /// </summary>
        public int UsedYValueHigh
        {
            get { return this.Get<int>("UsedYValueHigh"); }
            set { this.Set("UsedYValueHigh", 0); }
        }

        /// <summary>
        /// Specifies the index of the Y value to use for the low price in the Point and Figure chart, with the first Y value at index 0.
        /// </summary>
        public int UsedYValueLow
        {
            get { return this.Get<int>("UsedYValueLow"); }
            set { this.Set("UsedYValueLow", 0); }
        }
    }
}
