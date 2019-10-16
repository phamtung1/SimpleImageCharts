using SimpleImageCharts.Core;
using SimpleImageCharts.Core.Models;

namespace SimpleImageCharts.BarChart
{
    public interface IBarChart : IBaseChart
    {
        BarSettingModel BarSetting { get; set; }
        string[] Categories { get; set; }
        ChartGridModel ChartGridModel { get; set; }
        DataSeries[] DataSet { get; set; }
        string FormatAxisValue { get; set; }
        int StepSize { get; set; }
    }
}