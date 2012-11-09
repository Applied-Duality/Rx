// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Linq.Charting
{
    partial class RangeBar 
    {
        partial class DataPoint 
        {
            /// <summary>
            /// Specifies the placement of the data point label.
            /// </summary>
            public BarLabelStyle BarLabelStyle
            {
                get { return this.Get<BarLabelStyle>("BarLabelStyle"); }
                set { this.Set("BarLabelStyle", value); }
            }

            /// <summary>
            /// Specifies the drawing style of data points.
            /// </summary>
            public DrawingStyle DrawingStyle
            {
                get { return this.Get<DrawingStyle>("DrawingStyle"); }
                set { this.Set("DrawingStyle", value); }
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
        }
    }

}
