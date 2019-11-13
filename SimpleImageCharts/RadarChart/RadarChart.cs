using GdiSharp.Components;
using GdiSharp.Components.Base;
using GdiSharp.Models;
using SimpleImageCharts.Core;
using SimpleImageCharts.Core.Models;
using SimpleImageCharts.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SimpleImageCharts.RadarChart
{
    public class RadarChart : BaseChart, IRadarChart
    {
        private const int InitAngle = 90;

        public SlimFont ValueFont { get; set; } = new SlimFont("Arial", 12, FontStyle.Bold);

        public int StepSize { get; set; } = 0;

        public int MaxDataValue { get; set; } = 0;

        public string[] Categories { get; set; }

        public RadarChartSeries[] DataSets { get; set; }

        private float _maxRadius;

        private float _stepSizeInPixel;

        private PointF _centerPoint;

        private float _unitPixel;

        private int _numberOfSteps;

        public RadarChart()
        {
            Size = new Size(600, 300);
            Padding = new Padding(100, 50, 50, 50);
        }

        protected override void Init(GdiContainer mainContainer, GdiRectangle chartContainer)
        {
            base.Init(mainContainer, chartContainer);
            if (StepSize <= 0)
            {
                throw new ArgumentException("Invalid StepSize");
            }

            if (StepSize <= 0 || Categories.Length < 3)
            {
                throw new ArgumentException("Invalid data");
            }

            _maxRadius = Math.Min(chartContainer.Size.Width, chartContainer.Size.Height) / 2;
            _centerPoint = new PointF(Padding.Left + _maxRadius, Padding.Top + _maxRadius);

            var maxDataValue = MaxDataValue > 0 ? MaxDataValue : DataSets.SelectMany(x => x.Data).Max();

            maxDataValue = (int)Math.Ceiling((double)maxDataValue / StepSize) * StepSize; // round it

            _numberOfSteps = (int)Math.Ceiling(maxDataValue / StepSize) + 1;

            // remove this variable
            _stepSizeInPixel = _maxRadius / _numberOfSteps;
            _unitPixel = _maxRadius / (maxDataValue + StepSize);
        }

        protected override void DrawAfterRender(Graphics graphics)
        {
            base.DrawAfterRender(graphics);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            for (int i = 0; i < _numberOfSteps; i++)
            {
                DrawGridLine(graphics, i * StepSize * _unitPixel, _centerPoint);
            }

            DrawCategories(graphics);
            foreach (var dataset in DataSets)
            {
                DrawPathValues(graphics, dataset);
            }

            DrawValueTexts(graphics, _numberOfSteps, _centerPoint);
            DrawLegends(graphics);
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
            using (var font = ValueFont.ToFatFont())
            {
                stringFormat.Alignment = StringAlignment.Far;
                for (int i = 0; i < numberOfStep; i++)
                {
                    graphic.DrawString((i * StepSize).ToString(), font, Brushes.DarkBlue, root.X - 4, root.Y - i * _stepSizeInPixel, stringFormat);
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
            using (var font = Font.ToFatFont())
            {
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

                        graphics.DrawString(Categories[i], font, Brushes.Black, point, stringFormat);
                    }
                }
            }
        }

        private void DrawLegends(Graphics graphics)
        {
            const int LabelHeight = 30;
            var left = Padding.Left + _maxRadius * 2 + 70;
            var legendAreaHeight = LabelHeight * DataSets.Length;
            var top = (Size.Height - legendAreaHeight) / 2;
            foreach (var dataset in DataSets)
            {
                if (string.IsNullOrEmpty(dataset.Label))
                {
                    continue;
                }

                using (var pen = new Pen(dataset.Color, 3))
                using (var stringFormat = new StringFormat())
                using (var font = Font.ToFatFont())
                {
                    stringFormat.LineAlignment = StringAlignment.Center;

                    graphics.DrawLine(pen, left, top, left + 30, top);
                    graphics.DrawString(dataset.Label, font, Brushes.Gray, left + 35, top, stringFormat);
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