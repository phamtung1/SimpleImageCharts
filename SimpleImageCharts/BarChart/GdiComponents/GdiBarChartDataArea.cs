using System;
using System.Drawing;
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
            var y = (CellSize.Height / 2) + offsetY;

            foreach (var value in series.Data)
            {
                var length = WidthUnit * value;
                var barPosition = new PointF(0, y);

                var bar = new GdiRectangle
                {
                    Size = new SizeF(Math.Abs(length), BarSettingModel.Size),
                    Color = series.Color,
                };

                var textPosition = new PointF(bar.Size.Width + 2, 0);
                var text = new GdiText
                {
                    Content = string.Format(BarSettingModel.FormatValue, value),
                    Font = BarSettingModel.ValueFont,
                    Color = Color.Gray,
                    VerticalAlignment = GdiSharp.Enum.GdiVerticalAlign.Middle
                };

                if (length > 0)
                {
                    barPosition.X = RootX;
                }
                else if (length < 0)
                {
                    barPosition.X = -(Size.Width - RootX);
                    bar.HorizontalAlignment = GdiSharp.Enum.GdiHorizontalAlign.Right;
                    textPosition.X = -textPosition.X;
                    text.HorizontalAlignment = GdiSharp.Enum.GdiHorizontalAlign.Right;
                }

                bar.Position = barPosition;
                text.Position = textPosition;
                bar.AddChild(text);
                this.AddChild(bar);

                y += CellSize.Height;
            }
        }
    }
}