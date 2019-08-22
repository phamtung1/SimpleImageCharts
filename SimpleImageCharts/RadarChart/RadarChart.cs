using SimpleImageCharts.Core;
using SimpleImageCharts.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SimpleImageCharts.RadarChart
{
    public class RadarChart : IRadarChart
    {
        private const int InitAngle = 90;

        private const int MarginLeft = 100;

        private const int MarginRight = 50;

        private const int MarginTop = 50;

        private const int MarginBottom = 50;

        public Font Font { get; set; } = new Font("Arial", 12);

        public Font ValueFont { get; set; } = new Font("Arial", 12, FontStyle.Bold);

        public int Width { get; set; } = 600;

        public int Height { get; set; } = 300;

        public int StepSize { get; set; } = 0;

        public int MaxDataValue { get; set; } = 0;

        public string[] Categories { get; set; }

        public RadarChartSeries[] DataSets { get; set; }

        private float _maxRadius;

        private float _stepSizeInPixel;

        private PointF _centerPoint;

        private float _unitPixel;

        public virtual Bitmap CreateImage()
        {
            if (Categories.Length < 3)
            {
                throw new ArgumentException("Invalid data");
            }

            var maxDataValue = MaxDataValue > 0 ? MaxDataValue : DataSets.SelectMany(x => x.Data).Max();
            var bitmap = new Bitmap(Width, Height);
            using (var graphic = Graphics.FromImage(bitmap))
            {
                graphic.Clear(Color.White);
                graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                var numberOfStep = 0;

                var firstDigit = MathHelper.GetFirstDigit(maxDataValue);
                // test again with value <= 10
                numberOfStep = firstDigit + 1;

                var roundMaxValue = int.Parse(firstDigit.ToString().PadRight(maxDataValue.ToString().Length, '0'));
                if (StepSize == 0)
                {
                    StepSize = roundMaxValue / firstDigit;
                }
                else
                {
                    numberOfStep = roundMaxValue / StepSize + 1;
                }

                _maxRadius = Math.Min(Width - MarginLeft - MarginRight, Height - MarginTop - MarginBottom) / 2;
                _centerPoint = new PointF(MarginLeft + _maxRadius, MarginTop + _maxRadius);
                // remove this variable
                _stepSizeInPixel = _maxRadius / numberOfStep;
                _unitPixel = _maxRadius / (roundMaxValue + StepSize);
                for (int i = 0; i <= numberOfStep; i++)
                {
                    DrawGridLine(graphic, i * StepSize * _unitPixel, _centerPoint);
                }

                DrawCategories(graphic);
                foreach (var dataset in DataSets)
                {
                    DrawPathValues(graphic, dataset);
                }

                DrawValueTexts(graphic, numberOfStep, _centerPoint);
                DrawLegends(graphic);
            }

            return bitmap;
        }

        private void DrawPathValues(Graphics graphics, RadarChartSeries dataset)
        {
            var step = 360.0f / Categories.Length;
            var startAngle = 90;
            float angle = startAngle;

            var points = new PointF[dataset.Data.Length];

            for (var i = 0; i < dataset.Data.Length; i++)
            {
                var radius = dataset.Data[i] * _unitPixel;
                points[i] = MathHelper.DegreeToPoint(angle, radius, _centerPoint);

                angle -= step;
            }

            using (var pen = new Pen(dataset.Color, 3))
            {
                graphics.DrawPolygon(pen, points);
            }
        }

        private void DrawValueTexts(Graphics graphic, int numberOfStep, PointF root)
        {
            using (var stringFormat = new StringFormat())
            {
                stringFormat.Alignment = StringAlignment.Far;
                for (int i = 0; i <= numberOfStep; i++)
                {
                    graphic.DrawString((i * StepSize).ToString(), this.ValueFont, Brushes.DarkBlue, root.X - 4, root.Y - i * _stepSizeInPixel + 2, stringFormat);
                }
            }
        }

        private void DrawGridLine(Graphics graphic, float radius, PointF center)
        {
            using (var pen = new Pen(ColorTranslator.FromHtml("#C4C4C4")))
            {
                var verticies = CalculateVertices(Categories.Length, radius, InitAngle, center);
                graphic.DrawPolygon(pen, verticies);
            }
        }

        private void DrawCategories(Graphics graphics)
        {
            var vertices = CalculateVertices(Categories.Length, _maxRadius, InitAngle, _centerPoint);

            for (int i = 0; i < Categories.Length; i++)
            {
                using (var stringFormat = new StringFormat())
                {
                    var point = vertices[i];
                    if (point.X == _centerPoint.X)
                    {
                        stringFormat.Alignment = StringAlignment.Center;
                    }
                    else if (point.X > _centerPoint.X)
                    {
                        stringFormat.Alignment = StringAlignment.Near;
                    }
                    else
                    {
                        stringFormat.Alignment = StringAlignment.Far;
                    }

                    if (point.Y < _centerPoint.Y)
                    {
                        point.Y -= 20;
                    }

                    graphics.DrawString(Categories[i], this.Font, Brushes.Black, point, stringFormat);
                }
            }
        }

        private void DrawLegends(Graphics graphics)
        {
            const int LabelHeight = 30;
            var left = MarginLeft + _maxRadius * 2 + 70;
            var legendAreaHeight = LabelHeight * DataSets.Length;
            var top = (Height - legendAreaHeight) / 2;
            foreach (var dataset in DataSets)
            {
                if (string.IsNullOrEmpty(dataset.Label))
                {
                    continue;
                }

                using (var pen = new Pen(dataset.Color, 3))
                using (var stringFormat = new StringFormat())
                {
                    stringFormat.LineAlignment = StringAlignment.Center;

                    graphics.DrawLine(pen, left, top, left + 30, top);
                    graphics.DrawString(dataset.Label, this.Font, Brushes.Gray, left + 35, top, stringFormat);
                }

                top += LabelHeight;
            }
        }

        private static PointF[] CalculateVertices(int sides, float radius, int startAngle, PointF center)
        {
            var points = new List<PointF>();
            var step = 360.0f / sides;
            float angle = startAngle;
            for (var i = 0; i < sides; i++)
            {
                points.Add(MathHelper.DegreeToPoint(angle, radius, center));
                angle -= step;
            }

            return points.ToArray();
        }
    }
}