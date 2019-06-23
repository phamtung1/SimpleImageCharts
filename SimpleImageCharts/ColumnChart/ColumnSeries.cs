using System.Drawing;

namespace SimpleImageCharts.ColumnChart
{
    public class ColumnSeries
    {
        public Color Color { get; set; }

        /// <summary>
        ///  set this propery only if each column has different color.
        /// </summary>
        public Color[] Colors { get; set; }

        public float[] Data { get; set; }
    }
}