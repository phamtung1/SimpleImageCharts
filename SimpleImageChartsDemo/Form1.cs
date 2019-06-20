using SimpleImageCharts.HorzBarChart;
using SimpleImageCharts.HorzBarDoubleAxisChart;
using SimpleImageCharts.PieChart;
using SimpleImageCharts.VertBarChart;
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

        private void BtnHorzBarChart_Click(object sender, EventArgs e)
        {
            var chart = new HorzBarChart
            {
                Width = pictureBox1.Width,
                Height = pictureBox1.Height,
                Categories = new[] { "A", "Product B", "Product C" },
                DataSets = new[]
                {
                    new HorzBarSeries
                    {
                        Color = Color.Green,
                        Data = new[] { -5f, 10f, 15f },
                    },
                    new HorzBarSeries
                    {
                        Color = Color.Red,
                        Data = new[] { 1f, -2f, 3f },
                    }
                    ,
                    new HorzBarSeries
                    {
                        Color = Color.Blue,
                        Data = new[] { 5f, 20f, -13f },
                    }
                }
            };

            pictureBox1.Image = chart.CreateImage();
        }

        private void BtnVertBar_Click(object sender, EventArgs e)
        {
            var categories = new[] { "A", "Product B", "Product C", "Product D", "Product E" };
            var rand = new Random();
            var datasets = new VertBarSeries[4];
            for (int i = 0; i < datasets.Length; i++)
            {
                var data = new float[categories.Length];
                for (int j = 0; j < categories.Length; j++)
                {
                    data[j] = rand.Next(20) - 10;
                }

                var dataset = new VertBarSeries
                {
                    Color = Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256)),
                    Data = data
                };
                datasets[i] = dataset;
            }

            var chart = new VertBarChart
            {
                Width = pictureBox1.Width,
                Height = pictureBox1.Height,
                Categories = categories,
                DataSets = datasets
            };

            pictureBox1.Image = chart.CreateImage();
        }

        private void BtnHorzBarDoubleAxis_Click(object sender, EventArgs e)
        {
            var chart = new HorzBarDoubleAxisChart
            {
                Width = pictureBox1.Width,
                Height = pictureBox1.Height,
                Categories = new[] { "Product A", "Product B", "Product C", "Product D", "Product E", "Product F" },
                FirstDataSet = new HorzBarDoubleAxisSeries { 
                        Color = Color.Green,
                        Data = new[] { 5f, 10f, 5f, 1f, 12f, 7f },
                    },
                SecondDataSet = new HorzBarDoubleAxisSeries
                {
                    Color = Color.Red,
                    Data = new[] { 15f, 10f, 15f, 8f, 2f, 14f },
                }
            };

            pictureBox1.Image = chart.CreateImage();
            pictureBox1.Image.Save("D:\\HorzBarDoubleAxis.jpg"); ;
        }
    }
}