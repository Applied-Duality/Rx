// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Drawing;

namespace System.Linq.Charting
{
    partial class Pyramid
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
        /// Specifies the 3D drawing style of the Pyramid chart.
        /// This custom property applies only when the property ChartArea.Area3DStyle.Enable3D is set to True.
        /// </summary>
        public Pyramid3DDrawingStyle Pyramid3DDrawingStyle
        {
            get { return this.Get<Pyramid3DDrawingStyle>("Pyramid3DDrawingStyle"); }
            set { this.Set("Pyramid3DDrawingStyle", value); }
        }

        /// <summary>
        /// Specifies the 3D rotation angle for a Pyramid chart.
        /// </summary>
        public int Pyramid3DRotationAngle 
        {
            get { return this.Get<int>("Pyramid3DRotationAngle "); }
            set { this.Set("Pyramid3DRotationAngle ", value.Between(-10, 10) ? value : 5); }
        }

        /// <summary>
        /// Specifies the data point label placement for a Pyramid chart.
        /// This property applies only when PyramidLabelStyle is set to Inside.
        /// </summary>
        public PyramidInsideLabelAlignment PyramidInsideLabelAlignment 
        {
            get { return this.Get<PyramidInsideLabelAlignment>("PyramidInsideLabelAlignment"); }
            set { this.Set("PyramidInsideLabelAlignment", value); }
        }

        /// <summary>
        /// Specifies the data point label style of the Pyramid chart.
        /// If this property is not set to Disabled, the properties PyramidInsideLabelAlignment and PyramidOutsideLabelPlacement are used to specify additional positioning rules.
        /// </summary>
        public PyramidLabelStyle PyramidLabelStyle
        {
            get { return this.Get<PyramidLabelStyle>("PyramidLabelStyle"); }
            set { this.Set("PyramidLabelStyle", value); }
        }

        /// <summary>
        /// Specifies the minimum height of a data point measured in relative coordinates.
        /// The Pyramid chart uses this property for the displayed height of any data point with a value less than its value. 
        /// This eliminates very thin slices.
        /// /// </summary>
        public int PyramidMinPointHeight 
        {
            get { return this.Get<int>("PyramidMinPointHeight"); }
            set { this.Set("PyramidMinPointHeight", value.Between(0,100) ? value : 0); }
        }

        /// <summary>
        /// Specifies the placement of the data point labels in the Pyramid chart when the labels are placed outside the pyramid.
        /// This property applies only when the PyramidLabelStyle is set to Outside or OutsideInColumn.
        /// /// </summary>
        public PyramidOutsideLabelPlacement PyramidOutsideLabelPlacement 
        {
            get { return this.Get<PyramidOutsideLabelPlacement>("PyramidOutsideLabelPlacement"); }
            set { this.Set("PyramidOutsideLabelPlacement", value); }
        }

        
        /// <summary>
        /// Specifies the gap size between the points of a Pyramid chart, measured in relative coordinates.
        /// The maximum gap size is limited by the number of data points.
        /// </summary>
        public int PyramidPointGap
        {
            get { return this.Get<int>("PyramidPointGap"); }
            set { this.Set("PyramidPointGap", value.Between(0, 100) ? value : 0); }
        }

        /// <summary>
        /// Specifies whether the data point value represents a linear height or the surface of the segment.
        /// </summary>
        public PyramidValueType PyramidValueType
        {
            get { return this.Get<PyramidValueType>("PyramidValueType"); }
            set { this.Set("PyramidValueType", value); }
        }
    }
}
