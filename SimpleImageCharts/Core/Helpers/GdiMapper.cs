using GdiSharp.Components;
using GdiSharp.Enum;
using SimpleImageCharts.Core.Models;
using SimpleImageCharts.Enum;
using System.Collections.Generic;

namespace SimpleImageCharts.Core.Helpers
{
    public static class GdiMapper
    {
        private static readonly IDictionary<HorizontalAlign, GdiHorizontalAlign> HorizontalAlignMap = new Dictionary<HorizontalAlign, GdiHorizontalAlign>
        {
            { HorizontalAlign.Center, GdiHorizontalAlign.Center },
            { HorizontalAlign.Left, GdiHorizontalAlign.Left },
            { HorizontalAlign.Right, GdiHorizontalAlign.Right },
        };

        private static readonly IDictionary<VerticalAlign, GdiVerticalAlign> VerticalAlignMap = new Dictionary<VerticalAlign, GdiVerticalAlign>
        {
            { VerticalAlign.Bottom, GdiVerticalAlign.Bottom },
            { VerticalAlign.Middle, GdiVerticalAlign.Middle },
            { VerticalAlign.Top, GdiVerticalAlign.Top },
        };

        public static GdiGrid ToGdiGrid(ChartGridModel chartGrid)
        {
            return new GdiGrid
            {
                LineColor = chartGrid.LineColor,
                LineWidth = chartGrid.LineWidth,
                ColumnLinesVisible = chartGrid.ColumnLinesVisible,
                RowLinesVisible = chartGrid.RowLinesVisible
            };
        }

        public static GdiHorizontalAlign ToGdiHorizontalAlign(HorizontalAlign align)
        {
            return HorizontalAlignMap[align];
        }

        public static GdiVerticalAlign ToGdiVerticalAlign(VerticalAlign align)
        {
            return VerticalAlignMap[align];
        }
    }
}