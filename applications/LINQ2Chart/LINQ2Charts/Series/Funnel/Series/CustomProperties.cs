// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Drawing;

namespace System.Linq.Charting
{
    partial class Funnel
    {
        /// <summary>
        /// Specifies the line color of the callout for the data point labels of Funnel and Pyramid charts.
        /// This custom property applies only when the FunnelLabelStyle or PyramidLabelStyle is set to OutsideInColumn.
        /// </summary>
        public Color CalloutLineColor 
        {
            get { return this.Get<Color>("CalloutLineColor "); }
            set { this.Set("CalloutLineColor", value.ToArgb()); }
        }

        /// <summary>
        /// Specifies the 3D drawing style of the Funnel chart.
        /// </summary>
        public Funnel3DDrawingStyle Funnel3DDrawingStyle
        {
            get { return this.Get<Funnel3DDrawingStyle>("Funnel3DDrawingStyle"); }
            set { this.Set("Funnel3DDrawingStyle", value); }
        }

        /// <summary>
        /// Specifies the 3D rotation angle of the Funnel chart.
        /// </summary>
        public int Funnel3DRotationAngle
        {
            get { return this.Get<int>("Funnel3DRotationAngle"); }
            set { this.Set("Funnel3DRotationAngle", value.Between(-10,10) ? value : 5); }
        }

        /// <summary>
        /// Specifies the data point label placement for a Funnel chart.
        /// This property applies only when FunnelLabelStyle is set to Inside.
        /// </summary>
        public FunnelInsideLabelAlignment FunnelInsideLabelAlignment 
        {
            get { return this.Get<FunnelInsideLabelAlignment>("FunnelInsideLabelAlignment"); }
            set { this.Set("FunnelInsideLabelAlignment", value); }
        }

        /// <summary>
        /// Specifies the data point label style of the Funnel chart.
        /// If this property is not set to Disabled, the properties FunnelInsideLabelAlignment and FunnelOutsideLabelPlacement are used to specify additional positioning rules.
        /// </summary>
        public FunnelLabelStyle FunnelLabelStyle
        {
            get { return this.Get<FunnelLabelStyle>("FunnelLabelStyle"); }
            set { this.Set("FunnelLabelStyle", value); }
        }

        /// <summary>
        /// Specifies the minimum height of a data point in the Funnel chart, measured in relative coordinates.
        /// Any point that would typically be drawn smaller than the amount specified by this property is drawn using the specified value instead. 
        /// This eliminates the occurrence of very thin slices, which may be difficult or impossible to see when displayed in the chart picture.
        /// </summary>
        public int FunnelMinPointHeight 
        {
            get { return this.Get<int>("FunnelMinPointHeight"); }
            set { this.Set("FunnelMinPointHeight", value.Between(0,100) ? value : 0); }
        }

        /// <summary>
        /// Specifies the neck height of the Funnel chart.
        /// This property applies only when the FunnelStyle property is set to YIsHeight.
        /// </summary>
        public int FunnelNeckHeight
        {
            get { return this.Get<int>("FunnelNeckHeight"); }
            set { this.Set("FunnelNeckHeight", value.Between(0, 100) ? value : 5); }
        }

        /// <summary>
        /// Specifies the neck width of the Funnel chart.
        /// This property applies only when the FunnelStyle property is set to YIsWidth.
        /// </summary>
        public int FunnelNeckWidth
        {
            get { return this.Get<int>("FunnelNeckWidth"); }
            set { this.Set("FunnelNeckWidth", value.Between(0, 100) ? value : 5); }
        }

        /// <summary>
        /// Specifies the placement of the data point label in the Funnel chart.
        /// This property applies only when FunnelLabelStyle is set to Outside or OutsideInColumn.
        /// </summary>
        public FunnelOutsideLabelPlacement FunnelOutsideLabelPlacement 
        {
            get { return this.Get<FunnelOutsideLabelPlacement>("FunnelOutsideLabelPlacement "); }
            set { this.Set("FunnelOutsideLabelPlacement ", value); }
        }

        /// <summary>
        /// Specifies the gap size between the points of a Funnel chart, measured in relative coordinates.
        /// The maximum gap size is limited by the number of data points.
        /// </summary>
        public int FunnelPointGap
        {
            get { return this.Get<int>("FunnelPointGap"); }
            set { this.Set("FunnelPointGap", value.Between(0, 100) ? value : 0); }
        }

        /// <summary>
        /// Specifies the style of the Funnel chart.
        /// </summary>
        public FunnelStyle FunnelStyle
        {
            get { return this.Get<FunnelStyle>("FunnelStyle"); }
            set { this.Set("FunnelStyle", value); }
        }
    }
}
