using GdiSharp.Components.Base;
using SimpleImageCharts.Core.GdiChartComponents;
using SimpleImageCharts.Core.Models;
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

        protected virtual void AddLegend(GdiContainer container)
        {
            if (Legend == null || Legend.Items == null || !Legend.Items.Any())
            {
                return;
            }

            container.AddChild(new GdiLegend
            {
                Legend = Legend,
            });
        }
    }
}