// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Linq.Charting
{
    partial class SplineRange 
    {
        public new partial class DataPoint : RangeOr_<DataPoint>.DataPoint
        {
            public DataPoint(double high, double low) : base(high, low) { }
            public DataPoint(Decimal high, Decimal low) : base(high, low) { }
            public DataPoint(Single high, Single low) : base(high, low) { }
            public DataPoint(int high, int low) : base(high, low) { }
            public DataPoint(long high, long low) : base(high, low) { }
            public DataPoint(uint high, uint low) : base(high, low) { }
            public DataPoint(ulong high, ulong low) : base(high, low) { }
            public DataPoint(string high, string low) : base(high, low) { }
            public DataPoint(DateTime high, DateTime low) : base(high, low) { }
            public DataPoint(short high, short low) : base(high, low) { }
            public DataPoint(ushort high, ushort low) : base(high, low) { }
        }
    }
}
