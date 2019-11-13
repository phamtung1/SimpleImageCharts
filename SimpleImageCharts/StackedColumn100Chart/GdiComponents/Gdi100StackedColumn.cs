using GdiSharp.Components;
using GdiSharp.Models;
using System;
using System.Drawing;
using System.Linq;

namespace SimpleImageCharts.StackedBar100Chart.GdiComponents
{
    public class Gdi100StackedColumn : GdiRectangle
    {
        private const string TextFormat = "{0:#.##}%";

        public float[] Values { get; set; }

        public Color[] Colors { get; set; }

        public Color[] TextColors { get; set; }

        public override void BeforeRendering(Graphics graphics)
        {
            base.BeforeRendering(graphics);
            if (Values.Length != Colors.Length || Values.Length != TextColors.Length)
            {
                throw new ArgumentException("Values and Colors must have the same number of items.");
            }

            var sum = this.Values.Sum();
            if(sum == 0)
            {
                return;
            }

            var size = this.Size;
            var pixelUnit = size.Height / 100;
            
            var y = size.Height;
            var font = SlimFont.Default;
            font.Size = 10;
            for (int i = 0; i < Values.Length; i++)
            {
                var percent = Values[i] / sum * 100;
                if (percent <= 0.1)
                {
                    continue;
                }

                var height = percent * pixelUnit;
                var section = new GdiRectangle
                {
                    BackgroundColor = Colors[i],
                    Margin = new PointF(0, y - height),
                    Size = new SizeF(size.Width, height)
                };

                if (i < Values.Length - 1)
                {
                    section.AddChild(new GdiHozLine
                    {
                        Length = size.Width,
                        BackgroundColor = Color.White,
                        LineHeight = 2
                    });
                }

                var text = new GdiText
                {
                    Content = string.Format(TextFormat, percent),
                    HorizontalAlignment = GdiSharp.Enum.GdiHorizontalAlign.Center,
                    VerticalAlignment = GdiSharp.Enum.GdiVerticalAlign.Middle,
                    Font = font,
                    TextColor = TextColors[i]
                };

                // move the text outside the column
                if (percent <= 2)
                {
                    text.Margin = new PointF(size.Width, 0);
                    text.HorizontalAlignment = GdiSharp.Enum.GdiHorizontalAlign.Left;
                    text.TextColor = Color.Black;
                }

                section.AddChild(text);

                this.AddChild(section);

                y -= height;
            }
        }
    }
}