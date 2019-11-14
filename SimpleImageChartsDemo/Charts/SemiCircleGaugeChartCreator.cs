using System.Drawing;
using System.Linq;
using SimpleImageCharts.SemiCircleGaugeChart;
using SimpleImageCharts.Core.Models;
using SimpleImageCharts.Enum;

namespace WindowsFormsChart.Charts
{
    public static class SemiCircleGaugeChartCreator
    {
        public static SemiCircleGaugeChart CreateChart(Size size)
        {
            var chart = new SemiCircleGaugeChart
            {
                LeftCaption = "Min Value",
                RightCaption = "Max Value",
                Legend = new LegendModel
                {
                    Margin = new PointF(40, 80),
                    VerticalAlign = VerticalAlign.Bottom,
                    HorizontalAlign = HorizontalAlign.Center
                },
                MaxValue = 8,
                Size = size,
                DataItems = new[]
                {
                    new DataItem { Color = Color.Brown, Value = 0.5f, Label = "Brown", BarSize = 30 },
                    new DataItem { Color = Color.LightCoral, Value = 2, Label = "LightCoral" },
                    new DataItem { Color = Color.LightGreen, Value = 4.5f, Label = "LightGreen" },
                    new DataItem { Color = Color.LightBlue, Value = 5, Label = "LightBlue" },
                    new DataItem { Color = Color.Yellow, Value = 6, Label = "Yellow" },
                    new DataItem { Color = Color.LightPink, Value = 7, Label = "LightPink" },
                    new DataItem { Color = Color.Aqua, Value = 8, Label = "Aqua" },
                }
            };

            return chart;
        }
    }
}