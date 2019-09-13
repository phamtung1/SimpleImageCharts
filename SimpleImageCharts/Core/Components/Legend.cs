using System.Collections.Generic;
using System.Drawing;

namespace SimpleImageCharts.Core.Components
{
    public class Legend
    {
        public IEnumerable<LegendItem> Items { get; set; }

        public string FontName { get; set; } = "Arial";

        public int FontSize { get; set; } = 12;

        public Color TextColor { get; set; } = Color.Gray;

        public int MarginLeft { get; set; } = 0;

        public int MarginTop { get; set; } = 0;
    }
}