using SimpleImageCharts.Core;
using System.Drawing;

namespace SimpleImageCharts.DoubleAxisBarChart
{
    public interface IDoubleAxisBarChart : IImageChart
    {
        string[] Categories { get; set; }
        DoubleAxisBarSeries FirstDataSet { get; set; }
        string FormatBarValue { get; set; }
        DoubleAxisBarSeries SecondDataSet { get; set; }
        int StepSize { get; set; }
    }
}