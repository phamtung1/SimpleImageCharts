using System.Drawing;
using System.Linq;
using GdiSharp.Components;
using GdiSharp.Components.Base;
using SimpleImageCharts.Core;
using SimpleImageCharts.Core.GdiChartComponents;
using SimpleImageCharts.Core.Models;
using SimpleImageCharts.StackedBar100Chart.GdiComponents;

namespace SimpleImageCharts.StackedColumn100Chart
{
    public class StackedColumn100Chart : BaseChart, IStackedColumn100Chart
    {
        public BarSettingModel BarSetting { get; set; } = new BarSettingModel();

        public string FormatAxisValue { get; set; } = "{0}%";

        public int StepSize { get; set; } = 20;

        public string[] Categories { get; set; }

        public DataSeries[] DataSet { get; set; }

        private float _categoryWidth;

        private float _heightUnit;

        public ChartGridModel ChartGridModel { get; set; }

        private GdiStackedColumn100ChartArea _barChartArea;

        public StackedColumn100Chart()
        {
            this.Size = new Size(600, 300);
            Padding = new Padding(100, 10, 30, 100);
        }

        protected override void Init(GdiContainer mainContainer, GdiRectangle chartContainer)
        {
            base.Init(mainContainer, chartContainer);
            _categoryWidth = chartContainer.Size.Width / Categories.Length;

            _heightUnit = chartContainer.Size.Height / 100;
            this.LegendHeight = Padding.Bottom - 50;
        }

        protected override void BuildComponents(GdiContainer mainContainer, GdiRectangle chartContainer)
        {
            base.BuildComponents(mainContainer, chartContainer);
            AddChartArea(chartContainer);
            AddVerLabelAxis(mainContainer, chartContainer);
            AddHozLabelAxis(mainContainer, chartContainer);
        }

        protected override void CreateLegendItems()
        {
            Legend.Items = DataSet.Select(x => new LegendItemModel
            {
                Text = x.Label,
                Color = x.Color
            }).ToArray();
        }

        private void AddChartArea(GdiRectangle chartArea)
        {
            if (ChartGridModel == null)
            {
                ChartGridModel = new ChartGridModel
                {
                    LineColor = Color.LightGray
                };
            }

            _barChartArea = new GdiStackedColumn100ChartArea
            {
                Size = chartArea.Size,
                CellSize = new SizeF(_categoryWidth, _heightUnit * StepSize),
                ChartGridModel = ChartGridModel,
                BarSettingModel = BarSetting,
                DataSet = DataSet
            };
            chartArea.AddChild(_barChartArea);
        }

        private void AddVerLabelAxis(GdiContainer mainContainer, GdiRectangle chartContainer)
        {
            var labels = Enumerable.Range(0, 100 / StepSize + 1)
                .Select(x => string.Format(FormatAxisValue, x * StepSize)).Reverse().ToArray();

            var labelHeight = _heightUnit * StepSize;
            mainContainer.AddChild(new GdiVerLabelAxis
            {
                Margin = new PointF(0, Padding.Top),
                Size = new SizeF(Padding.Left, chartContainer.Size.Height),
                Labels = labels,
                LabelHeight = labelHeight,
                LabelOffsetX = Padding.Left - 10,
                LabelOffetY = -labelHeight / 2,
                Font = Font
            });
        }

        private void AddHozLabelAxis(GdiContainer mainContainer, GdiRectangle chartContainer)
        {
            mainContainer.AddChild(new GdiHozLabelAxis
            {
                Size = new SizeF(chartContainer.Size.Width, Padding.Bottom),
                Margin = new PointF(Padding.Left, this.Size.Height - Padding.Bottom),
                LeftToRightLabels = Categories,
                LabelWidth = _categoryWidth,
                LabelOffsetX = _categoryWidth / 2,
                LabelOffsetY = 10,
                Font = Font
            });
        }
    }
}