using SimpleImageCharts.Core;
using SimpleImageCharts.Core.Models;

namespace SimpleImageCharts.SemiCircleGaugeChart
{
    public interface ISemiCircleGaugeChart : IBaseChart
    {
        int BarSize { get; set; }
        DataItem[] DataItems { get; set; }
        int GapSize { get; set; }
        int MaxValue { get; set; }
    }
}