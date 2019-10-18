using System;
using System.Windows.Forms;
using WindowsFormsChart.Charts;

namespace WindowsFormsChart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPieChart_Click(object sender, EventArgs e)
        {
            var chart = PieChartCreator.CreatePie(pictureBox1.Size);
            var image = chart.CreateImage();
            pictureBox1.Image = image.GetImage();
        }

        private void BtnDonutChart_Click(object sender, EventArgs e)
        {
            var chart = PieChartCreator.CreateDonut(pictureBox1.Size);
            var image = chart.CreateImage();

            pictureBox1.Image = image.GetImage();
        }

        private void BtnBarChart_Click(object sender, EventArgs e)
        {
            var chart = BarChartCreator.CreateChart(pictureBox1.Size);

            var image = chart.CreateImage();
            pictureBox1.Image = image.GetImage();
        //    image.Save(@"D:\GitHub\SimpleImageCharts\screenshots\BarChart.jpg");
        }

        private void BtnStackedBar_Click(object sender, EventArgs e)
        {
            var chart = StackedBarChartCreator.CreateChart(pictureBox1.Size);

            pictureBox1.Image = chart.CreateImage().GetImage();
        //    pictureBox1.Image.Save(@"D:\GitHub\SimpleImageCharts\screenshots\StackedBarChart.jpg");
        }

        private void BtnDoubleAxisBar_Click(object sender, EventArgs e)
        {
            var chart = DoubleAxisBarChartCreator.CreateChart(pictureBox1.Size);

            pictureBox1.Image = chart.CreateImage().GetImage();
        //    pictureBox1.Image.Save(@"D:\GitHub\SimpleImageCharts\screenshots\DoubleAxisBarChart.jpg");
        }

        private void BtnColumnChart_Click(object sender, EventArgs e)
        {
            var chart = ColumnChartCreator.CreateChart(pictureBox1.Size);
            pictureBox1.Image = chart.CreateImage().GetImage();
        //    pictureBox1.Image.Save(@"D:\GitHub\SimpleImageCharts\screenshots\ColumnChart.jpg");
        }

        private void BtnRadarChart_Click(object sender, EventArgs e)
        {
            var chart = RadarChartCreator.CreateChart(pictureBox1.Size);
            pictureBox1.Image = chart.CreateImage().GetImage();
        //    pictureBox1.Image.Save(@"D:\GitHub\SimpleImageCharts\screenshots\RadarChart.jpg");
        }

        private void BtnSingleRangeBarChart_Click(object sender, EventArgs e)
        {
            var chart = SingleRangeBarChartCreator.CreateChart(pictureBox1.Size);

            pictureBox1.Image = chart.CreateImage().GetImage();
        //    pictureBox1.Image.Save(@"D:\GitHub\SimpleImageCharts\screenshots\SingleRangeBarChart.jpg");
        }

        private void btnStackedBar100Percent_Click(object sender, EventArgs e)
        {
            var chart = StackedBar100ChartCreator.CreateChart(pictureBox1.Size);

            pictureBox1.Image = chart.CreateImage().GetImage();
         //   pictureBox1.Image.Save(@"D:\GitHub\SimpleImageCharts\screenshots\StackedBar100Chart.jpg");
        }

        private void btnStackedColumn100Percent_Click(object sender, EventArgs e)
        {
            var chart = StackedColumn100ChartCreator.CreateChart(pictureBox1.Size);

            pictureBox1.Image = chart.CreateImage().GetImage();
        //    pictureBox1.Image.Save(@"D:\GitHub\SimpleImageCharts\screenshots\StackedColumn100Chart.jpg");
        }

        private void btnBarGaugeChart_Click(object sender, EventArgs e)
        {
            var chart = BarGaugeChartCreator.CreateChart(pictureBox1.Size);

            pictureBox1.Image = chart.CreateImage().GetImage();
            pictureBox1.Image.Save(@"D:\GitHub\SimpleImageCharts\screenshots\BarGaugeChart.jpg");
        }
    }
}