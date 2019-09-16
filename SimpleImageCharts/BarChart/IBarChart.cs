using SimpleImageCharts.Core;
using SimpleImageCharts.Core.Models;

namespace SimpleImageCharts.BarChart
{
    public interface IBarChart : IBaseChart
    {
        BarSettingModel BarSetting { get; set; }
        string[] Categories { get; set; }
        ChartGridModel ChartGrid { get; set; }
        BarSeries[] DataSet { get; set; }
        string FormatAxisValue { get; set; }
        int StepSize { get; set; }
    }
}