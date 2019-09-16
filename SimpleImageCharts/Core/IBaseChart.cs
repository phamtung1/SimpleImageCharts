using System.Drawing;
using GdiSharp.Models;
using SimpleImageCharts.Core.Models;

namespace SimpleImageCharts.Core
{
    public interface IBaseChart
    {
        SlimFont Font { get; set; }
        LegendModel Legend { get; set; }
        Padding Padding { get; set; }
        Size Size { get; set; }
        SubTitleModel SubTitle { get; set; }

        IImageFile CreateImage();
    }
}