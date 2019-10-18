using System.Drawing;
using SimpleImageCharts.BarGaugeChart;
using SimpleImageCharts.Core.Models;

namespace WindowsFormsChart.Charts
{
    public static class BarGaugeChartCreator
    {
        public static BarGaugeChart CreateChart(Size size)
        {
            var chart = new BarGaugeChart
            {
                MaxValue = 8,
                Size = size,
                DataItems = new[]
                {
                    new DataItem { Color = Color.LightCoral, Value = 2, Label = "LightCoral" },
                    new DataItem { Color = Color.LightGreen, Value = 4, Label = "LightGreen" },
                    new DataItem { Color = Color.LightBlue, Value = 5, Label = "LightBlue" },
                    new DataItem { Color = Color.Yellow, Value = 6, Label = "Yellow" },
                    new DataItem { Color = Color.LightPink, Value = 7, Label = "LightPink" },
                }
            };

            return chart;
        }
    }
}