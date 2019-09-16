using System;
using System.Drawing;
using System.Linq;
using GdiSharp.Components;
using GdiSharp.Components.Base;
using SimpleImageCharts.Core;
using SimpleImageCharts.Core.Helpers;
using SimpleImageCharts.Enum;
using SimpleImageCharts.PieChart.GdiComponents;

namespace SimpleImageCharts.PieChart
{
    public class PieChart : BaseChart, IPieChart
    {
        public string LabelFormat { get; set; } = "{0}";

        public PieEntry[] Entries { get; set; }

        public Color BorderColor { get; set; } = Color.White;

        public byte BorderWidth { get; set; } = 2;

        public Color TextColor { get; set; } = Color.White;

        public bool IsDonut { get; set; } = false;

        public Action<Graphics> AfterDraw { get; set; }

        public HorizontalAlign PieAlign { get; set; } = HorizontalAlign.Left;

        public PieChart()
        {
            Size = new Size(600, 300);
            Padding = new Core.Models.Padding(5);
        }

        protected override void Init(GdiContainer mainContainer, GdiRectangle chartContainer)
        {
            base.Init(mainContainer, chartContainer);

            if (Entries == null || Entries.Length == 0)
            {
                throw new ArgumentException("Invalid entries data");
            }
        }

        protected override void BuildComponents(GdiContainer mainContainer, GdiRectangle chartContainer)
        {
            base.BuildComponents(mainContainer, chartContainer);
            var pie = new GdiPie
            {
                Diameter = chartContainer.Size.Height,
                Entries = Entries,
                IsDonut = IsDonut,
                HorizontalAlignment = GdiMapper.ToGdiHorizontalAlign(this.PieAlign),
                TextColor = TextColor,
                LabelFormat = LabelFormat,
                Font = Font
            };
            chartContainer.AddChild(pie);
        }

        protected override void Draw(Graphics graphics)
        {
            base.Draw(graphics);

            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            float total = Entries.Sum(x => x.Value);
            DrawLegend(graphics);

            if (AfterDraw != null)
            {
                AfterDraw(graphics);
            }
        }

        private void DrawLegend(Graphics graphic)
        {
            graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            const int BoxWidth = 25;
            const int BoxHeight = 15;
            const int LineHeight = 20;

            var left = PieAlign == HorizontalAlign.Left ? this.Size.Height + 40 : Size.Width - Size.Height - 150;
            var top = 20;

            using (var textBrush = new SolidBrush(Color.FromArgb(70, 70, 70)))
            using (var font = Font.ToFatFont())
            {
                foreach (var entry in Entries)
                {
                    using (var brush = new SolidBrush(entry.Color))
                    {
                        graphic.FillRectangle(brush, left, top, BoxWidth, BoxHeight);
                        graphic.DrawString(entry.Name, font, textBrush, left + BoxWidth + 5, top);
                    }

                    top += LineHeight;
                }
            }

            graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }
    }
}