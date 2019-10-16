using GdiSharp.Components;
using GdiSharp.Components.Base;
using SimpleImageCharts.BarChart;
using SimpleImageCharts.Core;
using SimpleImageCharts.Core.GdiChartComponents;
using SimpleImageCharts.Core.Models;
using SimpleImageCharts.StackedBar100Chart.GdiComponents;
using System.Drawing;
using System.Linq;

namespace SimpleImageCharts.StackedBar100Chart
{
    public class StackedBar100Chart : BaseChart
    {
        public BarSettingModel BarSetting { get; set; } = new BarSettingModel();

        public string FormatAxisValue { get; set; } = "{0}%";

        public int StepSize { get; set; } = 20;

        public string[] Categories { get; set; }

        public DataSeries[] DataSet { get; set; }

        private float _categoryHeight;

        private float _widthUnit;

        public ChartGridModel ChartGridModel { get; set; }

        private GdiStackedBar100ChartArea _barChartArea;

        public StackedBar100Chart()
        {
            this.Size = new Size(600, 300);
            Padding = new Padding(100, 10, 30, 100);
        }

        protected override void Init(GdiContainer mainContainer, GdiRectangle chartContainer)
        {
            base.Init(mainContainer, chartContainer);
            _categoryHeight = chartContainer.Size.Height / Categories.Length;

            _widthUnit = chartContainer.Size.Width / 100;

        }

        protected override void BuildComponents(GdiContainer mainContainer, GdiRectangle chartContainer)
        {
            base.BuildComponents(mainContainer, chartContainer);
            AddChartArea(chartContainer);
            CreateLegendItems();
            base.AddLegend(mainContainer);
            base.AddSubTitle(mainContainer);
            AddVerLabelAxis(mainContainer, chartContainer);
            AddHozLabelAxis(mainContainer, chartContainer);
        }

        private void CreateLegendItems()
        {
            if (Legend != null && Legend.Items == null)
            {
                Legend.Items = DataSet.Select(x => new LegendItemModel
                {
                    Text = x.Label,
                    Color = x.Color
                }).ToArray();
            }
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

            _barChartArea = new GdiStackedBar100ChartArea
            {
                Size = chartArea.Size,
                CellSize = new SizeF(_widthUnit * StepSize, _categoryHeight),
                ChartGridModel = ChartGridModel,
                BarSettingModel = BarSetting,
                DataSet = DataSet
            };
            chartArea.AddChild(_barChartArea);
        }

        private void AddVerLabelAxis(GdiContainer mainContainer, GdiRectangle chartContainer)
        {
            mainContainer.AddChild(new GdiVerLabelAxis
            {
                Margin = new PointF(0, Padding.Top),
                Size = new SizeF(Padding.Left, chartContainer.Size.Height),
                Labels = Categories,
                LabelHeight = _categoryHeight,
                LabelOffsetX = Padding.Left - 10,
                Font = Font
            });
        }

        private void AddHozLabelAxis(GdiContainer mainContainer, GdiRectangle chartContainer)
        {
            var leftToRightLabels = Enumerable.Range(0, 100 / StepSize + 1)
                .Select(x => string.Format(FormatAxisValue, x * StepSize)).ToArray();

            mainContainer.AddChild(new GdiHozLabelAxis
            {
                Size = new SizeF(chartContainer.Size.Width, Padding.Bottom),
                Margin = new PointF(Padding.Left, this.Size.Height - Padding.Bottom),
                RootX = 0,
                LeftToRightLabels = leftToRightLabels,
                LabelWidth = _widthUnit * StepSize,
                Font = Font
            });
        }
    }
}