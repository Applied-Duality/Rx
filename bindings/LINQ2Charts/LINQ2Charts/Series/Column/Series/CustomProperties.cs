// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Linq.Charting
{
    partial class Column
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
        /// Specifies the drawing style of data points.
        /// </summary>
        public DrawSideBySide DrawSideBySide
        {
            get { return this.Get<DrawSideBySide>("DrawSideBySide"); }
            set { this.Set("DrawSideBySide", value); }
        }

        /// <summary>
        /// Specifies the value to be used for empty points. This property determines how an empty point is treated when the chart is drawn.
        /// If a value of Average is used, the chart is drawn as though a point exists, and has a value of the average of the two adjacent points. 
        /// If Zero is used, the chart is drawn as though a point exists with a zero value.
        /// </summary>
        public EmptyPointValue EmptyPointValue
        {
            get { return this.Get<EmptyPointValue>("EmptyPointValue"); }
            set { this.Set("EmptyPointValue", value); }
        }

        /// <summary>
        /// Specifies the placement of the data point label.
        /// </summary>
        public LabelStyle LabelStyle
        {
            get { return this.Get<LabelStyle>("LabelStyle"); }
            set { this.Set("LabelStyle", value); }
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
