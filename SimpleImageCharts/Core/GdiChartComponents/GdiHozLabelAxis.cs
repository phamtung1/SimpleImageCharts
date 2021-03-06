﻿using GdiSharp.Components;
using GdiSharp.Models;
using System.Drawing;

namespace SimpleImageCharts.Core.GdiChartComponents
{
    public class GdiHozLabelAxis : GdiRectangle
    {
        public string[] LeftToRightLabels { get; set; }

        public string[] RightToLeftLabels { get; set; }

        public float LabelWidth { get; set; }

        public float LabelOffsetX { get; set; }

        public float LabelOffsetY { get; set; }

        public SlimFont Font { get; set; }

        public float RootX { get; set; }

        public override void Render(Graphics graphics)
        {
            base.Render(graphics);

            var position = GetAbsolutePosition(graphics);
            var x = position.X + RootX + LabelOffsetX;
            var y = position.Y + LabelOffsetY;

            using (var stringFormat = new StringFormat())
            using (var font = Font.ToFatFont())
            {
                stringFormat.Alignment = StringAlignment.Center;

                if (LeftToRightLabels != null)
                {
                    foreach (var text in LeftToRightLabels)
                    {
                        graphics.DrawString(text, font, Brushes.Gray, x, y, stringFormat);
                        x += LabelWidth;
                    }
                }

                if (RightToLeftLabels != null)
                {
                    x = position.X + RootX;
                    foreach (var text in RightToLeftLabels)
                    {
                        graphics.DrawString(text, font, Brushes.Gray, x, y, stringFormat);
                        x -= LabelWidth;
                    }
                }
            }
        }
    }
}