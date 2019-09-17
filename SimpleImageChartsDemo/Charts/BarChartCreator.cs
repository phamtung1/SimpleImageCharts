using SimpleImageCharts.BarChart;
using SimpleImageCharts.Core.Models;
using SimpleImageCharts.Enum;
using System.Drawing;

namespace WindowsFormsChart.Charts
{
    public static class BarChartCreator
    {
        public static BarChart CreateChart(Size size)
        {
            var chart = new BarChart
            {
                Legend = new LegendModel
                {
                    Margin = new PointF(0, 40),
                    VerticalAlign = VerticalAlign.Bottom,
                    HorizontalAlign = HorizontalAlign.Center
                },
                ChartGrid = new ChartGridModel
                {
                    LineColor = Color.LightGreen
                },
                SubTitle = new SubTitleModel { Text = "AAAAAAA" },
                Size = size,
                Categories = new[] { "Product A", "Product B", "Product C" },
                DataSet = new[]
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

            return chart;
        }
    }
}