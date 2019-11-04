using SimpleImageCharts.BarChart;
using SimpleImageCharts.Core.Models;
using SimpleImageCharts.Enum;
using System.Drawing;

namespace WindowsFormsChart.Charts
{
    public static class StackedBarChartCreator
    {
        public static BarChart CreateChart(Size size)
        {
            var chart = new BarChart
            {
                Legend = new LegendModel
                {
                    Margin = new PointF(0, 50),
                    VerticalAlign = VerticalAlign.Bottom
                },
                ChartGridModel = new ChartGridModel
                {
                    LineColor = Color.LightGreen
                },
                BarSetting = new BarSettingModel
                {
                    IsStacked = true,
                    FormatValue = "{0:0;0}",
                },
                SubTitle = new TitleModel { Text = "Some random text" },
                Size = size,
                FormatAxisValue = "{0:0;0}", // force positive values
                Categories = new[] { "Product A", "Product B", "Product C", "Product A", "Product B", "Product C", "Product A", "Product B", "Product C" },
                DataSet = new[]
                {
                    new DataSeries
                    {
                        Label = "Yesterday",
                        Color = Color.LightBlue,
                        Data = new[] { -5f, -10f, -1f , -5f, -10f, -1f , -5f, -10f, -1f },
                    },
                    new DataSeries
                    {
                        Label = "Today",
                        Color = Color.LightCoral,
                        Data = new[] { 10f, 20f, 5f, 10f, 20f, 5f, 10f, 20f, 5f },
                    }
                }
            };

            return chart;
        }
    }
}