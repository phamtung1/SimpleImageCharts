using SimpleImageCharts.Core;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SimpleImageCharts.BarGauge
{
    public class BarGaugeChart : BaseChart
    {
        protected override void Draw(Graphics graphics)
        {
            base.Draw(graphics);

            const float StartAngle = 180F;

            var rect = new Rectangle(30, 30, 400, 400);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.Clear(Color.White);

           
            var inflateSize = new Size(-20, -20);

            graphics.FillEllipse(Brushes.White, rect);
            graphics.DrawPie(Pens.Black, rect, StartAngle, 180);

            var values = new int[] { 10, 20, 30 };
            var colors = new Color[] { Color.Red, Color.Green, Color.Blue };
            for (int i = 0; i < values.Length; i++)
            {
                var value = values[i];
                var color = colors[i];
                rect.Inflate(inflateSize);
                graphics.FillPie(new SolidBrush(color), rect, StartAngle, (float)(value * 3.6));
                rect.Inflate(inflateSize);
                graphics.FillEllipse(new SolidBrush(Color.White), rect);
            }

            var startAngle = StartAngle;
            var centerX = 30 + 400 / 2;
            var centerY = centerX;
            int labelRadius = centerX;
            for (var i = 1; i <= 8; i++)
            {
                var sweepAngle = 22.5f;

                var labelAngle = Math.PI * (startAngle + sweepAngle / 2f) / 180f;
                var x = centerX + (float)(labelRadius * Math.Cos(labelAngle));
                var y = centerY + (float)(labelRadius * Math.Sin(labelAngle));
                graphics.DrawString(i.ToString(), new Font("Arial", 10), Brushes.Black, x, y);
                graphics.DrawLine(Pens.Gray, centerX, centerY, x, y);
                startAngle += sweepAngle;
            }

        }
    }
}