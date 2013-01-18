// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Collections;
using System.Collections.Generic;

namespace System.Linq.Charting
{
    // keep the C# compiler happy
    public partial class Series<S> : IEnumerable<S>
    {

        public IEnumerator<S> GetEnumerator()
        {
            return BasePoints.Cast<S>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
