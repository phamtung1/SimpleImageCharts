using SimpleImageCharts.Core;
using SimpleImageCharts.Core.Models;

namespace SimpleImageCharts.BarGaugeChart
{
    public interface IBarGaugeChart : IBaseChart
    {
        int BarSize { get; set; }
        DataItem[] DataItems { get; set; }
        int GapSize { get; set; }
        int MaxValue { get; set; }
    }
}