// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Linq.Charting
{
    partial class Range
    {
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
        /// Specifies the label style of the data points.
        /// </summary>
        public LabelStyle LabelStyle
        {

            get { return this.Get<LabelStyle>("LabelStyle"); }
            set { this.Set("LabelStyle", value); }
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
        /// Specifies whether marker lines are displayed when rendered in 3D.
        /// </summary>
        public bool ShowMarkerLines
        {
            get { return this.Get<bool>("ShowMarkerLines"); }
            set { this.Set("ShowMarkerLines", value); }
        }
    }

}
