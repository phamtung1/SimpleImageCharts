using GdiSharp.Components;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SimpleImageCharts.SingleRangeBarChart.GdiComponents
{
    public class GdiRangeBar : GdiRectangle
    {
        public Color CenterColor { get; set; } = Color.White;

        protected override Brush GetFillBrush(Graphics graphics)
        {
            var position = GetAbsolutePosition(graphics);
            var colorBlend = new ColorBlend(3)
            {
                Colors = new[] { Color, CenterColor, Color },
                Positions = new[] { 0f, 0.5f, 1f }
            };
            var brush = new LinearGradientBrush(new Point((int)position.X, 0),
               new Point((int)position.X + (int)this.Size.Width, 0),
               this.Color,
               this.CenterColor);
            brush.InterpolationColors = colorBlend;
            return brush;
        }
    }
}