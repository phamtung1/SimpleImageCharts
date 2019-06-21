using SimpleImageCharts.BarChart;
using SimpleImageCharts.ColumnChart;
using SimpleImageCharts.DoubleAxisBarChart;
using SimpleImageCharts.PieChart;
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

            var bitmap = chart.CreateImage();

            pictureBox1.Image = bitmap;
        }

        private void BtnDonutChart_Click(object sender, EventArgs e)
        {
            PieEntry[] entries = CreatePieEntries();

            var chart = new PieChart
            {
                Width = pictureBox1.Width,
                Height = pictureBox1.Height,
                Entries = entries,
                IsDonut = true
            };

            var bitmap = chart.CreateImage();

            pictureBox1.Image = bitmap;
        }

        private void BtnBarChart_Click(object sender, EventArgs e)
        {
            var chart = new BarChart
            {
                Width = pictureBox1.Width,
                Height = pictureBox1.Height,
                Categories = new[] { "A", "Product B", "Product C" },
                DataSets = new[]
                {
                    new BarSeries
                    {
                        Color = Color.Green,
                        Data = new[] { -5f, 10f, 15f },
                    },
                    new BarSeries
                    {
                        Color = Color.Red,
                        Data = new[] { 1f, -2f, 3f },
                    }
                    ,
                    new BarSeries
                    {
                        Color = Color.Blue,
                        Data = new[] { 5f, 20f, -13f },
                    }
                }
            };

            pictureBox1.Image = chart.CreateImage();
            pictureBox1.Image.Save(@"D:\GitHub\SimpleImageCharts\screenshots\BarChart.jpg");
        }

        private void BtnStackedBar_Click(object sender, EventArgs e)
        {
            var chart = new BarChart
            {
                Width = pictureBox1.Width,
                Height = pictureBox1.Height,
                IsStacked = true,
                Categories = new[] { "A", "Product B", "Product C", "A", "Product B", "Product C", "A", "Product B", "Product C" },
                DataSets = new[]
                {
                    new BarSeries
                    {
                        Color = Color.Green,
                        Data = new[] { -5f, -10f, -1f , -5f, -10f, -1f , -5f, -10f, -1f },
                    },
                    new BarSeries
                    {
                        Color = Color.Red,
                        Data = new[] { 10f, 20f, 5f, 10f, 20f, 5f, 10f, 20f, 5f },
                    }
                }
            };

            pictureBox1.Image = chart.CreateImage();
            pictureBox1.Image.Save(@"D:\GitHub\SimpleImageCharts\screenshots\StackedBarChart.jpg");
        }

        private void BtnDoubleAxisBar_Click(object sender, EventArgs e)
        {
            var chart = new DoubleAxisBarChart
            {
                Width = pictureBox1.Width,
                Height = pictureBox1.Height,
                Categories = new[] { "Product A", "Product B", "Product C", "Product D", "Product E", "Product F" },
                FirstDataSet = new DoubleAxisBarSeries
                {
                    Color = Color.Green,
                    Data = new[] { 5f, 10f, 5f, 1f, 12f, 7f },
                },
                SecondDataSet = new DoubleAxisBarSeries
                {
                    Color = Color.Red,
                    Data = new[] { 15f, 10f, 15f, 8f, 2f, 14f },
                }
            };

            pictureBox1.Image = chart.CreateImage();
            pictureBox1.Image.Save(@"D:\GitHub\SimpleImageCharts\screenshots\DoubleAxisBarChart.jpg");
        }

        private void BtnColumnChart_Click(object sender, EventArgs e)
        {
            var categories = new[] { "A", "Product B", "Product C", "Product D", "Product E" };
            var rand = new Random();
            var datasets = new ColumnSeries[4];
            for (int i = 0; i < datasets.Length; i++)
            {
                var data = new float[categories.Length];
                for (int j = 0; j < categories.Length; j++)
                {
                    data[j] = rand.Next(20) - 10;
                }

                var dataset = new ColumnSeries
                {
                    Color = Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256)),
                    Data = data
                };
                datasets[i] = dataset;
            }

            var chart = new ColumnChart
            {
                Width = pictureBox1.Width,
                Height = pictureBox1.Height,
                Categories = categories,
                DataSets = datasets
            };

            pictureBox1.Image = chart.CreateImage();
            pictureBox1.Image.Save(@"D:\GitHub\SimpleImageCharts\screenshots\ColumnChart.jpg");
        }
    }
}