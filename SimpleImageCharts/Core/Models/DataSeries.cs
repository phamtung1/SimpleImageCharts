using System.Drawing;

namespace SimpleImageCharts.Core.Models
{
    public class DataSeries
    {
        public string Label { get; set; }

        public Color Color { get; set; }

        public Color TextColor { get; set; } = Color.Black;

        public float[] Data { get; set; }
    }
}