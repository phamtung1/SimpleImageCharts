using System.Drawing;

namespace SimpleImageCharts.Core.Models
{
    public class BarSettingModel
    {
        // use "{0:0;0}" for forcing positive value
        public string FormatValue { get; set; } = "{0}";

        public int Size { get; set; } = 30;

        public Font ValueFont { get; set; } = new Font("Arial", 12, FontStyle.Bold);

        public bool IsStacked { get; set; } = false;
    }
}