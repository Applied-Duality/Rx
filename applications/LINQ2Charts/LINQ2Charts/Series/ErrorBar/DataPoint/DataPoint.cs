// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Linq.Charting
{
    public partial class ErrorBar 
    {
        public new partial class DataPoint : Series<DataPoint>.DataPoint
        {
            public DataPoint(double center, double lower, double upper) : base(center, lower, upper) { }
            public DataPoint(Decimal center, Decimal lower, Decimal upper) : base(center, lower, upper) { }
            public DataPoint(Single center, Single lower, Single upper) : base(center, lower, upper) { }
            public DataPoint(int center, int lower, int upper) : base(center, lower, upper) { }
            public DataPoint(long center, long lower, long upper) : base(center, lower, upper) { }
            public DataPoint(uint center, uint lower, uint upper) : base(center, lower, upper) { }
            public DataPoint(ulong center, ulong lower, ulong upper) : base(center, lower, upper) { }
            public DataPoint(string center, string lower, string upper) : base(center, lower, upper) { }
            public DataPoint(DateTime center, DateTime lower, DateTime upper) : base(center, lower, upper) { }
            public DataPoint(short center, short lower, short upper) : base(center, lower, upper) { }
            public DataPoint(ushort center, ushort lower, ushort upper) : base(center, lower, upper) { }
        }
    }

}
