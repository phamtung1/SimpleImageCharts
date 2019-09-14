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

        public BarSeries[] DataSet { get; set; }

        public ChartGridModel ChartGrid { get; set; }

        private float _categoryHeight;

        private float _rootX;

        private float _widthUnit;

        private float _maxValue;

        private float _minValue;

        private GdiHozDataArea _chartDataArea;

        public BarChart()
        {
            this.Size = new Size(600, 300);
            Padding.Left = 100;
            Padding.Right = 30;
            Padding.Top = 10;
            Padding.Bottom = 100;
        }

        protected override void Init(GdiContainer container, GdiRectangle dataArea)
        {
            base.Init(container, dataArea);
            const int NumberOfColumns = 4;
            _categoryHeight = dataArea.Size.Height / Categories.Length;

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

            _widthUnit = dataArea.Size.Width / (Math.Abs(_minValue) + _maxValue);
            _rootX = Padding.Left + (_widthUnit * Math.Abs(_minValue));
        }

        protected override void BuildComponents(GdiContainer container, GdiRectangle dataArea)
        {
            base.BuildComponents(container, dataArea);

            AddChartDataArea(dataArea);
            CreateLegendItems();
            base.AddLegend(container);
            base.AddSubTitle(container);
            AddVerLabelAxis(container, dataArea);
            AddHozLabelAxis(container, dataArea);
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

        private void AddChartDataArea(GdiRectangle dataArea)
        {
            if (ChartGrid != null)
            {
                _chartDataArea = new GdiBarChartDataArea
                {
                    // base
                    MinValue = _minValue,
                    MaxValue = _maxValue,
                    RootX = _rootX - Padding.Left,
                    Size = dataArea.Size,
                    CellSize = new SizeF(_widthUnit * StepSize, _categoryHeight),
                    ChartGridModel = ChartGrid,
                    // GdiBarChartDataArea
                    BarSettingModel = BarSetting,
                    DataSet = DataSet,
                    WidthUnit = _widthUnit
                };
                dataArea.AddChild(_chartDataArea);
            }
        }

        private void AddVerLabelAxis(GdiContainer container, GdiRectangle dataArea)
        {
            container.AddChild(new GdiVerLabelAxis
            {
                Position = new PointF(0, Padding.Top),
                Size = new SizeF(Padding.Left, dataArea.Size.Height),
                Labels = Categories,
                LabelHeight = _categoryHeight,
                LabelOffsetX = Padding.Left - 10,
                Font = Font
            });
        }

        private void AddHozLabelAxis(GdiContainer container, GdiRectangle dataArea)
        {
            var leftToRightLabels = Enumerable.Range(0, (int)Math.Ceiling(_maxValue / StepSize))
                .Select(x => string.Format(FormatAxisValue, x * StepSize)).ToArray();
            var rightToLeftLabels = Enumerable.Range(0, (int)Math.Ceiling(Math.Abs(_minValue) / StepSize))
                .Select(x => string.Format(FormatAxisValue, -x * StepSize)).ToArray();

            container.AddChild(new GdiHozLabelAxis
            {
                Size = new SizeF(dataArea.Size.Width, Padding.Bottom),
                Position = new PointF(Padding.Left, this.Size.Height - Padding.Bottom),
                RootX = _rootX - Padding.Left,
                LeftToRightLabels = leftToRightLabels,
                RightToLeftLabels = rightToLeftLabels,
                LabelWidth = _widthUnit * StepSize,
                Font = Font
            });

        }
    }
}