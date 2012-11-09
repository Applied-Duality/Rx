// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Charting;
using System.Windows.Forms;

namespace Samples
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Form()
                        { ClientSize = new System.Drawing.Size(771, 496)
                        , Controls = { new TabControl() 
                                        { Dock = DockStyle.Fill
                                        , Controls = { new TabPage("Pie") { Controls = { Demos.Pie() } }
                                                     , new TabPage("Doughnut") { Controls = { Demos.Doughnut() } }
                                                     , new TabPage("Bar") { Controls = { Demos.Bar() } }
                                                     , new TabPage("Fuel Economy") { Controls = { Demos.FuelEconomy() } }
                                                     , new TabPage("3D Lines") { Controls = { Demos.Lines3D() } }
                                                     , new TabPage("Pixels") { Controls = { Demos.Pixels() } }
                                                     , new TabPage("Fast") { Controls = { Demos.Fast() } }
                                                     } 
                                        }
                                     }
                        , Text = "LINQ2Charts Demos"
                        });
        }
    }

    public class Demos
    {
        public static Chart Pie()
            {
                var pie = new Pie
                {
                    Points = { { "System",  20 }
                             , { "Linq", new Pie.DataPoint(40){ ToolTip = "LINQ to Charts!", } }
                             , { "Charting", new Pie.DataPoint(10){ Color = Color.HotPink }}
                             }
                , DrawingStyle = PieDrawingStyle.Concave
                , StartAngle = 45
                };

                var piechart = new Chart { pie };
                piechart.Dock = DockStyle.Fill;
                return piechart;
            }
        public static Chart Doughnut()
            {
                var doughnut = new Doughnut
                {
                    Points = { {"France", 65.62}
                                      , {"Canada", 75.54}
                                      , { "UK", new Doughnut.DataPoint(60.45) 
                                                { Exploded = true
                                                , LegendText = "God save the queen!"
                                                } 
                                         }
                                      , {"USA", 55.73}
                                      , {"Italy", 70.42}
                                      }
                ,
                    DoughnutRadius = 60
                ,
                    DrawingStyle = PieDrawingStyle.SoftEdge
                ,
                    LabelStyle = LabelStyle.Inside
                };

                var doughnutchart = new Chart { doughnut };
                doughnutchart.Dock = DockStyle.Fill;
                return doughnutchart;
            }
        public static Chart Bar()
        {
            var column1 = new Column
            {
                Points = { 6, 9, 5, 7.5, 5.6999998092651367, 3.2000000476837158, 8.5, 7.5, 6.5 }
            };

            var column2 = new Column { 6, 9, 2, 7, 3, 5, 8, 2, 6 };
            var column3 = new Column { Points = { 4, 5, 2, 6, 1, 2, 3, 1, 5 } };

            var area = new ChartArea
            { Series = { column1, column2, column3 }
            , AxisX = { IsMarginVisible = true }
            , Area3DStyle = { Enable3D = true, Rotation = 30, Inclination = 10, IsRightAngleAxes = false }
            };
            return new Chart { ChartAreas = { area }, Dock = DockStyle.Fill };
        }
        public static Chart Lines3D()
            {
                var series1 = new Spline();
                var series2 = new Spline();
                var series3 = new Spline();

                // imperative
                var random = new Random();
                for (var pointIndex = 0; pointIndex < 10; pointIndex++)
                {
                    series1.Add(random.Next(45, 95));
                    series2.Add(random.Next(5, 75));
                    series3.Add(random.Next(2, 50));
                }

                var area = new System.Linq.Charting.ChartArea
                {
                    Area3DStyle =
                    {
                        Enable3D = true
                    ,
                        Inclination = 38
                    ,
                        Rotation = 9
                    ,
                        Perspective = 10
                    ,
                        PointDepth = 200
                    ,
                        LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic
                    ,
                        IsRightAngleAxes = false
                    ,
                        WallWidth = 0
                    }
                ,
                    AxisX = { IsMarginVisible = true }
                ,
                    Series = { series1, series2, series3 }
                };

                var chart = new System.Linq.Charting.Chart
                {
                    ChartAreas = { area }
                ,
                    Titles = { new System.Windows.Forms.DataVisualization.Charting.Title{ Text = "Three 3D Lines"
					                          , Font = new Font(FontFamily.GenericSansSerif, 20) 
					                          }
			                        }
                ,
                    Dock = DockStyle.Fill
                };
                return chart;

            }
        public static Chart FuelEconomy()
        {
            #region
            Func<Car, double> Displacement = car => car.Displacement;
            Func<Car, int> Highway = car => car.Highway;
            Func<Car, int> Cylinders = car => car.Cylinders;
            #endregion

            var cars = Car.ParseFromFile();

            var data = from car in cars.GroupBy(Displacement).ThenBy(Highway, Cylinders)
                       from hwy in car from cylinder in hwy
                       select new
                       { X = car.Key
                       , Y = new System.Linq.Charting.Point.DataPoint(hwy.Key)
                           { Color = CylindersToColor(cylinder)
                           , MarkerSize = cylinder * 4
                           , ToolTip = string.Format("{0} cyclinders", cylinder)
                           }
                       };

            var series = new System.Linq.Charting.Point
            {
                Points = { data.Select(xy => KeyValuePair.Create(xy.X, xy.Y)) }
            };

            var area = new ChartArea
            { Series = { series }
            , AxisX = { Title = "Displacement" }
            , AxisY = { Title = "Highway mpg" }
            };

            return new Chart { ChartAreas = { area }, Dock = DockStyle.Fill };
        }
        public static Chart Pixels()
        {

            var path = Path.Combine(Environment.CurrentDirectory, "logo.png");
            var image = new Bitmap(path);

            var pixels = ColorPoint.Pixels(image);

            var copy = from pixel in pixels
                       let y = new System.Linq.Charting.Point.DataPoint(image.Height - pixel.Y) { Color = pixel.Color }
                       let x = pixel.X + 1
                       select KeyValuePair.Create(x, y);

            var pixelated = new System.Linq.Charting.Point 
                            { Points = { copy } 
                            };

            return new Chart { ChartAreas = { pixelated }, Dock = DockStyle.Fill };
        }

        public static Chart Fast()
        {
            var ys1 = EnumerableEx.Defer(delegate { var random = new Random(0); 
                        return EnumerableEx.Generate(50.0, y => true, y => y + (random.NextDouble() * 10.0 - 5.0), y => y); });
            var ys2 = EnumerableEx.Defer(delegate { var random = new Random(1); 
                        return EnumerableEx.Generate(200.0, y => true, y => y + (random.NextDouble() * 10.0 - 5.0), y => y); });

            var beans = new FastLine()
            { Points = { from y in ys1.Take(1000000) select y }
            , LegendText = "Garbonzo Beans"
            };

            var brocolli = new FastLine()
            { Points = { from y in ys2.Take(1000000) select y }
            , LegendText = "Brocolli"
            };

            var chart = new Chart
            {
                ChartAreas = { new ChartArea { beans, brocolli } },
                BackColor = System.Drawing.Color.WhiteSmoke,
                BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom,
                BackSecondaryColor = System.Drawing.Color.White,
                BorderlineColor = System.Drawing.Color.FromArgb(26, 59, 105),
                BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid,
                BorderlineWidth = 2,
                BorderSkin = { SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss },
                Dock = DockStyle.Fill
            };

            return chart;
        }

        class ColorPoint
        {
            public int X { get; set; }
            public int Y { get; set; }
            public Color Color { get; set; }

            public static IEnumerable<ColorPoint> Pixels(Bitmap image)
            {
                for (var x = 0; x < image.Width; x++)
                    for (var y = 0; y < image.Height; y++)
                        yield return new ColorPoint { X = x, Y = y, Color = image.GetPixel(x, y) };
            }
        }

        #region Helpers
        public static Color CylindersToColor(int nrOfCylinders)
        {
            switch (nrOfCylinders)
            {
                case 4: return Color.Green;
                case 6: return Color.Yellow;
                case 8: return Color.Red;
                case 12: return Color.Blue;
                default: return Color.Azure;
            }
        }
        public class Car
        {
            public static IEnumerable<Car> ParseFromFile()
            {
                var path = Environment.CurrentDirectory;
                return Car.ParseFromFile(Path.Combine(path, "fuel.csv"));
            }

            public static IEnumerable<Car> ParseFromFile(string file)
            {
                return from line in File.ReadAllLines(file).Skip(1) // skip header
                       let fields = line.Split(',')
                       select new Car { Displacement = double.Parse(fields[0]), Cylinders = int.Parse(fields[1]), City = int.Parse(fields[2]) , Highway = int.Parse(fields[3]) };
            }

            public double Displacement { get; set; }
            public int Cylinders { get; set; }
            public int City { get; set; }
            public int Highway { get; set; }
        }
        #endregion
    }
}
