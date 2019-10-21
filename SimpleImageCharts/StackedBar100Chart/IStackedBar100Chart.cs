using SimpleImageCharts.Core;
using SimpleImageCharts.Core.Models;

namespace SimpleImageCharts.StackedBar100Chart
{
    public interface IStackedBar100Chart : IBaseChart
    {
        BarSettingModel BarSetting { get; set; }
        string[] Categories { get; set; }
        ChartGridModel ChartGridModel { get; set; }
        DataSeries[] DataSet { get; set; }
        string FormatAxisValue { get; set; }
        int StepSize { get; set; }
    }
}