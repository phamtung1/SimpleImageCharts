using System;
using System.Drawing;
using System.Linq;

namespace SimpleImageCharts.PieChart
{
    public class PieChart
    {
        private const float InitialAngle = -90;

        public string LabelFormat { get; set; } = "0.##";

        public int Radius { get; set; } = 300;

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

            var bitmap = new Bitmap(Radius, Radius);

            using (var borderPen = new Pen(BorderColor, BorderWidth))
            using (var graphic = Graphics.FromImage(bitmap))
            {
                graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                var rect = new Rectangle(0, 0, Radius, Radius);
                float total = Entries.Sum(x => x.Value);
                var startAngle = InitialAngle;
                foreach (var entry in Entries)
                {
                    var endAngle = entry.Value * 360f / total;
                    var brush = new SolidBrush(entry.Color);
                    graphic.FillPie(brush, rect, startAngle, endAngle);
                    graphic.DrawPie(borderPen, rect, startAngle, endAngle);

                    startAngle += endAngle;
                }

                DrawLabels(graphic, total);
            }

            return bitmap;
        }

        private void DrawLabels(Graphics graphic, float total)
        {
            using (var labelBrush = new SolidBrush(TextColor))
            using (var labelFont = new Font("Arial", 12))
            using (StringFormat stringFormat = new StringFormat())
            {
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;

                var centerX = Radius / 2f;
                var centerY = centerX;

                var labelRadius = Radius * 0.4f;

                var startAngle = InitialAngle;
                foreach (var entry in Entries)
                {
                    var endAngle = entry.Value * 360f / total;

                    var labelAngle = Math.PI * (startAngle + endAngle / 2f) / 180f;
                    var x = centerX + (float)(labelRadius * Math.Cos(labelAngle));
                    var y = centerY + (float)(labelRadius * Math.Sin(labelAngle));
                    graphic.DrawString(entry.Value.ToString(LabelFormat),
                        labelFont, labelBrush, x, y, stringFormat);

                    startAngle += endAngle;
                }
            }
        }
    }
}