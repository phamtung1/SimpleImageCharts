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
                    Color = Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256)),
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
    }
}