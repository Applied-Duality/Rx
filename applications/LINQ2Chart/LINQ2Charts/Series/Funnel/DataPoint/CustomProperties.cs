// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Drawing;

namespace System.Linq.Charting
{
    partial class Funnel 
    {
         partial class DataPoint 
        {
            /// <summary>
            /// Specifies the line color of the callout for the data point labels of Funnel and Pyramid charts.
            /// This custom property applies only when the FunnelLabelStyle or PyramidLabelStyle is set to OutsideInColumn.
            /// </summary>
            public Color CalloutLineColor
            {
                get { return this.Get<Color>("CalloutLineColor"); }
                set { this.Set("CalloutLineColor", value); }
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
            /// Specifies the placement of the data point label in the Funnel chart.
            /// This property applies only when FunnelLabelStyle is set to Outside or OutsideInColumn.
            /// </summary>
            public FunnelOutsideLabelPlacement FunnelOutsideLabelPlacement
            {
                get { return this.Get<FunnelOutsideLabelPlacement>("FunnelOutsideLabelPlacement"); }
                set { this.Set("FunnelOutsideLabelPlacement", value); }
            }
        }
    }

}
