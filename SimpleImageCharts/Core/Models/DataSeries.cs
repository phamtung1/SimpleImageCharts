using System.Drawing;

namespace SimpleImageCharts.Core.Models
{
    public class DataSeries
    {
        public string Label { get; set; }

        public Color Color { get; set; }

        public float[] Data { get; set; }
    }
}