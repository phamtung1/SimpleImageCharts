using SimpleImageCharts.DoubleAxisBarChart;
using System.Drawing;

namespace WindowsFormsChart.Charts
{
    public static class DoubleAxisBarChartCreator
    {
        public static DoubleAxisBarChart CreateChart(Size size)
        {
            var chart = new DoubleAxisBarChart
            {
                FormatBarValue = "{0}%",
                Size = size,
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
            return chart;
        }
    }
}