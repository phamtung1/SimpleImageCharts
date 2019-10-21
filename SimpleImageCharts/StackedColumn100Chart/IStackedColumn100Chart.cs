using SimpleImageCharts.Core;
using SimpleImageCharts.Core.Models;

namespace SimpleImageCharts.StackedColumn100Chart
{
    public interface IStackedColumn100Chart : IBaseChart
    {
        BarSettingModel BarSetting { get; set; }
        string[] Categories { get; set; }
        ChartGridModel ChartGridModel { get; set; }
        DataSeries[] DataSet { get; set; }
        string FormatAxisValue { get; set; }
        int StepSize { get; set; }
    }
}