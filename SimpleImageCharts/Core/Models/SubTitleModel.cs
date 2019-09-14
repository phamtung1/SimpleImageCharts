using System.Drawing;

namespace SimpleImageCharts.Core.Models
{
    public class SubTitleModel
    {
        public string Text { get; set; }

        public Color Color { get; set; } = Color.Gray;

        public string FontName { get; set; } = "Arial";

        public int FontSize { get; set; } = 12;
    }
}