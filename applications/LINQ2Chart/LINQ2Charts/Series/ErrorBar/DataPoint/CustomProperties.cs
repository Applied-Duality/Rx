// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Linq.Charting
{
    partial class ErrorBar 
    {
        partial class DataPoint 
        {
            /// <summary>
            /// Specifies the appearance of the marker at the center value of the error bar.
            /// </summary>
            public ErrorBarCenterMarkerStyle ErrorBarCenterMarkerStyle
            {
                get { return this.Get<ErrorBarCenterMarkerStyle>("ErrorBarCenterMarkerStyle "); }
                set { this.Set("ErrorBarCenterMarkerStyle ", value); }
            }

            /// <summary>
            /// Specifies the visibility of the upper and lower error values.
            /// </summary>
            public ErrorBarStyle ErrorBarStyle
            {
                get { return this.Get<ErrorBarStyle>("ErrorBarStyle"); }
                set { this.Set("ErrorBarStyle", value); }
            }
        }
    }

}
