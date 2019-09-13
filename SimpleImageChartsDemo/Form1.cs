using SimpleImageCharts.BarChart;
using SimpleImageCharts.ColumnChart;
using SimpleImageCharts.Core.Models;
using SimpleImageCharts.DoubleAxisBarChart;
using SimpleImageCharts.PieChart;
using SimpleImageCharts.RadarChart;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsChart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static PieEntry[] CreatePieEntries()
        {
            var rand = new Random();
            var entries = new PieEntry[10];
            for (int i = 0; i < entries.Length; i++)
            {
                entries[i] = new PieEntry
                {
                    Value = (float)rand.Next(10, 40) / 10,
                    Color = Color.FromArgb(rand.Next(0, 200), rand.Next(0, 200), rand.Next(0, 200)),
                    Label = "Data " + i
                };
            }

            return entries;
        }

        private void btnPieChart_Click(object sender, EventArgs e)
        {
            PieEntry[] entries = CreatePieEntries();

            var chart = new PieChart
            {
                Width = pictureBox1.Width,
                Height = pictureBox1.Height,
                Entries = entries
            };

            var image = chart.CreateImage();

            pictureBox1.Image = image.GetImage();
        }

        private void BtnDonutChart_Click(object sender, EventArgs e)
        {
            PieEntry[] entries = CreatePieEntries();

            var chart = new PieChart
            {
                Width = pictureBox1.Width,
                Height = pictureBox1.Height,
                Entries = entries,
                IsDonut = true,
                PieAligment = SimpleImageCharts.Enum.PositionAlign.Right
            };

            var image = chart.CreateImage();

            pictureBox1.Image = image.GetImage();
        }

        private void BtnBarChart_Click(object sender, EventArgs e)
        {
            var chart = new BarChart
            {
                Legend = new Legend
                {
                    MarginTop = -40,
                    HorizontalAlign = SimpleImageCharts.Enum.HorizontalAlign.Right
                },
                ChartGrid = new ChartGrid
                {
                    LineColor = Color.LightGreen
                },
                SubTitle = new SubTitle { Text = "AAAAAAA" },
                Width = pictureBox1.Width,
                Height = pictureBox1.Height,
                Categories = new[] { "Product A", "Product B", "Product C" },
                DataSets = new[]
                {
                    new BarSeries
                    {
                        Label = "LightBlue",
                        Color = Color.LightBlue,
                        Data = new[] { -5f, 10f, 15f },
                    },
                    new BarSeries
                    {
                        Label = "LightCoral",
                        Color = Color.LightCoral,
                        Data = new[] { 1f, -2f, 3f },
                    }
                    ,
                    new BarSeries
                    {
                        Label = "LightGreen",
                        Color = Color.LightGreen,
                        Data = new[] { 5f, 20f, -13f },
                    }
                }
            };

            var image = chart.CreateImage();
            pictureBox1.Image = image.GetImage();
            image.Save(@"D:\GitHub\SimpleImageCharts\screenshots\BarChart.jpg");
        }

        private void BtnStackedBar_Click(object sender, EventArgs e)
        {
            var chart = new BarChart
            {
                Legend = new Legend
                {
                    MarginTop = -50
                },
                ChartGrid = new ChartGrid
                {
                    LineColor = Color.LightGreen
                },
                SubTitle = new SubTitle { Text = "aaaaaaaaaa ccccccccdddddddddddddddddcccc" },
                Width = pictureBox1.Width,
                Height = pictureBox1.Height,
                MarginBottom = 100,
                IsStacked = true,
                FormatAxisValue = "{0:0;0}", // force positive values
                FormatBarValue = "{0:0;0}",
                Categories = new[] { "Product A", "Product B", "Product C", "Product A", "Product B", "Product C", "Product A", "Product B", "Product C" },
                DataSets = new[]
                {
                    new BarSeries
                    {
                        Label = "Yesterday",
                        Color = Color.LightBlue,
                        Data = new[] { -5f, -10f, -1f , -5f, -10f, -1f , -5f, -10f, -1f },
                    },
                    new BarSeries
                    {
                        Label = "Today",
                        Color = Color.LightCoral,
                        Data = new[] { 10f, 20f, 5f, 10f, 20f, 5f, 10f, 20f, 5f },
                    }
                }
            };

            pictureBox1.Image = chart.CreateImage().GetImage();
            pictureBox1.Image.Save(@"D:\GitHub\SimpleImageCharts\screenshots\StackedBarChart.jpg");
        }

        private void BtnDoubleAxisBar_Click(object sender, EventArgs e)
        {
            var chart = new DoubleAxisBarChart
            {
                FormatBarValue = "{0}%",
                Width = pictureBox1.Width,
                Height = pictureBox1.Height,
                Categories = new[] { "Product A", "Product B", "Product C", "Product D", "Product E", "Product F" },
                FirstDataSet = new DoubleAxisBarSeries
                {
                    Label = "Income",
                    Color = Color.LightBlue,
                    Data = new[] { 5f, 10f, 5f, 1f, 12f, 7f },
                },
                SecondDataSet = new DoubleAxisBarSeries
                {
                    Label = "Outcome",
                    Color = Color.LightCoral,
                    Data = new[] { 15f, 10f, 15f, 8f, 2f, 14f },
                }
            };

            pictureBox1.Image = chart.CreateImage().GetImage();
            pictureBox1.Image.Save(@"D:\GitHub\SimpleImageCharts\screenshots\DoubleAxisBarChart.jpg");
        }

        private void BtnColumnChart_Click(object sender, EventArgs e)
        {
            var categories = new[] { "Product A", "Product B", "Product C", "Product D", "Product E" };
            var rand = new Random();
            var datasets = new ColumnSeries[3];
            for (int i = 0; i < datasets.Length; i++)
            {
                var data = new float[categories.Length];
                for (int j = 0; j < categories.Length; j++)
                {
                    data[j] = rand.Next(30) - 10;
                }

                var dataset = new ColumnSeries
                {
                    Color = Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256)),
                    Data = data
                };
                datasets[i] = dataset;
            }

            datasets[0].OffsetX = 10;
            var chart = new ColumnChart
            {
                ColumnSize = 30,
                Width = pictureBox1.Width,
                Height = pictureBox1.Height,
                Categories = categories,
                DataSets = datasets
            };

            pictureBox1.Image = chart.CreateImage().GetImage();
            pictureBox1.Image.Save(@"D:\GitHub\SimpleImageCharts\screenshots\ColumnChart.jpg");
        }

        private void BtnRadarChart_Click(object sender, EventArgs e)
        {
            var random = new Random();
            var categories = new[] { "Eating", "Sleeping", "Doing Nothing", "Playing", "Relaxing", "Watching" };
            var chart = new RadarChart
            {
                MaxDataValue = 100,
                StepSize = 10,
                Width = pictureBox1.Width,
                Height = pictureBox1.Height,
                Categories = categories,
                DataSets = new[]
                {
                    new RadarChartSeries
                    {
                        Label = "My Life",
                        Color = Color.LightCoral,
                        Data = GenerateRandomArray(random, categories.Length, 10, 60),
                    },
                    new RadarChartSeries
                    {
                        Label = "My Wife Life",
                        Color = Color.LightBlue,
                        Data = GenerateRandomArray(random, categories.Length, 10, 70),
                    }
                }
            };
            pictureBox1.Image = chart.CreateImage().GetImage();
            pictureBox1.Image.Save(@"D:\GitHub\SimpleImageCharts\screenshots\RadarChart.jpg");
        }

        private int[] GenerateRandomArray(Random random, int length, int min, int max)
        {
            var result = new int[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = random.Next(min, max);
            }

            return result;
        }
    }
}