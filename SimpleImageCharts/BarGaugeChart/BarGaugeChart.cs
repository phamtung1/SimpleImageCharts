using GdiSharp.Components;
using GdiSharp.Components.Base;
using SimpleImageCharts.Core;
using SimpleImageCharts.Core.Models;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace SimpleImageCharts.BarGaugeChart
{
    public class BarGaugeChart : BaseChart
    {
        private const float StartAngle = 180F;

        public int MaxValue { get; set; } = 10;

        public DataItem[] DataItems { get; set; }

        public int BarSize { get; set; } = 20;

        public int GapSize { get; set; } = 10;

        public BarGaugeChart()
        {
            Padding = new Padding(50, 50, 50, 150);
        }

        protected override void Init(GdiContainer mainContainer, GdiRectangle chartContainer)
        {
            base.Init(mainContainer, chartContainer);
            this.MainContainer.BackgroundColor = Color.Transparent;
            var chartRect = CalculateChartRect();
            this.LegendWidth = chartRect.Width;
            this.LegendHeight = this.Size.Height - this.Padding.Top - chartRect.Height /2 - 50;
        }

        protected override void DrawBeforeRender(Graphics graphics)
        {
            base.DrawBeforeRender(graphics);

            var chartRect = CalculateChartRect();
            var center = new PointF(Padding.Left + chartRect.Width / 2f, Padding.Top + chartRect.Height / 2f);

            var sweepAngle = 180f / MaxValue;

            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.Clear(Color.White);

            DrawDataItems(graphics, chartRect, center, sweepAngle);

            DrawValueTexts(graphics, chartRect, center, sweepAngle);
        }

        protected override void CreateLegendItems()
        {
            base.CreateLegendItems();
            Legend.Items = DataItems.Select(x => new LegendItemModel
            {
                Color = x.Color,
                Text = x.Label
            }).ToArray();
        }

        private void DrawValueTexts(Graphics graphics, Rectangle chartRect, PointF center, float sweepAngle)
        {
            var startAngle = StartAngle;

            int labelRadius = chartRect.Width / 2 + 20;
            using (var stringFormat = new StringFormat())
            using (var valueFont = new Font("Arial", 10))
            {
                for (var i = 0; i <= MaxValue; i++)
                {
                    var labelAngle = Math.PI * startAngle / 180f;

                    var x = center.X + (float)(labelRadius * Math.Cos(labelAngle));
                    var y = center.Y + (float)(labelRadius * Math.Sin(labelAngle));

                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    graphics.DrawString(i.ToString(), valueFont, Brushes.Black, x, y, stringFormat);

                    startAngle += sweepAngle;
                }
            }
        }

        private void DrawDataItems(Graphics graphics, Rectangle chartRect, PointF center, float sweepAngle)
        {
            var barSize = new Size(-BarSize, -BarSize);
            var gapSize = new Size(-GapSize, -GapSize);

            graphics.FillEllipse(Brushes.White, chartRect);
            graphics.DrawPie(Pens.Gray, chartRect, StartAngle, 180);
            var rect = chartRect;
            DrawValueLines(graphics, rect.Width / 2, center, sweepAngle);
            foreach (var item in DataItems)
            {
                rect.Inflate(gapSize);
                if (rect.Width <= 0 || rect.Height <= 0)
                {
                    throw new ArgumentException("Invalid chart size or setting.");
                }

                graphics.FillPie(new SolidBrush(item.Color), rect, StartAngle, (float)(item.Value * sweepAngle));
                rect.Inflate(barSize);
                graphics.FillEllipse(new SolidBrush(Color.White), rect);

                DrawValueLines(graphics, rect.Width / 2, center, sweepAngle);
            }
        }

        private void DrawValueLines(Graphics graphics, float radius, PointF center, float sweepAngle)
        {
            var startAngle = StartAngle;

            for (var i = 0; i <= MaxValue; i++)
            {
                var labelAngle = Math.PI * startAngle / 180f;
                var x = center.X + (float)(radius * Math.Cos(labelAngle));
                var y = center.Y + (float)(radius * Math.Sin(labelAngle));

                graphics.DrawLine(Pens.LightGray, center.X, center.Y, x, y);

                startAngle += sweepAngle;
            }
        }

        private Rectangle CalculateChartRect()
        {
            var rect = new Rectangle(
                Padding.Left,
                Padding.Top,
                this.Size.Width - Padding.Left - Padding.Right,
                this.Size.Height - Padding.Top - Padding.Bottom);

            if (rect.Width < rect.Height)
            {
                rect.Height = rect.Width;
            }
            else if (rect.Height < rect.Width / 2)
            {
                rect.Height = rect.Height * 2;
                rect.Width = rect.Height;
            }
            else
            {
                rect.Height = rect.Width;
            }

            return rect;
        }
    }
}