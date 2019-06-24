using SimpleImageCharts.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;

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

        public RadarChartSeries[] DataSets { get; set; }

        public Bitmap CreateImage()
        {
            if (NumberOfSides < 3)
            {
                throw new ArgumentException("Invalid Number of sides");
            }

            var maxDataValue = 87;
            var bitmap = new Bitmap(Width, Height);
            using (var graphic = Graphics.FromImage(bitmap))
            {
                graphic.Clear(Color.White);

                graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                var firstDigit = MathHelper.GetFirstDigit(maxDataValue);
                var numberOfStep = firstDigit + 1;
                var roundMaxValue = int.Parse(firstDigit.ToString().PadRight(maxDataValue.ToString().Length, '0'));
                var stepSize = roundMaxValue / firstDigit;
                var radius = Math.Min(Width - MarginLeft - MarginRight, Height - MarginTop - MarginBottom) / 2;
                var center = new PointF(MarginLeft + radius, MarginTop + radius);
                var stepSizePixel = radius / numberOfStep;
                for (int i = 1; i < numberOfStep; i++)
                {
                    DrawPolygon(graphic, i * stepSizePixel, center);
                }
            }

            return bitmap;
        }

        private void DrawValueTexts(Graphics graphic, int numberOfStep, PointF root)
        {
            for (int i = 0; i < numberOfStep; i++)
            {

            }
        }

        private void DrawPolygon(Graphics graphic, int radius, PointF center)
        {
            var verticies = CalculateVertices(NumberOfSides, radius, -90, center);
            graphic.DrawPolygon(Pens.Gray, verticies);
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