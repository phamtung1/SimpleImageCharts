using System;
using System.Windows.Forms;
using SimpleImageCharts.Core;
using WindowsFormsChart.Charts;

namespace WindowsFormsChart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SetImageToPictureBox(BaseChart chart, string saveFileName)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }

            pictureBox1.Image = chart.CreateImage().GetImage();

            if (!string.IsNullOrEmpty(saveFileName))
            {
                //pictureBox1.Image.Save(@"D:\GitHub\SimpleImageCharts\screenshots\" + saveFileName);
            }
        }

        private void btnPieChart_Click(object sender, EventArgs e)
        {
            var chart = PieChartCreator.CreatePie(pictureBox1.Size);
            SetImageToPictureBox(chart, "pie.jpg");
        }

        private void BtnDonutChart_Click(object sender, EventArgs e)
        {
            var chart = PieChartCreator.CreateDonut(pictureBox1.Size);
            SetImageToPictureBox(chart, "donut.jpg");
        }

        private void BtnBarChart_Click(object sender, EventArgs e)
        {
            var chart = BarChartCreator.CreateChart(pictureBox1.Size);
            SetImageToPictureBox(chart, "BarChart.jpg");
        }

        private void BtnStackedBar_Click(object sender, EventArgs e)
        {
            var chart = StackedBarChartCreator.CreateChart(pictureBox1.Size);
            SetImageToPictureBox(chart, "StackedBarChart.jpg");
        }

        private void BtnDoubleAxisBar_Click(object sender, EventArgs e)
        {
            var chart = DoubleAxisBarChartCreator.CreateChart(pictureBox1.Size);
            SetImageToPictureBox(chart, "DoubleAxisBarChart.jpg");
        }

        private void BtnColumnChart_Click(object sender, EventArgs e)
        {
            var chart = ColumnChartCreator.CreateChart(pictureBox1.Size);
            SetImageToPictureBox(chart, "ColumnChart.jpg");
        }

        private void BtnRadarChart_Click(object sender, EventArgs e)
        {
            var chart = RadarChartCreator.CreateChart(pictureBox1.Size);
            SetImageToPictureBox(chart, "RadarChart.jpg");
        }

        private void BtnSingleRangeBarChart_Click(object sender, EventArgs e)
        {
            var chart = SingleRangeBarChartCreator.CreateChart(pictureBox1.Size);
            SetImageToPictureBox(chart, "SingleRangeBarChart.jpg");
        }

        private void btnStackedBar100Percent_Click(object sender, EventArgs e)
        {
            var chart = StackedBar100ChartCreator.CreateChart(pictureBox1.Size);
            SetImageToPictureBox(chart, "StackedBar100Chart.jpg");
        }

        private void btnStackedColumn100Percent_Click(object sender, EventArgs e)
        {
            var chart = StackedColumn100ChartCreator.CreateChart(pictureBox1.Size);
            SetImageToPictureBox(chart, "StackedColumn100Chart.jpg");
        }

        private void btnBarGaugeChart_Click(object sender, EventArgs e)
        {
            var chart = BarGaugeChartCreator.CreateChart(pictureBox1.Size);
            SetImageToPictureBox(chart, "BarGaugeChart.jpg");
        }

        private void btnTableChart_Click(object sender, EventArgs e)
        {
            var chart = TableChartCreator.CreateChart(pictureBox1.Size);
            SetImageToPictureBox(chart, "TableChart.jpg");
        }
    }
}