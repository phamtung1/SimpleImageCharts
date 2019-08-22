using SimpleImageCharts.Core;
using System.Drawing;

namespace SimpleImageCharts.DoubleAxisBarChart
{
    public interface IDoubleAxisBarChart : IImageChart
    {
        Font BarValueFont { get; set; }
        string[] Categories { get; set; }
        DoubleAxisBarSeries FirstDataSet { get; set; }
        Font Font { get; set; }
        string FormatBarValue { get; set; }
        int Height { get; set; }
        int MarginBottom { get; set; }
        int MarginLeft { get; set; }
        int MarginRight { get; set; }
        int MarginTop { get; set; }
        DoubleAxisBarSeries SecondDataSet { get; set; }
        int StepSize { get; set; }
        int Width { get; set; }
    }
}