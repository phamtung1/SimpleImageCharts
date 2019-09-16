using System.Drawing;
using SimpleImageCharts.Core;
using SimpleImageCharts.Core.Models;

namespace SimpleImageCharts.BarChart
{
    public interface IBarChart : IImageChart
    {
        BarSettingModel BarSetting { get; set; }
        string[] Categories { get; set; }
        BarSeries[] DataSet { get; set; }
        string FormatAxisValue { get; set; }
        int StepSize { get; set; }
    }
}