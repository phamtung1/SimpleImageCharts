using SimpleImageCharts.BarChart;
using SimpleImageCharts.Core.Models;
using SimpleImageCharts.Enum;
using SimpleImageCharts.StackedBar100Chart;
using System.Drawing;

namespace WindowsFormsChart.Charts
{
    public static class StackedBar100ChartCreator
    {
        public static StackedBar100Chart CreateChart(Size size)
        {
            var chart = new StackedBar100Chart
            {
                Legend = new LegendModel
                {
                    Margin = new PointF(0, 40),
                    VerticalAlign = VerticalAlign.Bottom,
                    HorizontalAlign = HorizontalAlign.Center
                },
                SubTitle = new SubTitleModel { Text = "AAAAAAA" },
                Size = size,
                Categories = new[] { "Product A", "Product B", "Product C" },
                DataSet = new[]
                {
                    new DataSeries
                    {
                        Label = "LightBlue",
                        Color = Color.LightBlue,
                        Data = new[] { 25f, 13f, 3f },
                    },
                    new DataSeries
                    {
                        Label = "LightCoral",
                        Color = Color.LightCoral,
                        Data = new[] { 25f, 3f, 33f },
                    }
                    ,
                    new DataSeries
                    {
                        Label = "LightGreen",
                        Color = Color.LightGreen,
                       Data = new[] { 5f, 3f, 3f },
                    },
                    new DataSeries
                    {
                        Label = "Red",
                        Color = Color.Red,
                       Data = new[] { 25f, 13f, 3f },
                    }
                }
            };

            return chart;
        }
    }
}