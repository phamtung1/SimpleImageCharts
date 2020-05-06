using GdiSharp.Models;
using SimpleImageCharts.Core;

namespace SimpleImageCharts.ColumnChart
{
    public interface IColumnChart : IBaseChart
    {
        float CategoryWidth { get; }
        string[] Categories { get; set; }
        int ColumnSize { get; set; }
        SlimFont ColumnValueFont { get; set; }
        ColumnSeries[] DataSets { get; set; }
        string FormatColumnValue { get; set; }
        int StepSize { get; set; }
        float CategoryLabelXOffset { get; set; }
        float CategoryLabelYOffset { get; set; }
        bool ColumnValuesVisible { get; set; }
        bool IsOneHundredPercentChart { get; set; }
        string YAxisMinText { get; set; }
        string YAxisMaxText { get; set; }
    }
}