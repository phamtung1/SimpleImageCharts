using System;
using System.Drawing;
using SimpleImageCharts.Core;
using SimpleImageCharts.Enum;

namespace SimpleImageCharts.PieChart
{
    public interface IPieChart : IBaseChart
    {
        Action<Graphics> AfterDraw { get; set; }
        Color BorderColor { get; set; }
        byte BorderWidth { get; set; }
        PieEntry[] Entries { get; set; }
        HorizontalAlign PieAlign { get; set; }
        bool IsDonut { get; set; }
        string LabelFormat { get; set; }
        Color TextColor { get; set; }
    }
}