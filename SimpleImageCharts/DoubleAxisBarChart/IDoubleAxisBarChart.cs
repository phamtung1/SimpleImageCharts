using GdiSharp.Models;
using SimpleImageCharts.Core;

namespace SimpleImageCharts.DoubleAxisBarChart
{
    public interface IDoubleAxisBarChart : IBaseChart
    {
        SlimFont BarValueFont { get; set; }
        string[] Categories { get; set; }
        DoubleAxisBarSeries FirstDataSet { get; set; }
        string FormatBarValue { get; set; }
        DoubleAxisBarSeries SecondDataSet { get; set; }
        int StepSize { get; set; }
    }
}