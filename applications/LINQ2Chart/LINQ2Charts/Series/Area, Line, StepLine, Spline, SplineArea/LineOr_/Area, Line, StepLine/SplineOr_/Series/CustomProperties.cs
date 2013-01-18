namespace System.Linq.Charting
{
    partial class SplineOr_<S>
    {
        /// <summary>
        /// Specifies the line tension for the drawing of curves between data points.
        /// </summary>
        public double LineTension
        {
            get { return this.Get<double>("LineTension"); }
            set { this.Set("LineTension", value.Between(0,2) ? value : 0.8); }
        }
    }

}
