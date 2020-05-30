using SimpleImageCharts.Core;
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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Form1_Resize(null, null);
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
                pictureBox1.Image.Save(@"D:\GitHub\SimpleImageCharts\screenshots\" + saveFileName);
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

        private void btnColumnChartSingleDataset_Click(object sender, EventArgs e)
        {
            var chart = ColumnChartSingleDatasetCreator.CreateChart(pictureBox1.Size);
            SetImageToPictureBox(chart, "ColumnChartSingleDataset.jpg");
        }

        private void btnColumnChartMultiDataset_Click(object sender, EventArgs e)
        {
            var chart = ColumnChartMultiDatasetCreator.CreateChart(pictureBox1.Size);
            SetImageToPictureBox(chart, "ColumnChartMultiDataset.jpg");
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

        private void btnSemiCircleGaugeChart_Click(object sender, EventArgs e)
        {
            var chart = SemiCircleGaugeChartCreator.CreateChart(pictureBox1.Size);
            SetImageToPictureBox(chart, "SemiCircleGaugeChart.jpg");
        }

        private void btnTableChart_Click(object sender, EventArgs e)
        {
            var chart = TableChartCreator.CreateChart(pictureBox1.Size);
            SetImageToPictureBox(chart, "TableChart.jpg");
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            lblSize.Text = pictureBox1.Width + " x " + pictureBox1.Height;
        }
    }
}