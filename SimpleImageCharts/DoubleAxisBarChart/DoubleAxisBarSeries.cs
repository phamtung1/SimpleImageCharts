using System.Drawing;

namespace SimpleImageCharts.DoubleAxisBarChart
{
    public class DoubleAxisBarSeries
    {
        public Color Color { get; set; }

        /// <summary>
        ///  set this propery only if each column has different color.
        /// </summary>
        public Color[] Colors { get; set; }

        public float[] Data { get; set; }

        public string Label { get; set; }

        public Color LabelColor { get; set; } = Color.Gray;
    }
}