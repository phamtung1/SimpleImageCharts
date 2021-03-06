﻿using GdiSharp.Components;
using GdiSharp.Models;
using System.Drawing;

namespace SimpleImageCharts.Core.GdiChartComponents
{
    public class GdiColumn : GdiRectangle
    {
        public SlimFont Font { get; set; }

        public string Text { get; set; }

        public Color TextColor { get; set; } = Color.Black;

        public override void BeforeRendering(Graphics graphics)
        {
            base.BeforeRendering(graphics);

            if (!string.IsNullOrWhiteSpace(Text))
            {
                this.AddChild(new GdiText
                {
                    BackgroundColor = TextColor,
                    Font = this.Font,
                    Content = Text,
                    Margin = new PointF(0, -20),
                    HorizontalAlignment = GdiSharp.Enum.GdiHorizontalAlign.Center,
                    TextAlign = StringAlignment.Center
                });
            }
        }
    }
}