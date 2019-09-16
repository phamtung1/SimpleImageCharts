using GdiSharp.Models;
using SimpleImageCharts.Core;

namespace SimpleImageCharts.RadarChart
{
    public interface IRadarChart : IBaseChart
    {
        string[] Categories { get; set; }
        RadarChartSeries[] DataSets { get; set; }
        int MaxDataValue { get; set; }
        int StepSize { get; set; }
        SlimFont ValueFont { get; set; }
    }
}