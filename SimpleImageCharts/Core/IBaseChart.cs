using GdiSharp.Models;
using SimpleImageCharts.Core.Models;
using System;
using System.Drawing;

namespace SimpleImageCharts.Core
{
    public interface IBaseChart
    {
        SlimFont Font { get; set; }
        LegendModel Legend { get; set; }
        Padding Padding { get; set; }
        Size Size { get; set; }
        TitleModel Title { get; set; }
        TitleModel SubTitle { get; set; }

        Action<Graphics> AfterDraw { get; set; }

        IImageFile CreateImage();
    }
}