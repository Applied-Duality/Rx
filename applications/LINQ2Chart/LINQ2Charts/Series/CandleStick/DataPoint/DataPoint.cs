// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Linq.Charting
{
    partial class Candlestick 
    {
        public new partial class DataPoint : Series<DataPoint>.DataPoint
        {
            public DataPoint(double high, double low, double open, double close) : base(high, low, open, close) { }
            public DataPoint(Decimal high, Decimal low, Decimal open, Decimal close) : base(high, low, open, close) { }
            public DataPoint(Single high, Single low, Single open, Single close) : base(high, low, open, close) { }
            public DataPoint(int high, int low, int open, int close) : base(high, low, open, close) { }
            public DataPoint(long high, long low, long open, long close) : base(high, low, open, close) { }
            public DataPoint(uint high, uint low, uint open, uint close) : base(high, low, open, close) { }
            public DataPoint(ulong high, ulong low, ulong open, ulong close) : base(high, low, open, close) { }
            public DataPoint(string high, string low, string open, string close) : base(high, low, open, close) { }
            public DataPoint(DateTime high, DateTime low, DateTime open, DateTime close) : base(high, low, open, close) { }
            public DataPoint(short high, short low, short open, short close) : base(high, low, open, close) { }
            public DataPoint(ushort high, ushort low, ushort open, ushort close) : base(high, low, open, close) { }
        }
    }

}
