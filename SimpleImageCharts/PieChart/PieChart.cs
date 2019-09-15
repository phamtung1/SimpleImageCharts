using System;
using System.Drawing;
using System.Linq;
using GdiSharp.Components;
using GdiSharp.Components.Base;
using SimpleImageCharts.Core;
using SimpleImageCharts.Core.Models;
using SimpleImageCharts.Enum;

namespace SimpleImageCharts.PieChart
{
    public class PieChart : BaseChart, IPieChart
    {
        private const float InitialAngle = -90;

        public string LabelFormat { get; set; } = "{0}";

        public PieEntry[] Entries { get; set; }

        public Color BorderColor { get; set; } = Color.White;

        public byte BorderWidth { get; set; } = 2;

        public Color TextColor { get; set; } = Color.White;

        public bool IsDonut { get; set; } = false;

        public Action<Graphics> AfterDraw { get; set; }

        public PositionAlign PieAligment { get; set; } = PositionAlign.Left;

        public PieChart()
        {
            Size = new Size(600, 300);
        }

        protected override void Init(GdiContainer mainContainer, GdiRectangle chartContainer)
        {
            base.Init(mainContainer, chartContainer);

            if (Entries == null || Entries.Length == 0)
            {
                throw new ArgumentException("Invalid entries data");
            }

            if (PieAligment == PositionAlign.Top || PieAligment == PositionAlign.Bottom)
            {
                throw new ArgumentException("Unsupported Position!");
            }
        }

        protected override void Draw(Graphics graphics)
        {
            base.Draw(graphics);
            graphics.Clear(Color.White);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            float total = Entries.Sum(x => x.Value);
            DrawPie(graphics, total);

            DrawValues(graphics, total);
            DrawLegend(graphics);

            if (AfterDraw != null)
            {
                AfterDraw(graphics);
            }
        }

        private void DrawPie(Graphics graphic, float total)
        {
            var startAngle = InitialAngle;
            var rect = PieAligment == PositionAlign.Left ? new Rectangle(0, 0, Size.Height, Size.Height) :
                new Rectangle(Size.Width - Size.Height, 0, Size.Height, Size.Height);
            using (var borderPen = new Pen(BorderColor, BorderWidth))
            {
                foreach (var entry in Entries)
                {
                    var sweepAngle = entry.Value * 360f / total;
                    using (var brush = new SolidBrush(entry.Color))
                    {
                        graphic.FillPie(brush, rect, startAngle, sweepAngle);
                    }

                    graphic.DrawPie(borderPen, rect, startAngle, sweepAngle);

                    startAngle += sweepAngle;
                }
            }

            if (IsDonut)
            {
                var x = this.PieAligment == PositionAlign.Left ? Size.Height / 4 : Size.Width - (Size.Height / 4 * 3);
                var y = Size.Height / 4;
                graphic.FillEllipse(Brushes.White, x, y, Size.Height / 2, Size.Height / 2);
            }
        }

        private void DrawValues(Graphics graphic, float total)
        {
            using (var labelBrush = new SolidBrush(TextColor))
            using (StringFormat stringFormat = new StringFormat())
            {
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;

                var centerX = PieAligment == PositionAlign.Left ? Size.Height / 2f : Size.Width - Size.Height / 2f;
                var centerY = Size.Height / 2f;

                var labelRadius = Size.Height * 0.4f;

                var startAngle = InitialAngle;
                foreach (var entry in Entries)
                {
                    if (entry.Value == 0)
                    {
                        continue;
                    }

                    var sweepAngle = entry.Value * 360f / total;

                    var labelAngle = Math.PI * (startAngle + sweepAngle / 2f) / 180f;
                    var x = centerX + (float)(labelRadius * Math.Cos(labelAngle));
                    var y = centerY + (float)(labelRadius * Math.Sin(labelAngle));
                    graphic.DrawString(string.Format(LabelFormat, entry.Value), Font, labelBrush, x, y, stringFormat);

                    startAngle += sweepAngle;
                }
            }
        }

        private void DrawLegend(Graphics graphic)
        {
            graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            const int BoxWidth = 25;
            const int BoxHeight = 15;
            const int LineHeight = 20;

            var left = PieAligment == PositionAlign.Left ? this.Size.Height + 40 : Size.Width - Size.Height - 150;
            var top = 20;

            using (var textBrush = new SolidBrush(Color.FromArgb(70, 70, 70)))
            {
                foreach (var entry in Entries)
                {
                    using (var brush = new SolidBrush(entry.Color))
                    {
                        graphic.FillRectangle(brush, left, top, BoxWidth, BoxHeight);
                        graphic.DrawString(entry.Label, Font, textBrush, left + BoxWidth + 5, top);
                    }

                    top += LineHeight;
                }
            }

            graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }
    }
}