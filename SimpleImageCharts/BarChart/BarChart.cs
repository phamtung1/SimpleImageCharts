using GdiSharp.Components;
using GdiSharp.Components.Base;
using GdiSharp.Renderer;
using SimpleImageCharts.Core;
using SimpleImageCharts.Core.Components;
using System;
using System.Drawing;
using System.Linq;

namespace SimpleImageCharts.BarChart
{
    public class BarChart : BaseChart, IBarChart
    {
        // use "{0:0;0}" for forcing positive value
        public string FormatAxisValue { get; set; } = "{0}";

        public string FormatBarValue { get; set; } = "{0}";

        public int BarSize { get; set; } = 30;

        public bool IsStacked { get; set; } = false;

        public int StepSize { get; set; } = 0;

        public string[] Categories { get; set; }

        public BarSeries[] DataSets { get; set; }

        public Font Font { get; set; } = new Font("Arial", 12);

        public Font BarValueFont { get; set; } = new Font("Arial", 12, FontStyle.Bold);

        private int _categoryHeight;

        private float _rootX;

        private float _widthUnit;

        private float _maxValue;

        private float _minValue;

        public BarChart()
        {
            this.Width = 600;
            this.Height = 300;
            this.MarginLeft = 100;
            this.MarginRight = 30;
            this.MarginTop = 10;
            this.MarginBottom = 100;
        }

        public virtual IImageFile CreateImage()
        {
            const int NumberOfColumns = 4;
            _categoryHeight = (Height - MarginTop - MarginBottom) / Categories.Length;

            _maxValue = DataSets.SelectMany(x => x.Data).Max(x => x) * 1.1f;
            _minValue = DataSets.SelectMany(x => x.Data).Min(x => x) * 1.1f;

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

            _widthUnit = (Width - MarginLeft - MarginRight) / (Math.Abs(_minValue) + _maxValue);

            _rootX = MarginLeft + (_widthUnit * Math.Abs(_minValue));

            var bitmap = new Bitmap(Width, Height);
            var renderer = new GdiRenderer(bitmap);
            var container = new GdiRectangle
            {
                Width = bitmap.Width,
                Height = bitmap.Height,
                Color = Color.White
            };
            AddHorizontalLines(container);
            AddVerticalLines(container);

            var offsetY = IsStacked ? -BarSize / 2 : -(DataSets.Length * BarSize) / 2;
            foreach (var data in DataSets)
            {
                AddBarSeries(container, data, offsetY);
                if (!IsStacked)
                {
                    offsetY += BarSize;
                }
            }

            renderer.Render(container);

            if (Legend != null && Legend.Items == null)
            {
                Legend.Items = DataSets.Select(x => new LegendItem
                {
                    Text = x.Label,
                    Color = x.Color
                }).ToArray();
            }

            using (var graphic = renderer.GetGraphics())
            {
                // X axis line
                graphic.DrawLine(Pens.LightGray, _rootX, MarginTop, _rootX, Height - MarginBottom);

                DrawHorizontalAxisValues(graphic);

                DrawCategoryLabels(graphic);
                base.DrawLegend(graphic);
                base.DrawSubTitle(graphic);
            }

            return new ImageFile(bitmap);
        }

        private void AddHorizontalLines(GdiContainer container)
        {
            var y = MarginTop;
            var numOfLines = Categories.Length + 1;
            for (int i = 0; i < numOfLines; i++)
            {
                var line = new GdiHozLine
                {
                    Color = Color.LightGray,
                    X = MarginLeft,
                    Y = y,
                    Length = Width - MarginRight
                };
                container.AddChild(line);
                y += _categoryHeight;
            }
        }

        private void AddVerticalLines(GdiContainer container)
        {
            var x = _rootX;
            var realStepSize = StepSize * _widthUnit;
            for (int i = 0; i < _maxValue; i += StepSize)
            {
                x += realStepSize;
                if (x < Width - MarginRight)
                {
                    container.AddChild(new GdiVerLine
                    {
                        Color = Color.LightGray,
                        X = x,
                        Y = MarginTop,
                        Length = Height - MarginBottom
                    });
                }
            }

            x = _rootX;
            for (int i = 0; i > _minValue; i -= StepSize)
            {
                x -= realStepSize;
                if (Math.Abs(x) > MarginLeft)
                {
                    container.AddChild(new GdiVerLine
                    {
                        Color = Color.LightGray,
                        X = x,
                        Y = MarginTop,
                        Length = Height - MarginBottom
                    });
                }
            }
        }

        private void DrawHorizontalAxisValues(Graphics graphic)
        {
            var x = _rootX;
            var realStepSize = StepSize * _widthUnit;
            using (var stringFormat = new StringFormat())
            {
                stringFormat.Alignment = StringAlignment.Center;

                graphic.DrawString("0", Font, Brushes.Gray, _rootX, Height - MarginBottom, stringFormat);

                for (int i = 0; i < _maxValue; i += StepSize)
                {
                    x += realStepSize;
                    if (x < Width - MarginRight)
                    {
                        graphic.DrawString(string.Format(FormatAxisValue, i + StepSize), Font, Brushes.Gray, x, Height - MarginBottom, stringFormat);
                    }
                }

                x = _rootX;
                for (int i = 0; i > _minValue; i -= StepSize)
                {
                    x -= realStepSize;
                    if (Math.Abs(x) > MarginLeft)
                    {
                        graphic.DrawString(string.Format(FormatAxisValue, i - StepSize), Font, Brushes.Gray, x, Height - MarginBottom, stringFormat);
                    }
                }
            }
        }

        private void DrawCategoryLabels(Graphics graphic)
        {
            var y = MarginTop + _categoryHeight / 2;
            using (StringFormat stringFormat = new StringFormat())
            {
                stringFormat.Alignment = StringAlignment.Far;

                foreach (var item in Categories)
                {
                    graphic.DrawString(item, Font, Brushes.Gray, MarginLeft - 10, y, stringFormat);
                    y += _categoryHeight;
                }
            }
        }

        private void AddBarSeries(GdiContainer container, BarSeries series, int offsetY)
        {
            var y = MarginTop + (_categoryHeight / 2) + offsetY;

            foreach (var value in series.Data)
            {
                var length = _widthUnit * value;
                var bar = new GdiRectangle
                {
                    Y = y,
                    Height = BarSize,
                    Color = series.Color,
                    Width = Math.Abs(length)
                };
                var text = new GdiText
                {
                    Content = string.Format(FormatBarValue, value),
                    Font = BarValueFont,
                    Color = Color.Gray,
                    X = bar.Width + 2,
                    VerticalAlignment = GdiSharp.Enum.VerticalAlignment.Middle
                };

                if (length > 0)
                {
                    bar.X = _rootX;
                }
                else if (length < 0)
                {
                    bar.X = Width - _rootX;
                    bar.HorizontalAlignment = GdiSharp.Enum.HorizontalAlignment.Right;
                    text.HorizontalAlignment = GdiSharp.Enum.HorizontalAlignment.Right;
                }

                bar.AddChild(text);
                container.AddChild(bar);

                y += _categoryHeight;
            }
        }
    }
}