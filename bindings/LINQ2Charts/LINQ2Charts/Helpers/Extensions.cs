// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Linq.Charting
{
    public static class Extensions
    {
        public static bool Between(this int n, int lower, int upper)
        {
            return n >= lower && n <= upper;
        }

        public static bool Between(this double n, double lower, double upper)
        {
            return n >= lower && n <= upper;
        }
    }
}