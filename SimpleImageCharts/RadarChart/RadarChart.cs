using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using SimpleImageCharts.Helpers;

namespace SimpleImageCharts.RadarChart
{
    public class RadarChart
    {
        private const int MarginLeft = 30;

        private const int MarginRight = 30;

        private const int MarginTop = 30;

        private const int MarginBottom = 30;

        public int Width { get; set; } = 600;

        public int Height { get; set; } = 300;

        public int NumberOfSides { get; set; } = 3;

        public Bitmap CreateImage()
        {
            if (NumberOfSides < 3)
            {
                throw new ArgumentException("Invalid Number of sides");
            }
            
            var bitmap = new Bitmap(Width, Height);
            using (var graphic = Graphics.FromImage(bitmap))
            {
                graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                var radius = Math.Min(Width - MarginLeft - MarginRight, Height - MarginTop - MarginBottom) / 2;
                var verticies = CalculateVertices(NumberOfSides, radius, -90, new PointF(MarginLeft + radius, MarginTop + radius));
                graphic.DrawPolygon(Pens.Black, verticies);
            }

            return bitmap;
        }

        private PointF[] CalculateVertices(int sides, int radius, int startAngle, PointF center)
        {
            var points = new List<PointF>();
            var step = 360.0f / sides;

            float angle = startAngle;
            for (float i = startAngle; i < startAngle + 360.0; i += step)
            {
                points.Add(MathHelper.DegreeToPoint(angle, radius, center));
                angle += step;
            }

            return points.ToArray();
        }
    }
}
