using SimpleImageCharts.Core;
using System.Drawing;

namespace SimpleImageCharts.RadarChart
{
    public interface IRadarChart : IImageChart
    {
        string[] Categories { get; set; }
        RadarChartSeries[] DataSets { get; set; }
        int MaxDataValue { get; set; }
        int StepSize { get; set; }
    }
}