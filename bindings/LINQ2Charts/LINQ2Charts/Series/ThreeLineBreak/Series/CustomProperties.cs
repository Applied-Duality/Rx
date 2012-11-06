// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Drawing;

namespace System.Linq.Charting
{
    partial class ThreeLineBreak
    {
        /// <summary>
        /// Specifies the number of lines to use in a Three Line Break chart.
        /// </summary>
        public int NumberOfLinesInBreak
        {
            get { return this.Get<int>("NumberOfLinesInBreak"); }
            set { this.Set("NumberOfLinesInBreak", value > 0 ? value : 3); }
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
        /// Specifies the index of the Y value to use to plot the Kagi, Renko, or Three Line Break chart.
        /// </summary>
        public int UsedYValue
        {
            get { return this.Get<int>("UsedYValue"); }
            set { this.Set("UsedYValue", 0); }
        }
    }
}
