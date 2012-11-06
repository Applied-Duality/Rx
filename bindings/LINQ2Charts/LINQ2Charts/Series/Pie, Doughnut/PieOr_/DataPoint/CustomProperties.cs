// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Drawing;

namespace System.Linq.Charting
{
    partial class PieOr_<S>
    {
        partial class DataPoint 
        {
            /// <summary>
            /// Specifies whether the <see cref="Pie"/> data point is exploded.
            /// </summary>
            public bool Exploded
            {
                get { return this.Get<bool>("Exploded"); }
                set { this.Set("Exploded", value); }
            }

            /// <summary>
            /// Specifies the label style of the data points.
            /// </summary>
            public LabelStyle LabelStyle
            {
                get { return this.Get<LabelStyle>("PielLabelStyle"); }
                set { this.Set("PielLabelStyle", value); }
            }

            /// <summary>
            /// Specifies the color of the radial and horizontal segments of the callout lines.
            /// This property applies only when <see cref="LabelStyle"/> is set to Outside.
            /// </summary>
            public Color LineColor
            {
                get { return this.Get<Color>("PieLineColor"); }
                set { this.Set("PieLineColor", value.ToArgb()); }
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
                get { return this.Get<int>("LabelsHorizontalLineSize"); }
                set { this.Set("LabelsRadialLineSize", value.Between(0, 100) ? value : 1); }
            }
        }
    }

}
