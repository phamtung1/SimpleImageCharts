using SimpleImageCharts.Core.Components;
using System.Drawing;
using System.Linq;

namespace SimpleImageCharts.Core
{
    public abstract class BaseChart
    {
        public int Width { get; set; } = 500;

        public int Height { get; set; } = 500;

        public int MarginRight { get; set; } = 30;

        public int MarginTop { get; set; } = 30;

        public int MarginBottom { get; set; } = 30;

        public int MarginLeft { get; set; } = 30;

        public SubTitle SubTitle { get; set; }

        public Legend Legend { get; set; }

        protected virtual void DrawSubTitle(Graphics graphics)
        {
            if (SubTitle == null || string.IsNullOrWhiteSpace(SubTitle.Text))
            {
                return;
            }

            using (var brush = new SolidBrush(SubTitle.Color))
            using (var font = new Font(SubTitle.FontName, SubTitle.FontSize, FontStyle.Bold))
            using (var stringFormat = new StringFormat())
            {
                stringFormat.Alignment = StringAlignment.Center;
                var x = MarginLeft + (Width - MarginLeft - MarginRight) / 2;

                graphics.DrawString(SubTitle.Text, font, brush, x, Height - 30, stringFormat);
            }
        }

        protected virtual void DrawLegend(Graphics graphic)
        {
            if (Legend == null || Legend.Items == null || !Legend.Items.Any())
            {
                return;
            }

            const int RectWidth = 25;
            const int RectHeight = 15;

            const int labelWidth = 130;
            var legendWidth = labelWidth * Legend.Items.Count();
            var legendHeight = RectHeight + 5;

            // currently only support legend at center-bottom position
            var left = MarginLeft + (Width - MarginLeft - MarginRight - legendWidth) / 2 + RectWidth + Legend.MarginLeft;
            var top = Height - legendHeight + Legend.MarginTop;

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
                        graphic.FillRectangle(brush, left, top, RectWidth, RectHeight);
                        graphic.DrawString(item.Text, font, textBrush, left + RectWidth + 5, top);
                    }

                    left += labelWidth;
                }
            }
        }
    }
}