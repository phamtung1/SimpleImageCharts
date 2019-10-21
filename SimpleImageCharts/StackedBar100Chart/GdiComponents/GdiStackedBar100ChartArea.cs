using GdiSharp.Components;
using SimpleImageCharts.BarChart;
using SimpleImageCharts.Core.Helpers;
using SimpleImageCharts.Core.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SimpleImageCharts.StackedBar100Chart.GdiComponents
{
    public class GdiStackedBar100ChartArea : GdiRectangle
    {
        public SizeF CellSize { get; set; }

        public ChartGridModel ChartGridModel { get; set; }

        public BarSettingModel BarSettingModel { get; set; }

        public DataSeries[] DataSet { get; set; }

        public override void BeforeRendering(Graphics graphics)
        {
            base.BeforeRendering(graphics);
            CreateGrid();

            var offsetY = (CellSize.Height - BarSettingModel.Size) / 2f;

            // render bars one by one
            var categoriesLength = DataSet.First().Data.Length;
            var colors = DataSet.Select(x => x.Color).ToArray();

            for (int i = 0; i < categoriesLength; i++)
            {
                var values = new List<float>();
                foreach (var item in DataSet)
                {
                    values.Add(item.Data[i]);
                }

                var bar = new Gdi100StackedBar
                {
                    Size = new SizeF(this.Size.Width, BarSettingModel.Size),
                    Margin = new PointF(0, offsetY),
                    Colors = colors,
                    Values = values.ToArray()
                };

                this.AddChild(bar);

                offsetY += CellSize.Height;
            }
        }

        private void CreateGrid()
        {
            var grid = GdiMapper.ToGdiGrid(ChartGridModel);
            grid.Border = new GdiSharp.Models.Border(1);
            grid.CellSize = CellSize;
            grid.Size = this.Size;

            this.AddChild(grid);
        }
    }
}