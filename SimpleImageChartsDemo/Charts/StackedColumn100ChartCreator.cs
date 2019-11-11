using SimpleImageCharts.Core.Models;
using SimpleImageCharts.Enum;
using SimpleImageCharts.StackedColumn100Chart;
using System.Drawing;

namespace WindowsFormsChart.Charts
{
    public static class StackedColumn100ChartCreator
    {
        public static StackedColumn100Chart CreateChart(Size size)
        {
            var chart = new StackedColumn100Chart
            {
                Legend = new LegendModel
                {
                    Margin = new PointF(0, 40),
                    VerticalAlign = VerticalAlign.Bottom,
                    HorizontalAlign = HorizontalAlign.Center
                },
                Padding = new Padding(80, 40, 20, 120),
                BarSetting = new BarSettingModel
                {
                    Size = 70,
                },
                Title = new TitleModel { Text = "Title here" },
                SubTitle = new TitleModel { Text = "Subtitle here" },
                Size = size,
                Categories = new[] { "Product A", "Product B", "Product C" },
                DataSet = new[]
               {
                    new DataSeries
                    {
                        TextColor = Color.Cyan,
                        Label = "LightBlue",
                        Color = Color.LightBlue,
                        Data = new[] { 1f, 3f, 3f },
                    },
                    new DataSeries
                    {
                        Label = "LightCoral",
                        Color = Color.LightCoral,
                        Data = new[] { 25f, 3f, 2f },
                    }
                    ,
                    new DataSeries
                    {
                        Label = "LightGreen",
                        Color = Color.LightGreen,
                        Data = new[] { 25f, 3f, 5f },
                    }
                    ,
                    new DataSeries
                    {
                        Label = "Red",
                        Color = Color.Red,
                        Data = new[] { 25f, 3f, 5f },
                    }
                }
            };

            return chart;
        }
    }
}