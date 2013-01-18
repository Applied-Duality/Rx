// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Linq.Charting
{
    partial class Bubble
    {
        /// <summary>
        /// Specifies the maximum size of the bubble radius as a percentage of the chart area size.
        /// </summary>
        public double BubbleMaxSize
        {
            get { return this.Get<double>("BubbleMaxSize"); }
            set { this.Set("BubbleMaxSize", value.Between(0,100) ? value : 15); }
        }

        /// <summary>
        /// Specifies the minimum size of the bubble radius as a percentage of the chart area size.
        /// </summary>
        public double BubbleMinSize
        {
            get { return this.Get<double>("BubbleMinSize"); }
            set { this.Set("BubbleMinSize", value.Between(0, 100) ? value : 3); }
        }

        /// <summary>
        /// Specifies the Y value that is represented by the minimum bubble size, which is set by BubbleMinSize.
        /// </summary>
        public double BubbleScaleMin
        {
            get { return this.Get<double>("BubbleScaleMin"); }
            set { this.Set("BubbleScaleMin", !double.IsNaN(value) ? value : 3); }
        }

        /// <summary>
        /// Specifies whether to use the bubble size as the data point label.
        /// Specify True to use the bubble size as the data point label. Otherwise, specify False.
        /// </summary>
        public bool BubbleUseSizeForLabel 
        {
            get { return this.Get<bool>("BubbleUseSizeForLabel "); }
            set { this.Set("BubbleUseSizeForLabel ", value); }
        }
    }
}
