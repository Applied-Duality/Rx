// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Linq.Charting
{
    public partial class PointOr_<S> 
    {
        public abstract partial class DataPoint : Series<S>.DataPoint
        {
            internal DataPoint(object value) : base(value) { }

            internal DataPoint(params object[] values)
                : base(values){}
        }
    }

}
