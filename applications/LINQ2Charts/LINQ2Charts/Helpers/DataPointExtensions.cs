// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Linq;

namespace System.Windows.Forms.DataVisualization.Charting
{
    public static class DataPointExtensions
    {
        /// <summary>
        /// Sets the X-value of the data point.
        /// </summary>
        public static DataPoint SetValueX(this DataPoint point, object xValue)
        {
            point.SetValueXY(xValue, point.YValues.Cast<object>().ToArray());
            return point;
        }
    }
}