using SimpleImageCharts.Core;
using System.Drawing;

namespace SimpleImageCharts.BarChart
{
    public interface IBarChart : IImageChart
    {
        int BarSize { get; set; }
        Font BarValueFont { get; set; }
        string[] Categories { get; set; }
        string ChartCaption { get; set; }
        BarSeries[] DataSets { get; set; }
        Font Font { get; set; }
        string FormatAxisValue { get; set; }
        string FormatBarValue { get; set; }
        int Height { get; set; }
        bool IsStacked { get; set; }
        int MarginBottom { get; set; }
        int StepSize { get; set; }
        int Width { get; set; }
    }
}