using SimpleImageCharts.BarGauge;
using System.Drawing;

namespace WindowsFormsChart.Charts
{
    public static class BarGaugeChartCreator
    {
        public static BarGaugeChart CreateChart(Size size)
        {
            return new BarGaugeChart
            {
                Size = size
            };
        }
    }
}