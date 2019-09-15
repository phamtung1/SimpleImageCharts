using System;
using System.Drawing;
using System.Linq;
using GdiSharp.Components.Base;
using GdiSharp.Models;

namespace SimpleImageCharts.PieChart.GdiComponents
{
    public class GdiPie : GdiComponent
    {
        private const float InitialAngle = -90;

        public string LabelFormat { get; set; } = "{0}";

        public Font Font { get; set; } = new Font("Arial", 12);

        public float Diameter { get; set; }

        public Border Border { get; set; } = new Border(2, Color.White);

        public PieEntry[] Entries { get; set; }

        public bool IsDonut { get; set; }

        public Color TextColor { get; set; } = Color.White;

        protected override SizeF GetComponentSize(Graphics graphics)
        {
            return new SizeF(Diameter, Diameter);
        }

        public override void Render(Graphics graphics)
        {
            base.Render(graphics);

            var position = GetAbsolutePosition(graphics);
            float total = Entries.Sum(x => x.Value);

            DrawPie(graphics, position, total);
            DrawValues(graphics, position, total);
        }

        private void DrawPie(Graphics graphics, PointF position, float total)
        {
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            var startAngle = InitialAngle;
            var rect = new RectangleF(position.X, position.Y, Diameter, Diameter);
            using (var borderPen = new Pen(Border.Color, Border.Size))
            {
                foreach (var entry in Entries)
                {
                    var sweepAngle = entry.Value * 360f / total;
                    using (var brush = new SolidBrush(entry.Color))
                    {
                        graphics.FillPie(brush, rect.X, rect.Y, rect.Width, rect.Height, startAngle, sweepAngle);
                    }

                    graphics.DrawPie(borderPen, rect, startAngle, sweepAngle);

                    startAngle += sweepAngle;
                }
            }

            if (IsDonut)
            {
                var smallDiameter = Diameter / 2;
                var x = position.X + (smallDiameter / 2);
                var y = position.Y + (smallDiameter / 2);
                graphics.FillEllipse(Brushes.White, x, y, smallDiameter, smallDiameter);
            }
        }

        private void DrawValues(Graphics graphics, PointF position, float total)
        {
            using (var labelBrush = new SolidBrush(TextColor))
            using (StringFormat stringFormat = new StringFormat())
            {
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;

                var centerX = position.X + Diameter / 2;
                var centerY = position.Y + Diameter / 2;

                var labelRadius = Diameter * 0.4f;

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
                    graphics.DrawString(string.Format(LabelFormat, entry.Value), Font, labelBrush, x, y, stringFormat);

                    startAngle += sweepAngle;
                }
            }
        }
    }
}