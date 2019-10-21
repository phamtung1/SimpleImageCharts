using GdiSharp.Components;
using GdiSharp.Models;
using SimpleImageCharts.Core.Models;
using System.Drawing;
using System.Linq;

namespace SimpleImageCharts.Core.GdiChartComponents
{
    public class GdiLegend : GdiRectangle
    {
        public LegendModel Legend { get; set; }

        public override void BeforeRendering(Graphics graphics)
        {
            base.BeforeRendering(graphics);
            if (Legend == null || Legend.Items == null || !Legend.Items.Any())
            {
                return;
            }

            var size = GetLegendItemsSize(graphics);
            var itemContainer = new GdiRectangle
            {
                Size = size,
                HorizontalAlignment = GdiSharp.Enum.GdiHorizontalAlign.Center,
                Margin = new PointF(0, 10)
            };
            var legendSlimFont = new SlimFont(Legend.FontName, Legend.FontSize);
            using (var font = new Font(Legend.FontName, Legend.FontSize))
            {
                var x = 0f;
                var line = 0;
                foreach (var item in Legend.Items)
                {
                    var textWidth = graphics.MeasureString(item.Text, font).Width;
                    var itemWidth = GdiLegendItem.RectWidth + GdiLegendItem.GapWidth + textWidth + GdiLegendItem.GapWidth;
                    if (x + itemWidth > itemContainer.Size.Width + 1)
                    {
                        x = 0f;
                        line++;
                    }

                    itemContainer.AddChild(new GdiLegendItem
                    {
                        Margin = new PointF(x, line * GdiLegendItem.LineHeight),
                        Size = new SizeF(itemWidth, GdiLegendItem.RectHeight),
                        Text = item.Text,
                        RectangleColor = item.Color,
                        Font = legendSlimFont
                    });
                    x += itemWidth;
                }
            }
            this.AddChild(itemContainer);
        }

        private SizeF GetLegendItemsSize(Graphics graphics)
        {
            var maxWidth = 0f;
            var left = 0f;
            var line = 1;
            using (var font = new Font(Legend.FontName, Legend.FontSize))
            {
                foreach (var item in Legend.Items)
                {
                    var textWidth = graphics.MeasureString(item.Text, font).Width;
                    var itemWidth = GdiLegendItem.RectWidth + GdiLegendItem.GapWidth + textWidth + GdiLegendItem.GapWidth;
                    if (left + itemWidth > this.Size.Width)
                    {
                        left = 0;
                        maxWidth = this.Size.Width;
                        line++;
                    }
                    else
                    {
                        left += itemWidth;
                        if (maxWidth < left)
                        {
                            maxWidth = left;
                        }
                    }
                }
            }

            return new SizeF(maxWidth, line * GdiLegendItem.LineHeight);
        }
    }
}