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

        public SizeF CellSize { get; set; }

        public ChartGridModel ChartGridModel { get; set; }

        public override void BeforeRendering()
        {
            base.BeforeRendering();
            if (RootX > 0)
            {
                var leftGrid = GdiMapper.ToGdiGrid(ChartGridModel);
                leftGrid.CellSize = CellSize;
                leftGrid.Size = new SizeF(RootX, this.Size.Height);
                leftGrid.IsDrawnFromRightToLeft = true;

                this.AddChild(leftGrid);
            }

            if (RootX < Size.Width)
            {
                var rightGrid = GdiMapper.ToGdiGrid(ChartGridModel);
                rightGrid.CellSize = CellSize;
                rightGrid.Size = new SizeF(this.Size.Width - RootX, this.Size.Height);
                rightGrid.Position = new PointF(RootX, 0);

                this.AddChild(rightGrid);
            }
        }

        public override void Render(Graphics graphics)
        {
            base.Render(graphics);
            var position = GetAbsolutePosition(graphics);

            // Draw root X axis
            graphics.DrawLine(Pens.LightGray, position.X + RootX, position.Y, position.X + RootX, position.Y + Size.Height);
        }
    }
}