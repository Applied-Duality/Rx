// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Drawing;

namespace System.Linq.Charting
{
    partial class Pyramid 
    {
        partial class DataPoint 
        {
            /// <summary>
            /// Specifies the line color of the callout for the data point labels of Funnel and Pyramid charts.
            /// This custom property applies only when the FunnelLabelStyle or PyramidLabelStyle is set to OutsideInColumn.
            /// </summary>
            public Color CalloutLineColor
            {
                get { return this.Get<Color>("CalloutLineColor "); }
                set { this.Set("CalloutLineColor", value); }
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
            /// Specifies the placement of the data point labels in the Pyramid chart when the labels are placed outside the pyramid.
            /// This property applies only when the PyramidLabelStyle is set to Outside or OutsideInColumn.
            /// </summary>
            public PyramidOutsideLabelPlacement PyramidOutsideLabelPlacement
            {
                get { return this.Get<PyramidOutsideLabelPlacement>("PyramidOutsideLabelPlacement"); }
                set { this.Set("PyramidOutsideLabelPlacement", value); }
            }
        }
    }

}
