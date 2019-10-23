using System.Collections.Generic;
using System.Drawing;
using GdiSharp.Components.DataGrid;
using SimpleImageCharts.Core;

namespace SimpleImageCharts.TableChart
{
    public interface ITableChart : IBaseChart
    {
        int Columns { get; set; }
        Color LineColor { get; set; }
        int LineWidth { get; set; }
        IEnumerable<DataGridMergedCell> MergedCells { get; set; }
        int Rows { get; set; }
        string[][] Texts { get; set; }
    }
}