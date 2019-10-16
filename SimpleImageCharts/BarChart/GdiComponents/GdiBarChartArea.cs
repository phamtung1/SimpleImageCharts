using System;
using System.Drawing;
using GdiSharp.Components;
using GdiSharp.Models;
using SimpleImageCharts.Core.GdiChartComponents;
using SimpleImageCharts.Core.Models;

namespace SimpleImageCharts.BarChart.GdiComponents
{
    public class GdiBarChartArea : GdiHozGridChartArea
    {
        public BarSettingModel BarSettingModel { get; set; }

        public float WidthUnit { get; set; }

        public DataSeries[] DataSet { get; set; }

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

        private void AddBarSeries(DataSeries series, int offsetY)
        {
            var y = (CellSize.Height / 2) + offsetY;

            foreach (var value in series.Data)
            {
                var length = WidthUnit * value;

                var bar = new GdiRectangle
                {
                    Size = new SizeF(Math.Abs(length), BarSettingModel.Size),
                    Margin = new PointF(0, y),
                    Color = series.Color,
                };

                var text = new GdiText
                {
                    Margin = new PointF(bar.Size.Width + 2, 0),
                    Content = string.Format(BarSettingModel.FormatValue, value),
                    Font = BarSettingModel.ValueFont,
                    Color = Color.Gray,
                    VerticalAlignment = GdiSharp.Enum.GdiVerticalAlign.Middle
                };

                if (length > 0)
                {
                    RightPanel.AddChild(bar);
                }
                else if (length < 0)
                {
                    LeftPanel.AddChild(bar);
                    bar.HorizontalAlignment = GdiSharp.Enum.GdiHorizontalAlign.Right;
                    text.HorizontalAlignment = GdiSharp.Enum.GdiHorizontalAlign.Right;
                }

                bar.AddChild(text);

                y += CellSize.Height;
            }
        }
    }
}