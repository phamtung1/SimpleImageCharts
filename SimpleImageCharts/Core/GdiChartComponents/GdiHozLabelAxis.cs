using System.Drawing;
using GdiSharp.Components;

namespace SimpleImageCharts.Core.GdiChartComponents
{
    public class GdiHozLabelAxis : GdiRectangle
    {
        public string[] LeftToRightLabels { get; set; }

        public string[] RightToLeftLabels { get; set; }

        public float LabelWidth { get; set; }

        public float LabelOffsetY { get; set; }

        public Font Font { get; set; }

        public float RootX { get; set; }

        public override void Render(Graphics graphics)
        {
            base.Render(graphics);

            var position = GetAbsolutePosition(graphics);
            var x = position.X + RootX;
            var y = position.Y + LabelOffsetY;

            using (var stringFormat = new StringFormat())
            {
                stringFormat.Alignment = StringAlignment.Center;

                foreach (var text in LeftToRightLabels)
                {
                    graphics.DrawString(text, Font, Brushes.Gray, x, y, stringFormat);
                    x += LabelWidth;
                }

                x = position.X + RootX;
                foreach (var text in RightToLeftLabels)
                {
                    graphics.DrawString(text, Font, Brushes.Gray, x, y, stringFormat);
                    x -= LabelWidth;
                }
            }
        }
    }
}