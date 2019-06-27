using System;
using System.Drawing;
using System.Linq;

namespace SimpleImageCharts.PieChart
{
    public class PieChart
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

        public Bitmap CreateImage()
        {
            if (Entries == null || Entries.Length == 0)
            {
                throw new ArgumentException("Invalid entries data");
            }

            var bitmap = new Bitmap(Width, Height);

            using (var borderPen = new Pen(BorderColor, BorderWidth))
            using (var graphic = Graphics.FromImage(bitmap))
            {
                graphic.Clear(Color.White);
                graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graphic.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                var rect = new Rectangle(0, 0, Height, Height);
                float total = Entries.Sum(x => x.Value);
                var startAngle = InitialAngle;
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

                DrawValues(graphic, total);
                DrawLegend(graphic);

                if (IsDonut)
                {
                    var x = Height / 4;
                    graphic.FillEllipse(Brushes.White, x, x, Height / 2, Height / 2);
                }

                if(AfterDraw != null)
                {
                    AfterDraw(graphic);
                }
            }

            return bitmap;
        }

        private void DrawValues(Graphics graphic, float total)
        {
            using (var labelBrush = new SolidBrush(TextColor))
            using (StringFormat stringFormat = new StringFormat())
            {
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;

                var centerX = Height / 2f;
                var centerY = centerX;

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

            var left = this.Height + 30;
            var top = 10;

            using (var textBrush = new SolidBrush(Color.FromArgb(70, 70, 70)))
            {
                foreach (var entry in Entries)
                {
                    using (var brush = new SolidBrush(entry.Color))
                    {
                        graphic.FillRectangle(brush, left, top, BoxWidth, BoxHeight);
                        graphic.DrawString(entry.Label, Font, textBrush, left + BoxWidth + 5, top);
                    }

                    top += 20;
                }
            }

            graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }
    }
}