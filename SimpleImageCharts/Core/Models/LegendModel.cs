using SimpleImageCharts.Enum;
using System.Collections.Generic;
using System.Drawing;

namespace SimpleImageCharts.Core.Models
{
    public class LegendModel
    {
        public IEnumerable<LegendItemModel> Items { get; set; }

        public string FontName { get; set; } = "Arial";

        public int FontSize { get; set; } = 12;

        public Color TextColor { get; set; } = Color.Gray;

        public PointF Margin { get; set; } = PointF.Empty;

        public HorizontalAlign HorizontalAlign { get; set; } = HorizontalAlign.Center;

        public VerticalAlign VerticalAlign { get; set; } = VerticalAlign.Bottom;
    }
}