using System.Drawing;

namespace SimpleImageCharts.Core.Models
{
    public class ChartGridModel
    {
        public Color LineColor { get; set; } = Color.Gray;

        public int LineWidth { get; set; } = 1;

        public bool RowLinesVisible { get; set; } = true;

        public bool ColumnLinesVisible { get; set; } = true;
    }
}