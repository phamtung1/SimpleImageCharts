using GdiSharp.Components;
using GdiSharp.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SimpleImageCharts.Core.GdiChartComponents
{
    public class GdiLegendItem : GdiRectangle
    {
        internal const int RectWidth = 25;
        internal const int RectHeight = 15;
        internal const int GapWidth = 10;
        internal const int LineHeight = 25;

        public string Text { get; set; }

        public Color RectangleColor { get; set; }

        public SlimFont Font { get; set; }

        public override void BeforeRendering(Graphics graphics)
        {
            base.BeforeRendering(graphics);
            this.AddChild(new GdiRectangle
            {
                BackgroundColor = RectangleColor,
                Size = new SizeF(RectWidth, RectHeight)
            });
            this.AddChild(new GdiText
            {
                Content = Text,
                Font = Font,
                Margin = new PointF(RectWidth + GapWidth, 0)
            });
        }
    }
}
