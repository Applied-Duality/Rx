// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Linq.Charting
{
    partial class Doughnut
    {
        /// <summary>
        /// Specifies the radius of the doughnut portion in the Doughnut chart.
        /// The value of this property affects the size of the circle that is used for the doughnut hole. 
        /// The larger the value of DoughnutRadius, the smaller the doughnut hole of the chart. 
        /// For example, if set to 100, the doughnut hole does not exist and the chart looks like a Pie chart.
        /// </summary>
        public int DoughnutRadius
        {
            get { return this.Get<int>("DoughnutRadius "); }
            set { this.Set("DoughnutRadius ", value.Between(0,100) ? value : 60); }
        }
    }
}