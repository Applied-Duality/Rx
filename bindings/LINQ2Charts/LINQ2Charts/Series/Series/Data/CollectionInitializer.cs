// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Collections;
using System.Collections.Generic;

namespace System.Linq.Charting
{
    partial class Series<S>
    {
        partial class Data : IEnumerable<S> 
        {
            IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }

            public IEnumerator<S> GetEnumerator()
            {
                return _series.GetEnumerator();
            }
        }
    }

}
