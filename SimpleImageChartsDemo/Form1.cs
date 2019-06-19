using SimpleImageCharts.HorzBarChart;
using SimpleImageCharts.PieChart;
using System;
using System.Collections.Generic;
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

            pictureBox1.Image = chart.Paint();
        }
    }
}