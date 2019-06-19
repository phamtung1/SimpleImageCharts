using System;
using System.Drawing;
using System.Linq;

namespace SimpleImageCharts.PieChart
{
    public class PieChart
    {
        private const float InitialAngle = -90;

        public string LabelFormat { get; set; } = "0.##";

        public int Width { get; set; } = 600;

        public int Height { get; set; } = 300;

        public PieEntry[] Entries { get; set; }

        public Color BorderColor { get; set; } = Color.White;

        public byte BorderWidth { get; set; } = 2;

        public Font Font { get; set; } = new Font("Arial", 10);

        public Color TextColor { get; set; } = Color.White;

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
                graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graphic.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                var rect = new Rectangle(0, 0, Height, Height);
                float total = Entries.Sum(x => x.Value);
                var startAngle = InitialAngle;
                foreach (var entry in Entries)
                {
                    var endAngle = entry.Value * 360f / total;
                    using (var brush = new SolidBrush(entry.Color))
                    {
                        graphic.FillPie(brush, rect, startAngle, endAngle);
                    }

                    graphic.DrawPie(borderPen, rect, startAngle, endAngle);

                    startAngle += endAngle;
                }

                DrawValues(graphic, total);
                DrawLegend(graphic);
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
                    var endAngle = entry.Value * 360f / total;

                    var labelAngle = Math.PI * (startAngle + endAngle / 2f) / 180f;
                    var x = centerX + (float)(labelRadius * Math.Cos(labelAngle));
                    var y = centerY + (float)(labelRadius * Math.Sin(labelAngle));
                    graphic.DrawString(entry.Value.ToString(LabelFormat), Font, labelBrush, x, y, stringFormat);

                    startAngle += endAngle;
                }
            }
        }

        private void DrawLegend(Graphics graphic)
        {
            const int Width = 25;
            const int Height = 15;

            var left = this.Height + 30;
            var top = 10;

            using (var textBrush = new SolidBrush(Color.FromArgb(100, 100, 100)))
            {
                var font = new Font("Arial", 12);

                foreach (var entry in Entries)
                {
                    using (var brush = new SolidBrush(entry.Color))
                    {
                        graphic.FillRectangle(brush, left, top, Width, Height);
                        graphic.DrawString(entry.Label, font, textBrush, left + Width + 5, top);
                    }

                    top += 20;
                }
            }
        }
    }
}