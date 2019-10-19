using System;
using System.Drawing;
using System.Linq;
using GdiSharp.Components;
using GdiSharp.Components.Base;
using SimpleImageCharts.BarChart.GdiComponents;
using SimpleImageCharts.Core;
using SimpleImageCharts.Core.GdiChartComponents;
using SimpleImageCharts.Core.Models;

namespace SimpleImageCharts.BarChart
{
    public class BarChart : BaseChart, IBarChart
    {
        public BarSettingModel BarSetting { get; set; } = new BarSettingModel();

        public string FormatAxisValue { get; set; } = "{0}";

        public int StepSize { get; set; } = 0;

        public string[] Categories { get; set; }

        public DataSeries[] DataSet { get; set; }

        public ChartGridModel ChartGridModel { get; set; }

        private float _categoryHeight;

        private float _rootX;

        private float _widthUnit;

        private float _maxValue;

        private float _minValue;

        private GdiHozGridChartArea _barChartArea;

        public BarChart()
        {
            Padding = new Padding(100, 10, 30, 100);
        }

        protected override void Init(GdiContainer mainContainer, GdiRectangle chartContainer)
        {
            base.Init(mainContainer, chartContainer);
            const int NumberOfColumns = 4;
            _categoryHeight = chartContainer.Size.Height / Categories.Length;

            _maxValue = DataSet.SelectMany(x => x.Data).Max(x => x) * 1.1f;
            _minValue = DataSet.SelectMany(x => x.Data).Min(x => x) * 1.1f;

            if (StepSize == 0)
            {
                var range = _maxValue - _minValue;
                if (range < NumberOfColumns)
                {
                    StepSize = 1;
                }
                else
                {
                    StepSize = (int)(range / NumberOfColumns);
                }
            }

            if (_minValue > 0)
            {
                _minValue = 0;
            }

            _widthUnit = chartContainer.Size.Width / (Math.Abs(_minValue) + _maxValue);
            _rootX = Padding.Left + (_widthUnit * Math.Abs(_minValue));
        }

        protected override void BuildComponents(GdiContainer mainContainer, GdiRectangle chartContainer)
        {
            base.BuildComponents(mainContainer, chartContainer);

            AddChartArea(chartContainer);
            base.AddSubTitle(mainContainer);
            AddVerLabelAxis(mainContainer, chartContainer);
            AddHozLabelAxis(mainContainer, chartContainer);
        }

        protected override void CreateLegendItems()
        {
            base.CreateLegendItems();
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

            _barChartArea = new GdiBarChartArea
            {
                // base
                LeftPanelWidth = _rootX - Padding.Left,
                Size = chartArea.Size,
                CellSize = new SizeF(_widthUnit * StepSize, _categoryHeight),
                ChartGridModel = ChartGridModel,
                // GdiBarChartDataArea
                BarSettingModel = BarSetting,
                DataSet = DataSet,
                WidthUnit = _widthUnit
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
            var leftToRightLabels = Enumerable.Range(0, (int)Math.Ceiling(_maxValue / StepSize))
                .Select(x => string.Format(FormatAxisValue, x * StepSize)).ToArray();
            var rightToLeftLabels = Enumerable.Range(0, (int)Math.Ceiling(Math.Abs(_minValue) / StepSize))
                .Select(x => string.Format(FormatAxisValue, -x * StepSize)).ToArray();

            mainContainer.AddChild(new GdiHozLabelAxis
            {
                Size = new SizeF(chartContainer.Size.Width, Padding.Bottom),
                Margin = new PointF(Padding.Left, this.Size.Height - Padding.Bottom),
                RootX = _rootX - Padding.Left,
                LeftToRightLabels = leftToRightLabels,
                RightToLeftLabels = rightToLeftLabels,
                LabelWidth = _widthUnit * StepSize,
                Font = Font
            });
        }
    }
}