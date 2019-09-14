using System.Drawing;
using SimpleImageCharts.Core;
using SimpleImageCharts.Core.Models;

namespace SimpleImageCharts.BarChart
{
    public interface IBarChart : IImageChart
    {
        BarSettingModel BarSettingModel { get; set; }
        string[] Categories { get; set; }
        BarSeries[] DataSet { get; set; }
        Font Font { get; set; }
        string FormatAxisValue { get; set; }
        int Height { get; set; }
        int MarginBottom { get; set; }
        int StepSize { get; set; }
        int Width { get; set; }
    }
}