using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using GdiSharp.Components;
using GdiSharp.Components.Base;
using GdiSharp.Models;
using SimpleImageCharts.Core;
using SimpleImageCharts.Core.Models;

namespace SimpleImageCharts.SemiCircleGaugeChart
{
    public class SemiCircleGaugeChart : BaseChart, ISemiCircleGaugeChart
    {
        private const float StartAngle = 180F;

        public int MaxValue { get; set; } = 10;

        public DataItem[] DataItems { get; set; }

        public int BarSize { get; set; } = 20;

        public int GapSize { get; set; } = 10;

        public string LeftCaption { get; set; }

        public string RightCaption { get; set; }

        private Rectangle _chartRect;

        public SemiCircleGaugeChart()
        {
            Padding = new Padding(100, 50, 100, 100);
        }

        protected override void Init(GdiContainer mainContainer, GdiRectangle chartContainer)
        {
            base.Init(mainContainer, chartContainer);
            this.MainContainer.BackgroundColor = Color.Transparent;
            _chartRect = CalculateChartRect();
            this.LegendWidth = _chartRect.Width;
            this.LegendHeight = this.Size.Height - this.Padding.Top - _chartRect.Height / 2 - 50;
        }

        protected override void BuildComponents(GdiContainer mainContainer, GdiRectangle chartContainer)
        {
            base.BuildComponents(mainContainer, chartContainer);

            // Add left, right captions
            const int RectWidth = 200;
            var rectTop = Padding.Top + _chartRect.Height / 2 + 10;
            if (!string.IsNullOrWhiteSpace(LeftCaption))
            {
                var rect = new GdiRectangle
                {
                    Margin = new PointF(_chartRect.Left - RectWidth / 2, rectTop),
                    Size = new SizeF(RectWidth, 30)
                };
                mainContainer.AddChild(rect);
                rect.AddChild(new GdiText
                {
                    Font = SlimFont.Default,
                    Content = LeftCaption,
                    HorizontalAlignment = GdiSharp.Enum.GdiHorizontalAlign.Center,
                    VerticalAlignment = GdiSharp.Enum.GdiVerticalAlign.Middle,
                    TextAlign = StringAlignment.Center
                });
            }

            if (!string.IsNullOrWhiteSpace(RightCaption))
            {
                var rect = new GdiRectangle
                {
                    Margin = new PointF(Padding.Left + _chartRect.Width - RectWidth / 2, rectTop),
                    Size = new SizeF(RectWidth, 30)
                };
                mainContainer.AddChild(rect);
                rect.AddChild(new GdiText
                {
                    Font = SlimFont.Default,
                    Content = RightCaption,
                    HorizontalAlignment = GdiSharp.Enum.GdiHorizontalAlign.Center,
                    VerticalAlignment = GdiSharp.Enum.GdiVerticalAlign.Middle,
                    TextAlign = StringAlignment.Center
                });
            }
        }

        protected override void DrawBeforeRender(Graphics graphics)
        {
            base.DrawBeforeRender(graphics);

            var center = new PointF(Padding.Left + _chartRect.Width / 2f, Padding.Top + _chartRect.Height / 2f);

            var sweepAngle = 180f / MaxValue;

            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.Clear(Color.White);

            DrawDataItems(graphics, _chartRect, center, sweepAngle);

            DrawValueTexts(graphics, _chartRect, center, sweepAngle);
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

                var itemValue = float.IsNaN(item.Value) ? 0 : item.Value;
                graphics.FillPie(new SolidBrush(item.Color), rect, StartAngle, (float)(itemValue * sweepAngle));
                var itemBarSize = item.BarSize == 0 ? barSize : new Size(-item.BarSize, -item.BarSize);
                rect.Inflate(itemBarSize);
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