// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Linq.Charting
{
    partial class Polar
    {
        /// <summary>
        /// Specifies the plot area shape in Polar and Radar charts.
        /// </summary>
        public AreaDrawingStyle AreaDrawingStyle
        {
            get { return this.Get<AreaDrawingStyle>("AreaDrawingStyle"); }
            set { this.Set("AreaDrawingStyle", value); }
        }

        /// <summary>
        /// Specifies the text orientation of the axis labels in Radar and Polar charts.
        /// </summary>
        public CircularLabelStyle CircularLabelStyle
        {
            get { return this.Get<CircularLabelStyle>("CircularLabelStyle"); }
            set { this.Set("CircularLabelStyle", value); }
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
        /// Specifies the drawing style of the Polar chart type.
        /// </summary>
        public PolarDrawingStyle PolarDrawingStyle
        {
            get { return this.Get<PolarDrawingStyle>("PolarDrawingStyle"); }
            set { this.Set("PolarDrawingStyle", value); }
        }
    }
}
