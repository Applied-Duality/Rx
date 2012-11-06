// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Linq.Charting
{
    partial class PointAndFigure
    {
        /// <summary>
        /// Specifies the box size of the Renko or Point and Figure chart as a percentage.
        /// </summary>
        public int BoxSizePercent
        {
            get { return Int32.Parse(this.Get<string>("BoxSize").TrimEnd('%')); }
            set { this.Set("BoxSize", string.Format("{0}%", value.Between(0, 100) ? value : 4)); }
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
        /// Specifies the maximum width of the data point in pixels.
        /// </summary>
        public int MaxPixelPointWidth
        {
            get { return this.Get<int>("MaxPixelPointWidth"); }
            set { this.Set("MaxPixelPointWidth", value > 0 ? value : 0); }
        }

        /// <summary>
        /// Specifies the minimum width of the data point in pixels.
        /// This property causes data points to be more visible. 
        /// This is especially useful when plotting a large data set, 
        /// which causes individual data points to be indistinguishable.
        /// </summary>
        public int MinPixelPointWidth
        {
            get { return this.Get<int>("MinPixelPointWidth"); }
            set { this.Set("MinPixelPointWidth", value > 0 ? value : 0); }
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
    }
}
