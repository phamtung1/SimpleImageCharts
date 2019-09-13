using GdiSharp.Components.Base;
using SimpleImageCharts.Core.Helpers;
using SimpleImageCharts.Core.Models;
using System.Drawing;
using System.Linq;

namespace SimpleImageCharts.Core.GdiChartComponents
{
    public class GdiLegend : GdiComponent
    {
        private const int RectWidth = 25;
        private const int RectHeight = 15;
        private const int LabelWidth = 130;

        public Legend Legend { get; set; }

        protected override SizeF GetComponentSize(Graphics graphics)
        {
            var width = LabelWidth * Legend.Items.Count();
            var height = RectHeight + 5;
            return new SizeF(width, height);
        }

        public override void Render(Graphics graphics)
        {
            if (Legend == null || Legend.Items == null || !Legend.Items.Any())
            {
                return;
            }

            this.HorizontalAlignment = GdiMapper.ToGdiHorizontalAlign(Legend.HorizontalAlign);
            this.VerticalAlignment = GdiMapper.ToGdiVerticalAlign(Legend.VerticalAlign);

            var position = GetAbsolutePosition(graphics);

            var left = position.X + Legend.MarginLeft;
            var top = position.Y + Legend.MarginTop;

            using (var textBrush = new SolidBrush(Legend.TextColor))
            using (var font = new Font(Legend.FontName, Legend.FontSize))
            {
                foreach (var item in Legend.Items)
                {
                    if (string.IsNullOrEmpty(item.Text))
                    {
                        continue;
                    }

                    using (var brush = new SolidBrush(item.Color))
                    {
                        graphics.FillRectangle(brush, left, top, RectWidth, RectHeight);
                        graphics.DrawString(item.Text, font, textBrush, left + RectWidth + 5, top);
                    }

                    left += LabelWidth;
                }
            }
        }
    }
}