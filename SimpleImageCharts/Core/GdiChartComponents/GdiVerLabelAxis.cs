using System.Drawing;
using GdiSharp.Components;

namespace SimpleImageCharts.Core.GdiChartComponents
{
    public class GdiVerLabelAxis : GdiRectangle
    {
        public string[] Labels { get; set; }

        public float LabelHeight { get; set; }

        public float LabelOffsetX { get; set; }

        public Font Font { get; set; }

        public override void Render(Graphics graphics)
        {
            base.Render(graphics);
            var position = GetAbsolutePosition(graphics);
            var y = position.Y + LabelHeight / 2;
            var x = position.X + LabelOffsetX;
            using (StringFormat stringFormat = new StringFormat())
            {
                stringFormat.LineAlignment = StringAlignment.Center;
                stringFormat.Alignment = StringAlignment.Far;

                foreach (var item in Labels)
                {
                    graphics.DrawString(item, Font, Brushes.Gray, x, y, stringFormat);
                    y += LabelHeight;
                }
            }
        }
    }
}