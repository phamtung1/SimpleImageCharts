using GdiSharp.Components.DataGrid;
using SimpleImageCharts.TableChart;
using System.Collections.Generic;
using System.Drawing;

namespace WindowsFormsChart.Charts
{
    public static class TableChartCreator
    {
        public static TableChart CreateChart(Size size)
        {
            var chart = new TableChart
            {
                Size = size,
                LineColor = Color.Cyan,
                Rows = 10,
                Columns = 10,
                MergedCells = new List<DataGridMergedCell>
                {
                    new DataGridMergedCell(1, 1, 3, 3)
                },
                Texts = new string[][]
                {
                    new []{ "1", "1", "1" },
                    new []{ "1", "1", "", "", "1" },
                }
            };

            return chart;
        }
    }
}