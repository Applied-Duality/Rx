// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Linq.Charting
{
    partial class Series<S> where S : Series<S>.DataPoint
    {
        public abstract partial class DataPoint : System.Windows.Forms.DataVisualization.Charting.DataPoint 
        {
            protected DataPoint(params object[] values)
            {
                base.SetValueY(values);
            }
        }

        protected virtual DataPoint CreateDataPoint(params object[] values)
        {
            return Activator.CreateInstance(GetType().GetNestedType("DataPoint"), values) as DataPoint;
        }
    }
}
