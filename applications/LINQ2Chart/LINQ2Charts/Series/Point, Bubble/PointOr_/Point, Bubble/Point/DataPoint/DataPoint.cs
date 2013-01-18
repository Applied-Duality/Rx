// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Linq.Charting
{
    public partial class Point 
    {
        public new partial class DataPoint : PointOr_<DataPoint>.DataPoint 
        {
            public DataPoint(object value) : base(value) { }
        }
    }

}
