using System;
using System.Drawing;
using System.Linq;
using SimpleImageCharts.Core;
using SimpleImageCharts.Enum;

namespace SimpleImageCharts.PieChart
{
    public class PieChart : IPieChart
    {
        private const float InitialAngle = -90;

        public string LabelFormat { get; set; } = "{0}";

        public int Width { get; set; } = 600;

        public int Height { get; set; } = 300;

        public PieEntry[] Entries { get; set; }

        public Color BorderColor { get; set; } = Color.White;

        public byte BorderWidth { get; set; } = 2;

        public Font Font { get; set; } = new Font("Arial", 12);

        public Color TextColor { get; set; } = Color.White;

        public bool IsDonut { get; set; } = false;

        public Action<Graphics> AfterDraw { get; set; }

        public PositionAlignment PieAligment { get; set; } = PositionAlignment.Left;

        public virtual Bitmap CreateImage()
        {
            if (Entries == null || Entries.Length == 0)
            {
                throw new ArgumentException("Invalid entries data");
            }

            if (PieAligment == PositionAlignment.Top || PieAligment == PositionAlignment.Bottom)
            {
                throw new ArgumentException("Unsupported Position!");
            }

            var bitmap = new Bitmap(Width, Height);

            using (var graphic = Graphics.FromImage(bitmap))
            {
                graphic.Clear(Color.White);
                graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graphic.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                float total = Entries.Sum(x => x.Value);
                DrawPie(graphic, total);

                DrawValues(graphic, total);
                DrawLegend(graphic);

                if (AfterDraw != null)
                {
                    AfterDraw(graphic);
                }
            }

            return bitmap;
        }

        private void DrawPie(Graphics graphic, float total)
        {
            var startAngle = InitialAngle;
            var rect = PieAligment == PositionAlignment.Left ? new Rectangle(0, 0, Height, Height) :
                new Rectangle(Width - Height, 0, Height, Height);
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
                var x = this.PieAligment == PositionAlignment.Left ? Height / 4 : Width - (Height / 4 * 3);
                var y = Height / 4;
                graphic.FillEllipse(Brushes.White, x, y, Height / 2, Height / 2);
            }

        }

        private void DrawValues(Graphics graphic, float total)
        {
            using (var labelBrush = new SolidBrush(TextColor))
            using (StringFormat stringFormat = new StringFormat())
            {
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;

                var centerX = PieAligment == PositionAlignment.Left ? Height / 2f : Width - Height / 2f;
                var centerY = Height / 2f;

                var labelRadius = Height * 0.4f;

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

            var left = PieAligment == PositionAlignment.Left ? this.Height + 40 : Width - Height - 150;
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