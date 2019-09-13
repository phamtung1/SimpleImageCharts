using GdiSharp.Components;
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

        protected virtual void AddSubTitle(GdiContainer container)
        {
            if (SubTitle == null || string.IsNullOrWhiteSpace(SubTitle.Text))
            {
                return;
            }

            var gdiText = new GdiText
            {
                Content = SubTitle.Text,
                Color = SubTitle.Color,
                HorizontalAlignment = GdiSharp.Enum.GdiHorizontalAlign.Center,
                VerticalAlignment = GdiSharp.Enum.GdiVerticalAlign.Bottom,
                Y = 10,
                Font = new Font(SubTitle.FontName, SubTitle.FontSize, FontStyle.Bold)
            };
            container.AddChild(gdiText);
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