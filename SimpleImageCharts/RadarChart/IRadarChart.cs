using SimpleImageCharts.Core;
using System.Drawing;

namespace SimpleImageCharts.RadarChart
{
    public interface IRadarChart : IImageChart
    {
        string[] Categories { get; set; }
        RadarChartSeries[] DataSets { get; set; }
        Font Font { get; set; }
        int Height { get; set; }
        int MaxDataValue { get; set; }
        int StepSize { get; set; }
        Font ValueFont { get; set; }
        int Width { get; set; }
    }
}