using System.Drawing;
using GdiSharp.Components;
using SimpleImageCharts.Core.Helpers;
using SimpleImageCharts.Core.Models;

namespace SimpleImageCharts.Core.GdiChartComponents
{
    public class GdiHozDataArea : GdiRectangle
    {
        public float RootX { get; set; } = 0;

        public float MinValue { get; set; } = 0;

        public float MaxValue { get; set; } = 0;

        public float CellWidth { get; set; } = 0;

        public float CellHeight { get; set; } = 0;

        public ChartGridModel ChartGridModel { get; set; }

        public override void BeforeRendering()
        {
            base.BeforeRendering();
            if (RootX > 0)
            {
                var leftGrid = GdiMapper.ToGdiGrid(ChartGridModel);
                leftGrid.CellHeight = CellHeight;
                leftGrid.CellWidth = CellWidth;
                leftGrid.Height = this.Height;
                leftGrid.Width = RootX;
                leftGrid.IsDrawnFromRightToLeft = true;

                this.AddChild(leftGrid);
            }

            if (RootX < Width)
            {
                var rightGrid = GdiMapper.ToGdiGrid(ChartGridModel);
                rightGrid.CellHeight = CellHeight;
                rightGrid.CellWidth = CellWidth;
                rightGrid.Height = this.Height;
                rightGrid.Width = this.Width - RootX;
                rightGrid.MarginLeft = RootX;

                this.AddChild(rightGrid);
            }
        }

        public override void Render(Graphics graphics)
        {
            base.Render(graphics);
            var position = GetAbsolutePosition(graphics);

            // Draw root X axis
            graphics.DrawLine(Pens.LightGray, position.X + RootX, position.Y, position.X + RootX, position.Y + Height);
        }
    }
}