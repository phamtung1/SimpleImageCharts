using GdiSharp.Models;
using SimpleImageCharts.Core;

namespace SimpleImageCharts.ColumnChart
{
    public interface IColumnChart : IBaseChart
    {
        string[] Categories { get; set; }
        int ColumnSize { get; set; }
        SlimFont ColumnValueFont { get; set; }
        ColumnSeries[] DataSets { get; set; }
        string FormatColumnValue { get; set; }
        int StepSize { get; set; }
    }
}