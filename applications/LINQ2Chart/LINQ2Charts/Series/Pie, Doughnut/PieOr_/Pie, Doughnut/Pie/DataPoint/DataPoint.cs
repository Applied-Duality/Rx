// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Linq.Charting
{
    public partial class Pie 
    {
        public new partial class DataPoint : PieOr_<DataPoint>.DataPoint
        {
            public DataPoint(object value) : base(value) { }
        }
    }

}
