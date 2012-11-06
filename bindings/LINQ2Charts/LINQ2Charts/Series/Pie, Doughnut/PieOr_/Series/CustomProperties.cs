// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Drawing;

namespace System.Linq.Charting
{
    public partial class PieOr_<S>
    {
        /// <summary>
        /// Specifies the drawing style of the data points.
        /// </summary>
        public PieDrawingStyle DrawingStyle
        {
            get { return this.Get<PieDrawingStyle>("PieDrawingStyle"); }
            set { this.Set("PieDrawingStyle", value); }
        }

        /// <summary>
        /// Specifies the color of the collected pie slice.
        /// This property applies only when a <see cref="CollectedThreshold"/> value is set.
        /// </summary>
        public Color CollectedColor
        {
            get { return this.Get("CollectedColor", Color.Empty); }
            set { this.Set("CollectedColor", value.ToArgb()); }
        }

        /// <summary>
        /// Specifies the label text for the collected pie slice.
        /// This property applies only when a <see cref="CollectedThreshold"/> value is set.
        /// </summary>
        public string CollectedLabel
        {
            get { return this.Get<string>("CollectedLabel"); }
            set { this.Set("CollectedLabel", value); }
        }

        /// <summary>
        /// Specifies the label of the collected pie slice.
        /// This property applies only when a <see cref="CollectedThreshold"/> value is set.
        /// </summary>
        public string CollectedLegendText
        {
            get { return this.Get<string>("CollectedLegendText"); }
            set { this.Set("CollectedLegendText", value); }
        }

        /// <summary>
        /// Specifies whether the collected pie slice will be shown as exploded.
        /// This property applies only when a <see cref="CollectedThreshold"/> value is set.
        /// </summary>
        public bool CollectedSliceExploded
        {
            get { return this.Get<bool>("CollectedSliceExploded"); }
            set { this.Set("CollectedSliceExploded", value); }
        }

        /// <summary>
        /// Specifies the threshold value for collecting small pie slices.
        /// Any double between 0 and 100 if <see cref="CollectedThresholdUsePercent"/> is true; otherwise, any double > 0.
        /// </summary>
        public double CollectedThreshold
        {
            get { return this.Get<double>("CollectedThreshold"); }
            set { this.Set("CollectedThreshold", CollectedThresholdUsePercent && !value.Between(0, 100) ? 0.0 : value); }
        }

        /// <summary>
        /// Specifies whether to use the collected threshold value as a percentage.
        /// If set to True, data points will be collected based on values in percent below <see cref="CollectedThreshold"/>. 
        /// If set to False, data points will be collected based on the actual values below <see cref="CollectedThreshold"/>.
        /// </summary>
        public bool CollectedThresholdUsePercent
        {
            get { return this.Get<bool>("CollectedThresholdUsePercent"); }
            set { this.Set("CollectedThresholdUsePercent", value); }
        }

        /// <summary>
        /// Specifies the tooltip text for the collected pie slice.
        /// This custom property only applies when <see cref="CollectedThreshold"/> is set.
        /// </summary>
        public string CollectedToolTip
        {
            get { return this.Get<string>("CollectedToolTip"); }
            set { this.Set("CollectedToolTip", value); }
        }

        /// <summary>
        /// Specifies the label style of the data points.
        /// </summary>
        public LabelStyle LabelStyle
        {
            get { return this.Get<LabelStyle>("PieLabelStyle"); }
            set { this.Set("PieLabelStyle", value); }
        }

        /// <summary>
        /// Specifies the color of the radial and horizontal segments of the callout lines.
        /// This property applies only when <see cref="LabelStyle"/> is set to Outside.
        /// </summary>
        public Color LineColor
        {
            get { return this.Get<Color>("PieLineColor", Color.Empty); }
            set { this.Set("PieLineColor", value.ToArgb()); }
        }
        /// <summary>
        /// Specifies the minimum pie or size.
        /// When used with outside labeling (<see cref="LabelStyle"/>), this property controls the minimum acceptable pie size as a percentage of the chart area size. 
        /// This prevents the pie from becoming too small due to labels dominating the chart area.
        /// </summary>
        public int MinimumRelativeSize
        {
            get { return this.Get<int>("MinimumRelativePieSize"); }
            set { this.Set("MinimumRelativePieSize", value.Between(10, 70) ? value : 30); }
        }

        /// <summary>
        /// Specifies the 3D label line size as a percentage of the default size. 
        /// It represents the amount of space reserved for drawing the line that connects a pie slice to a label outside the chart area (see <see cref="LabelStyle"/>).
        /// </summary>
        public int LabelLineSize3D
        {
            get { return this.Get<int>("3DLabelLineSize"); }
            set { this.Set("3DLabelLineSize", value.Between(30, 200) ? value : 100); }
        }

        /// <summary>
        /// Specifies the size of the horizontal segment of the callout line, as a percentage of the chart area.
        /// This property applies only when <see cref="LabelStyle"/> is set to Outside.
        /// </summary>
        public int LabelsHorizontalLineSize
        {
            get { return this.Get<int>("LabelsHorizontalLineSize"); }
            set { this.Set("LabelsHorizontalLineSize", value.Between(0, 100) ? value : 1); }
        }

        /// <summary>
        /// Specifies the size of the radial segment of the callout line, as a percentage of the chart area.
        /// This property applies only when <see cref="LabelStyle"/> is set to Outside.
        /// </summary>
        public int LabelsRadialLineSize
        {
            get { return this.Get<int>("LabelsRadialLineSize"); }
            set { this.Set("LabelsRadialLineSize", value.Between(0, 100) ? value : 1); }
        }

        /// <summary>
        /// Specifies the starting angle of the first data point in the Pie.
        /// </summary>
        public int StartAngle
        {
            get { return this.Get<int>("PieStartAngle"); }
            set { this.Set("PieStartAngle", value.Between(0, 360) ? value : 90); }
        }

    }

}
