using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using SimpleImageCharts.Helpers;

namespace SimpleImageCharts.RadarChart
{
    public class RadarChart
    {
        private const int InitAngle = -90;

        private const int MarginLeft = 100;

        private const int MarginRight = 50;

        private const int MarginTop = 50;

        private const int MarginBottom = 50;

        public Font Font { get; set; } = new Font("Arial", 10);

        public Font ValueFont { get; set; } = new Font("Arial", 10, FontStyle.Bold);

        public int Width { get; set; } = 600;

        public int Height { get; set; } = 300;

        public int NumberOfSides { get; set; } = 3;

        public string[] Categories { get; set; }

        public RadarChartSeries[] DataSets { get; set; }

        private float _maxRadius;

        private float _stepSizeInPixel;

        private PointF _centerPoint;

        private float _unitPixel;

        private float _stepSize;
        public Bitmap CreateImage()
        {
            if (NumberOfSides < 3)
            {
                throw new ArgumentException("Invalid Number of sides");
            }

            var maxDataValue = DataSets.SelectMany(x => x.Data).Max();
            var bitmap = new Bitmap(Width, Height);
            using (var graphic = Graphics.FromImage(bitmap))
            {
                graphic.Clear(Color.White);

                graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                var firstDigit = MathHelper.GetFirstDigit(maxDataValue);
                // test again with value <= 10
                var numberOfStep = firstDigit + 1;
                var roundMaxValue = int.Parse(firstDigit.ToString().PadRight(maxDataValue.ToString().Length, '0'));
                _stepSize = roundMaxValue / firstDigit;
                _maxRadius = Math.Min(Width - MarginLeft - MarginRight, Height - MarginTop - MarginBottom) / 2;
                _centerPoint = new PointF(MarginLeft + _maxRadius, MarginTop + _maxRadius);
                // remove this variable
                _stepSizeInPixel = _maxRadius / numberOfStep;
                _unitPixel = _maxRadius / (roundMaxValue + _stepSize);
                for (int i = 0; i <= numberOfStep; i++)
                {
                    DrawPolygon(graphic, i * _stepSize * _unitPixel, _centerPoint);
                }

                DrawValueTexts(graphic, numberOfStep, _centerPoint);
                DrawCategories(graphic);
                foreach (var dataset in DataSets)
                {
                    DrawPathValues(graphic, dataset.Data);
                }
            }

            return bitmap;
        }

        private void DrawPathValues(Graphics graphics, int[] values)
        {
            var step = 360.0f / NumberOfSides;
            var startAngle = 90;
            float angle = startAngle;
            
            var points = new PointF[values.Length];
            for (var i = 0; i < values.Length; i++)
            {
                var radius = values[i] * _unitPixel;
                points[i] = MathHelper.DegreeToPoint(angle, radius, _centerPoint);
                
                angle -= step;
            }

            graphics.DrawPolygon(Pens.Red, points);
        }

        private void DrawValueTexts(Graphics graphic, int numberOfStep, PointF root)
        {
            using (var stringFormat = new StringFormat())
            {
                stringFormat.Alignment = StringAlignment.Far;
                for (int i = 0; i <= numberOfStep; i++)
                {
                    graphic.DrawString((i * _stepSize).ToString(), this.ValueFont, Brushes.DarkBlue, root.X - 4, root.Y - i * _stepSizeInPixel + 2, stringFormat);
                }
            }
        }

        private void DrawPolygon(Graphics graphic, float radius, PointF center)
        {
            var verticies = CalculateVertices(NumberOfSides, radius, InitAngle, center);
            graphic.DrawPolygon(Pens.Gray, verticies);
        }

        private void DrawCategories(Graphics graphics)
        {
            var vertices = CalculateVertices(NumberOfSides, _maxRadius, InitAngle, _centerPoint);
            
            for (int i = 0; i < NumberOfSides; i++)
            {
                using (var stringFormat = new StringFormat())
                {
                    var point = vertices[i];
                    if(point.X == _centerPoint.X)
                    {
                        stringFormat.Alignment = StringAlignment.Center;
                    }
                    else if(point.X > _centerPoint.X)
                    {
                        stringFormat.Alignment = StringAlignment.Near;
                    }
                    else
                    {
                        stringFormat.Alignment = StringAlignment.Far;
                    }

                    if (point.Y == _centerPoint.Y)
                    {
                        
                    }
                    else if (point.Y > _centerPoint.Y)
                    {
                        
                    }
                    else
                    {
                        point.Y -= 15;
                    }

                    graphics.DrawString(Categories[i], this.Font, Brushes.Gray, point, stringFormat);
                }
            }
        }

        private PointF[] CalculateVertices(int sides, float radius, int startAngle, PointF center)
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