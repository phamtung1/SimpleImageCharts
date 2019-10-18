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
    public class GdiStackedColumn100ChartArea : GdiRectangle
    {
        public SizeF CellSize { get; set; }

        public ChartGridModel ChartGridModel { get; set; }

        public BarSettingModel BarSettingModel { get; set; }

        public DataSeries[] DataSet { get; set; }

        public override void BeforeRendering()
        {
            base.BeforeRendering();
            CreateGrid();

            var offsetX = (CellSize.Width - BarSettingModel.Size) / 2f;

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

                var column = new Gdi100StackedColumn
                {
                    Size = new SizeF(BarSettingModel.Size, this.Size.Height),
                    Margin = new PointF(offsetX, 0),
                    Colors = colors,
                    Values = values.ToArray()
                };

                this.AddChild(column);

                offsetX += CellSize.Width;
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