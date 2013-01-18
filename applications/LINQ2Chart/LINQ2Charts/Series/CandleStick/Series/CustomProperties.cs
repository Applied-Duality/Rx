// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Drawing;

namespace System.Linq.Charting
{
    partial class Candlestick
    {
        /// <summary>
        ///Specifies the Y value to use as the data point label.
        /// </summary>
        public LabelValueType LabelValueType
        {
            get { return this.Get<LabelValueType>("LabelValueType"); }
            set { this.Set("LabelValueType", value); }
        }

        /// <summary>
        /// Specifies the maximum width of the data point in pixels.
        /// </summary>
        public int MaxPixelPointWidth
        {
            get { return this.Get<int>("MaxPixelPointWidth"); }
            set { this.Set("MaxPixelPointWidth", value > 0 ? value : 0); }
        }

        /// <summary>
        /// Specifies the minimum data point width in pixels.
        /// This property causes data points to be more visible. 
        /// This is especially useful when plotting a large data set, which causes individual data points to be indistinguishable.
        /// </summary>
        public int MinPixelPointWidth
        {
            get { return this.Get<int>("MinPixelPointWidth"); }
            set { this.Set("MinPixelPointWidth", value > 0 ? value : 0); }
        }

        /// <summary>
        /// Specifies the marker style for open and close values.
        /// </summary>
        public OpenCloseStyle OpenCloseStyle
        {
            get { return this.Get<OpenCloseStyle>("OpenCloseStyle"); }
            set { this.Set("OpenCloseStyle", value); }
        }


        /// <summary>
        /// Specifies the 3D series depth in pixels. For more information, see 3D Charts.
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
        /// Specifies the data point width in pixels.
        /// </summary>
        public int PixelPointWidth
        {
            get { return this.Get<int>("PixelPointWidth"); }
            set { this.Set("PixelPointWidth", value > 0 ? value : 0); }
        }

        /// <summary>
        /// Data point width.
        /// </summary>
        public double PointWidth
        {
            get { return this.Get<double>("PointWidth"); }
            set { this.Set("PointWidth", value.Between(0, 2) ? value : 0.8); }
        }

        /// <summary>
        /// Specifies the data point color to use to indicate a decreasing trend.
        /// A price is considered decreasing when the close value is less than the open value.
        /// </summary>
        public Color PriceDownColor
        {
            get { return this.Get<Color>("PriceDownColor"); }
            set { this.Set("PriceDownColor", value.ToArgb()); }
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
    }

}
