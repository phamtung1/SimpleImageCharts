using SimpleImageCharts.Core;
using System.Drawing;

namespace SimpleImageCharts.ColumnChart
{
    public interface IColumnChart : IImageChart
    {
        string[] Categories { get; set; }
        int ColumnSize { get; set; }
        Font ColumnValueFont { get; set; }
        ColumnSeries[] DataSets { get; set; }
        Font Font { get; set; }
        string FormatColumnValue { get; set; }
        int Height { get; set; }
        int MarginBottom { get; set; }
        int MarginLeft { get; set; }
        int MarginRight { get; set; }
        int MarginTop { get; set; }
        int StepSize { get; set; }
        int Width { get; set; }
    }
}