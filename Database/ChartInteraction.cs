using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

using Graph;
using Shauni;

namespace Shauni.Database
{
    public class ChartCreator
    {
        protected ShauniDatabase database;
        private Random random = new Random((Int32)(DateTime.Now.Ticks % Int32.MaxValue));

        public ChartCreator(ShauniDatabase database)
        {
            this.database = database;
        }

        public List<DataSeries> CreateTotalPlaysArtistChart(int top)
        {
            var stat = (from s in database.AudioStatistic
                        join a in database.Artist on s.ArtistID equals a.ID
                        orderby s.Counter descending
                        select new { s.Artist.Name, s.TimeLineID, s.Counter });

            var groups = (from income in stat
                          group income by income.Name into result
                          select new
                          {
                              Name = result.Key,
                              Sum = result.Sum(i => i.Counter)
                          }).OrderByDescending(s => s.Sum).Take(top).OrderBy(s => s.Sum).ToList();

            List<DataSeries> dataSeries = new List<DataSeries>();
            DataSeries series;

            var gradient = this.CreateColorGradient(top, Color.Blue);

            for (int i = 1; i < groups.Count() + 1; i++)
            {
                series = new DataSeries(Color.LightGray, Color.Black, Color.DimGray) { Thickness = 1f };

                series.Name = groups[i - 1].Name;
                series.SymbolStyle.SymbolSize = 15;
                series.AddPoint(new PointF(i, groups[i - 1].Sum));

                dataSeries.Add(series);

                series.SymbolStyle.FillColor = gradient[i - 1];
            }

            return dataSeries;
        }

        public List<DataSeries> CreateEvolutionPlaysArtistChart(int top)
        {
            var stat = (from s in database.AudioStatistic
                        join a in database.Artist on s.ArtistID equals a.ID
                        orderby s.Counter descending
                        select new { s.Artist.Name, s.TimeLineID, s.Counter });

            var groups = (from b in stat
                          join f in database.TimeLine on b.TimeLineID equals f.ID
                          select new { b.Name, f.Date, b.Counter }).GroupBy(m => m.Name);

            int[] X, Y;

            List<DataSeries> dataSeries = new List<DataSeries>();
            DataSeries series;

            foreach (var group in groups)
            {
                int count = group.Count();
                var orderedGroup = group.OrderBy(g => g.Date).ToList();

                series = new DataSeries(Color.LightGray, this.GetRandomColor(), Color.DimGray) { Thickness = 1f };

                X = new int[count];
                Y = new int[count];

                for (int h = 0; h < count; h++)
                {
                    series.Name = orderedGroup[h].Name;

                    Y[h] = h == 0 ? orderedGroup[h].Counter : Y[h - 1] + orderedGroup[h].Counter;
                    X[h] = orderedGroup[h].Date.Day;

                    series.AddPoint(new PointF(X[h], Y[h]));
                }

                dataSeries.Add(series);
            }

            return dataSeries;
        }

        public void CreateMainChart(Song s, Chart2D chart)
        {
            var stat = (from m in SharedData.Database.AudioStatistic
                        join a in SharedData.Database.Artist on m.ArtistID equals a.ID
                        orderby s.Counter descending
                        select new { m.Artist.Name, m.TimeLineID, m.Counter });

            var groups = (from b in stat
                          join f in SharedData.Database.TimeLine on b.TimeLineID equals f.ID
                          select new { b.Name, f.Date, b.Counter }).Where(m => m.Name == s.Artist.Name);

            chart.DataCollection.RemoveAll();
            DataSeries series = new DataSeries(Color.LightGray, Color.Blue, Color.DimGray) { Thickness = 0.5f };

            int count = groups.Count();
            var orderedGroup = groups.OrderBy(g => g.Date).ToList();

            series = new DataSeries(Color.LightGray, Color.Blue, Color.DimGray) { Thickness = 1f };

            int[] X = new int[count];
            int[] Y = new int[count];

            for (int h = 0; h < count; h++)
            {
                series.Name = orderedGroup[h].Name;

                Y[h] = h == 0 ? orderedGroup[h].Counter : Y[h - 1] + orderedGroup[h].Counter;
                X[h] = orderedGroup[h].Date.Day;

                series.AddPoint(new PointF(X[h], Y[h]));
            }

            for (int i = 1; i < X.Length; i++)
            {
                if (X[i] < X[i - 1])
                {
                    X = X.Skip(i).ToArray();
                    Y = Y.Skip(i).ToArray();
                    series.PointList.RemoveRange(0, i);
                    break;
                }
            }

            chart.DataCollection.Add(series);

            chart.Title.Text = "Plot";
            chart.YAxis.LabelFont = new Font("Miramonte", 7f, FontStyle.Regular);
            chart.XAxis.LabelFont = new Font("Miramonte", 7f, FontStyle.Regular);
            chart.YAxis.Title = "Plays";
            chart.XAxis.Title = "Date";

            if (X.Length > 0)
            {
                if (X.Length == 1)
                {
                    chart.XAxis.Max = X.Max() + 1;
                    chart.XAxis.Min = X.Min() - 1;
                    chart.YAxis.Max = Y.Max() + 1;
                    chart.YAxis.Min = Y.Min() - 1;
                }
                else
                {
                    chart.XAxis.Max = X.Max();
                    chart.XAxis.Min = X.Min();
                    chart.YAxis.Max = Y.Max();
                    chart.YAxis.Min = Y.Min();
                }
            }
            else
                chart.DataCollection.DataSeriesList[0].Name = s.Name;

            chart.XAxis.Tick = 1;

            float y = chart.YAxis.Max;

            if (y < 40)
                chart.YAxis.Tick = 2;
            else if (y > 40 && y < 100)
                chart.YAxis.Tick = 5;
            else
                chart.YAxis.Tick = 10;
            

            chart.Legend.IsVisible = true;
            chart.Legend.Location = Legend.Position.SouthEast;
        }

        private Color GetRandomColor()
        {
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            int number = random.Next(names.Length);
            KnownColor randomColorName = names[number];

            return Color.FromKnownColor(randomColorName);
        }

        private List<Color> CreateColorGradient(int count, Color gradient)
        {
            List<Color> color = new List<Color>(count);

            for (int i = (255 / count) - 1; i < 255; i += 255 / count)
                color.Add(Color.FromArgb(i, gradient.R, gradient.G, gradient.B));

            return color;
        }
    }
}
