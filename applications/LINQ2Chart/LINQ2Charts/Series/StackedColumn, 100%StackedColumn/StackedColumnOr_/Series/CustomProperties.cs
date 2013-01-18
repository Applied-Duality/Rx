// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Linq.Charting
{
    partial class StackedColumnOr_<S>
    {
        /// <summary>
        /// Specifies the drawing style of data points.
        /// </summary>
        public DrawingStyle DrawingStyle
        {
            get { return this.Get<DrawingStyle>("DrawingStyle"); }
            set { this.Set("DrawingStyle", value); }
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

        /// <summary>
        /// Specifies the name of the stacked group.
        /// To place multiple series in the same stacked group, assign the same name to them.
        /// To show multiple stacks, assign different names to multiple series.
        /// </summary>
        public string StackedGroupName
        {
            get { return this.Get<string>("StackedGroupName"); }
            set { this.Set("StackedGroupName", value); }
        }
    }
}
