using GdiSharp.Components;
using GdiSharp.Components.Base;
using SimpleImageCharts.Core;
using SimpleImageCharts.Core.Models;
using SimpleImageCharts.SingleRangeBarChart.GdiComponents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SimpleImageCharts.SingleRangeBarChart
{
    public class SingleRangeBarChart : BaseChart
    {
        public float MinValue { get; set; }

        public float MaxValue { get; set; }

        public string LeftLabel { get; set; }

        public string CenterLabel { get; set; }

        public string RightLabel { get; set; }

        public Color TextColor { get; set; }

        public IEnumerable<SingleRangeBarEntry> Entries { get; set; }

        public SingleRangeBarChart()
        {
            Padding = new Padding(50, 10, 60, 30);
        }

        protected override void Init(GdiContainer mainContainer, GdiRectangle chartContainer)
        {
            base.Init(mainContainer, chartContainer);
            if (MaxValue <= 0 || MaxValue <= MinValue)
            {
                throw new ArgumentException("Invalid range value!");
            }

            if (Entries == null || !Entries.Any())
            {
                throw new ArgumentException("Invalid entries!");
            }
        }

        protected override void BuildComponents(GdiContainer mainContainer, GdiRectangle chartContainer)
        {
            base.BuildComponents(mainContainer, chartContainer);

            var rangeBar = AddRangeBar(chartContainer);
            AddLabels(chartContainer, rangeBar);
        }

        private GdiRangeBar AddRangeBar(GdiRectangle chartContainer)
        {
            var rangeBar = new GdiRangeBar
            {
                Size = new SizeF(chartContainer.Size.Width, chartContainer.Size.Height / 3),
                Margin = new PointF(0, chartContainer.Size.Height / 3),
                Color = ColorTranslator.FromHtml("#123367"),
                CenterColor = ColorTranslator.FromHtml("#BDD2F3")
            };
            chartContainer.AddChild(rangeBar);

            var onePercentWidth = rangeBar.Size.Width / 100; // bar is 100% width

            var columnHeight = rangeBar.Size.Height * 1.2f;
            var columnTop = rangeBar.Margin.Y - ((columnHeight - rangeBar.Size.Height) / 2);
            var rangeValue = MaxValue - MinValue;

            foreach (var entry in Entries)
            {
                var x = (entry.Value - MinValue) / rangeValue * 100 * onePercentWidth;

                var column = new GdiRectangle
                {
                    Color = entry.Color,
                    Size = new SizeF(10, columnHeight),
                    Margin = new PointF(x - 5, columnTop)
                };
                chartContainer.AddChild(column);
            }

            return rangeBar;
        }

        public void AddLabels(GdiRectangle chartContainer, GdiRangeBar rangeBar)
        {
            var margin = new PointF(0, rangeBar.Margin.Y + rangeBar.Size.Height + 10);
            if (!string.IsNullOrWhiteSpace(LeftLabel))
            {
                chartContainer.AddChild(new GdiText
                {
                    Color = TextColor,
                    Content = LeftLabel,
                    Font = Font,
                    Margin = margin
                });
            }

            if (!string.IsNullOrWhiteSpace(CenterLabel))
            {
                chartContainer.AddChild(new GdiText
                {
                    Color = TextColor,
                    Content = CenterLabel,
                    Font = Font,
                    HorizontalAlignment = GdiSharp.Enum.GdiHorizontalAlign.Center,
                    Margin = margin
                });
            }

            if (!string.IsNullOrWhiteSpace(RightLabel))
            {
                chartContainer.AddChild(new GdiText
                {
                    Color = TextColor,
                    Content = RightLabel,
                    Font = Font,
                    HorizontalAlignment = GdiSharp.Enum.GdiHorizontalAlign.Right,
                    Margin = margin,
                    IsTextAlignRight = true
                });
            }
        }
    }
}