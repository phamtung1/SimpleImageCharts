using System;
using GdiSharp.Components;
using SimpleImageCharts.Core.GdiChartComponents;
using SimpleImageCharts.Core.Models;

namespace SimpleImageCharts.BarChart.GdiComponents
{
    public class GdiBarChartDataArea : GdiHozDataArea
    {
        public BarSettingModel BarSettingModel { get; set; }

        public float WidthUnit { get; set; }

        public BarSeries[] DataSet { get; set; }

        public override void BeforeRendering()
        {
            base.BeforeRendering();

            var offsetY = BarSettingModel.IsStacked ? -BarSettingModel.Size / 2 : -(DataSet.Length * BarSettingModel.Size) / 2;
            foreach (var data in DataSet)
            {
                AddBarSeries(data, offsetY);
                if (!BarSettingModel.IsStacked)
                {
                    offsetY += BarSettingModel.Size;
                }
            }
        }

        private void AddBarSeries(BarSeries series, int offsetY)
        {
            var y = (CellHeight / 2) + offsetY;

            foreach (var value in series.Data)
            {
                var length = WidthUnit * value;
                var bar = new GdiRectangle
                {
                    Y = y,
                    Height = BarSettingModel.Size,
                    Color = series.Color,
                    Width = Math.Abs(length)
                };
                var text = new GdiText
                {
                    Content = string.Format(BarSettingModel.FormatValue, value),
                    Font = BarSettingModel.ValueFont,
                    Color = System.Drawing.Color.Gray,
                    X = bar.Width + 2,
                    VerticalAlignment = GdiSharp.Enum.GdiVerticalAlign.Middle
                };

                if (length > 0)
                {
                    bar.X = RootX;
                }
                else if (length < 0)
                {
                    bar.X = Width - RootX;
                    bar.HorizontalAlignment = GdiSharp.Enum.GdiHorizontalAlign.Right;
                    text.HorizontalAlignment = GdiSharp.Enum.GdiHorizontalAlign.Right;
                }

                bar.AddChild(text);
                this.AddChild(bar);

                y += CellHeight;
            }
        }
    }
}