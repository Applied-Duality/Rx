// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Windows.Forms.DataVisualization.Charting;

namespace System.Linq.Charting
{
    public abstract partial class Series<S> : Series
    {
        protected Series(): base(Guid.NewGuid().ToString()) 
        {
            Points = new Data(this);
        }

        public new Data Points { get; private set; }
        public DataPointCollection BasePoints { get { return base.Points; } }

        public void Add(S value) { BasePoints.Add(value); }
        public void Add(object key, S value) { BasePoints.Add(value.SetValueX(key)); }
   }
}
