// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Linq.Charting
{
    public partial class ErrorBar
    {
        /// <summary>
        /// Specifies the drawing style of data points.
        /// </summary>
        public DrawSideBySide DrawSideBySide
        {
            get { return this.Get<DrawSideBySide>("DrawSideBySide"); }
            set { this.Set("DrawSideBySide", value); }
        }

        /// <summary>
        /// Specifies the appearance of the marker at the center value of the error bar.
        /// </summary>
        public ErrorBarCenterMarkerStyle ErrorBarCenterMarkerStyle
        {
            get { return this.Get<ErrorBarCenterMarkerStyle>("ErrorBarCenterMarkerStyle"); }
            set { this.Set("ErrorBarCenterMarkerStyle", value); }
        }

        /// <summary>
        /// Specifies the name of the series to be used as the data source for the Error Bar chart calculations.
        /// </summary>
        string ErrorBarSeries
        {
            get { return this.Get<string>("ErrorBarSeries"); }
            set { this.Set("ErrorBarSeries", value); }
        }

        /// <summary>
        /// Specifies the visibility of the upper and lower error values.
        /// </summary>
        public ErrorBarStyle ErrorBarStyle
        {
            get { return this.Get<ErrorBarStyle>("ErrorBarStyle"); }
            set { this.Set("ErrorBarStyle", value); }
        }

        /// <summary>
        /// Specifies how the upper and lower error values are calculated for the center values of the ErrorBarSeries.
        /// </summary>
        public ErrorBarType ErrorBarType
        {
            get { return this.Get<ErrorBarType>("ErrorBarType"); }
            set { this.Set("ErrorBarType", value); }
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
    }

}
