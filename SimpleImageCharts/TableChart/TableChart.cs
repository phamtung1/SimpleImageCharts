using GdiSharp.Components;
using GdiSharp.Components.Base;
using GdiSharp.Components.DataGrid;
using SimpleImageCharts.Core;
using System.Collections.Generic;
using System.Drawing;

namespace SimpleImageCharts.TableChart
{
    public class TableChart : BaseChart, ITableChart
    {
        public Color LineColor { get; set; } = Color.LightGray;

        public int LineWidth { get; set; } = 1;

        public int Rows { get; set; }

        public int Columns { get; set; }

        public IEnumerable<DataGridMergedCell> MergedCells { get; set; }

        public string[][] Texts { get; set; }

        public Color TextColor { get; set; } = Color.Black;

        protected override void BuildComponents(GdiContainer mainContainer, GdiRectangle chartContainer)
        {
            base.BuildComponents(mainContainer, chartContainer);
            var table = new GdiDataGrid
            {
                Size = chartContainer.Size,
                LineColor = Color.Gray,
                Rows = Rows,
                Columns = Columns,
                MergedCells = MergedCells,
                Texts = Texts,
                TextColor = TextColor
            };

            chartContainer.AddChild(table);
        }
    }
}