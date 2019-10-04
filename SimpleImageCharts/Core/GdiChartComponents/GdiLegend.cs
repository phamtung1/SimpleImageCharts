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
        private const int GapWidth = 10;

        public LegendModel Legend { get; set; }

        protected override SizeF GetComponentSize(Graphics graphics)
        {
            var totalWidth = 0f;
            using (var font = new Font(Legend.FontName, Legend.FontSize))
            {
                foreach (var item in Legend.Items)
                {
                    totalWidth += graphics.MeasureString(item.Text, font).Width + RectWidth + 5 + GapWidth;
                }
            }

            var height = RectHeight + 5;
            return new SizeF(totalWidth, height);
        }

        public override void Render(Graphics graphics)
        {
            if (Legend == null || Legend.Items == null || !Legend.Items.Any())
            {
                return;
            }

            this.Margin = Legend.Margin;
            this.HorizontalAlignment = GdiMapper.ToGdiHorizontalAlign(Legend.HorizontalAlign);
            this.VerticalAlignment = GdiMapper.ToGdiVerticalAlign(Legend.VerticalAlign);

            var position = GetAbsolutePosition(graphics);

            var left = position.X;
            var top = position.Y;

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

                    var textWidth = graphics.MeasureString(item.Text, font).Width;
                    left += RectWidth + 5 + textWidth + GapWidth;
                }
            }
        }
    }
}