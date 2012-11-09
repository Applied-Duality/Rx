// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Drawing;

namespace System.Linq.Charting
{
    partial class Stock 
    {
        partial class DataPoint 
        {
            /// <summary>
            ///Specifies the Y value to use as the data point label.
            /// </summary>
            public LabelValueType LabelValueType
            {
                get { return this.Get<LabelValueType>("LabelValueType"); }
                set { this.Set("LabelValueType", value); }
            }

            /// <summary>
            /// Specifies the marker style for open and close values.
            /// </summary>
            public OpenCloseStyle OpenCloseStyle
            {
                get { return this.Get<OpenCloseStyle>("OpenCloseStyle"); }
                set { this.Set("OpenCloseStyle", value); }
            }

            /// <summary>
            /// Specifies the data point color to use to indicate a decreasing trend.
            /// A price is considered decreasing when the close value is less than the open value.
            /// </summary>
            public Color PriceDownColor
            {
                get { return this.Get<Color>("PriceDownColor"); }
                set { this.Set("PriceDownColor", value.ToArgb()); }
            }

            /// <summary>
            /// Specifies the data point color that indicates an increasing trend.
            /// A price is considered increasing when the close value is greater than the open value.
            /// </summary>
            public Color PriceUpColor
            {
                get { return this.Get<Color>("PriceUpColor"); }
                set { this.Set("PriceUpColor", value.ToArgb()); }
            }
        }
    }

}
