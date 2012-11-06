// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Linq.Charting
{
    partial class  StackedColumnOr_<S>
    {
        partial class DataPoint 
        {
            /// <summary>
            /// Specifies the drawing style of data points.
            /// </summary>
            public DrawingStyle DrawingStyle
            {
                get { return this.Get<DrawingStyle>("DrawingStyle"); }
                set { this.Set("DrawingStyle", value); }
            }
        }
    }

}
