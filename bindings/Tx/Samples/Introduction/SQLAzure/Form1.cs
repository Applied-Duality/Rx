using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reactive.Linq;
using System.Reactive.Tx;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace SQLAzure
{
    public partial class Form1 : Form
    {
        Dictionary<string, Series> _partitions = new Dictionary<string, Series>();
        DateTime startTime = DateTime.Parse("1/2/2012 12:00:00 AM");
        Series _detected;
        IDisposable _subscription;


        public Form1()
        {
            InitializeComponent();
            chart1.Series.Clear();
            chart1.Legends.Clear();

            _detected = new Series { ChartType = SeriesChartType.FastPoint };
            _detected.Name = "Detected";
            _detected.Points.Clear();
            _detected.MarkerSize = 15;
            _detected.MarkerStyle = MarkerStyle.Cross;
            _detected.MarkerColor = Color.Red;
            chart1.Series.Add(_detected);
        }        
        
        private void Form1_Load(object sender, EventArgs e)
        {
            Playback playback = new Playback();

            playback.AddTextTrace(@"..\..\sorted.csv");
            IObservable<PartitionEvent> all = playback.GetObservable<PartitionEvent>();

            all.ObserveOn(this)
                .Subscribe(evt=>
                {
                    double x = (evt.Timeflag-startTime).TotalHours;
                    double y = PartitionY(evt.PartitionId);
                    AddPoint(evt.PartitionId, x, y);
                });

            #region outage detection

            var grouped = (from a in all.GroupByUntil(
                                    evt => evt.PartitionId,
                                    g => Observable.Timer(TimeSpan.FromMinutes(10), playback.Scheduler))
                           from Count in a.Count()
                           where Count > 100
                           select new
                           {
                               PartitionId = a.Key,
                               Count
                           })
                          .Timestamp(playback.Scheduler);


            _subscription = grouped.ObserveOn(this).Subscribe(evt =>
                {
                    double x = (evt.Timestamp - startTime).TotalHours;
                    double y = PartitionY(evt.Value.PartitionId);
                    _detected.Points.AddXY(x, y);
                });

            #endregion

            #region
            //all.Throttle(TimeSpan.FromMinutes(1), playback.Scheduler) // <-- Playback virtual time!
            //    .ObserveOn(this)
            //    .Subscribe(evt =>
            //        {
            //            double horizon = (evt.Timeflag - startTime).TotalHours - 2;
            //            CleanTo(horizon);
            //        });
            #endregion

            playback.Start();
        }

        #region drawing helpers unrelated to the Playback usage
        int PartitionY(string partitonId)
        {
            ulong result;
            if (ulong.TryParse(partitonId, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out result))
                return (int)(result / 256);

            return 0;
        }

        void AddPoint(string seriesName, double x, double y)
        {
            Series series;
            if (!_partitions.TryGetValue(seriesName, out series))
            {
                series = new Series { ChartType = SeriesChartType.FastPoint };
                series.Name = seriesName;
                series.Points.Clear();
                series.MarkerSize = 5;
                _partitions.Add(seriesName, series);
                chart1.Series.Add(series);

                series.Points.AddXY(x, y);
                series.Tag = y;
            }
            else
            {
                series.Points.AddXY(x, series.Tag);
            }
        }

        void CleanTo(double horizon)
        {
            foreach (Series s in _partitions.Values)
            {
                s.Points.SuspendUpdates();
                while (s.Points.Count > 0 && s.Points[0].XValue < horizon)
                {
                    s.Points.RemoveAt(0);
                }
                s.Points.ResumeUpdates();
            }
        }
        #endregion
    }
}
