using SimpleImageCharts.Core;
using System.Drawing;

namespace SimpleImageCharts.ColumnChart
{
    public interface IColumnChart : IImageChart
    {
        string[] Categories { get; set; }
        int ColumnSize { get; set; }
        ColumnSeries[] DataSets { get; set; }
        string FormatColumnValue { get; set; }
        int StepSize { get; set; }
    }
}