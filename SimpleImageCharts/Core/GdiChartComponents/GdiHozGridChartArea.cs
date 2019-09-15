using System.Drawing;
using GdiSharp.Components;
using SimpleImageCharts.Core.Helpers;
using SimpleImageCharts.Core.Models;

namespace SimpleImageCharts.Core.GdiChartComponents
{
    public class GdiHozGridChartArea : GdiHozSplitContainer
    {
        public SizeF CellSize { get; set; }

        public ChartGridModel ChartGridModel { get; set; }

        public override void BeforeRendering()
        {
            base.BeforeRendering();
            CreateLeftGrid();
            CreateRightGrid();
        }

        private void CreateLeftGrid()
        {
            if (LeftPanel != null)
            {
                var leftGrid = GdiMapper.ToGdiGrid(ChartGridModel);
                leftGrid.CellSize = CellSize;
                leftGrid.Size = LeftPanel.Size;
                leftGrid.IsDrawnFromRightToLeft = true;

                LeftPanel.AddChild(leftGrid);
            }
        }

        private void CreateRightGrid()
        {
            if (RightPanel != null)
            {
                var rightGrid = GdiMapper.ToGdiGrid(ChartGridModel);
                rightGrid.CellSize = CellSize;
                rightGrid.Size = RightPanel.Size;

                RightPanel.AddChild(rightGrid);
            }
        }

        public override void Render(Graphics graphics)
        {
            base.Render(graphics);
            var position = GetAbsolutePosition(graphics);

            // Draw root X axis
            graphics.DrawLine(Pens.LightGray, position.X + LeftPanelWidth, position.Y, position.X + LeftPanelWidth, position.Y + Size.Height);
        }
    }
}