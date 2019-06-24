using System;
using System.Drawing;
using System.Linq;

namespace SimpleImageCharts.BarChart
{
    public class BarChart
    {
        private const int MarginLeft = 100;

        private const int MarginRight = 30;

        private const int MarginTop = 10;

        public int MarginBottom { get; set; } = 100;

        // use "{0:0;0}" for forcing positive value
        public string FormatAxisValue { get; set; } = "{0}";

        public string FormatBarValue { get; set; } = "{0}";

        public int BarSize { get; set; } = 30;

        public bool IsStacked { get; set; } = false;

        public int StepSize { get; set; } = 0;

        public int Width { get; set; } = 600;

        public int Height { get; set; } = 300;

        public string[] Categories { get; set; }

        public BarSeries[] DataSets { get; set; }

        public Font Font { get; set; } = new Font("Arial", 10);

        public Font BarValueFont { get; set; } = new Font("Arial", 10, FontStyle.Bold);

        private int _categoryHeight;

        private float _rootX;

        private float _widthUnit;

        private float _maxValue;

        private float _minValue;

        public Bitmap CreateImage()
        {
            _categoryHeight = (Height - MarginTop - MarginBottom) / Categories.Length;

            _maxValue = DataSets.SelectMany(x => x.Data).Max(x => x) * 1.1f;
            _minValue = DataSets.SelectMany(x => x.Data).Min(x => x) * 1.1f;

            if (StepSize == 0)
            {
                var range = _maxValue - _minValue;
                StepSize = (int)(range / 4);
            }

            if (_minValue > 0)
            {
                _minValue = 0;
            }

            _widthUnit = (Width - MarginLeft - MarginRight) / (Math.Abs(_minValue) + _maxValue);

            _rootX = MarginLeft + (_widthUnit * Math.Abs(_minValue));

            var bitmap = new Bitmap(Width, Height);
            using (var graphic = Graphics.FromImage(bitmap))
            {
                graphic.Clear(Color.White);

                // X axis line
                graphic.DrawLine(Pens.LightGray, _rootX, MarginTop, _rootX, Height - MarginBottom);

                DrawHorizontalLines(graphic);
                DrawVerticalLines(graphic);
                DrawHorizontalAxisValues(graphic);
                var offsetY = IsStacked ? -BarSize / 2 : -(DataSets.Length * BarSize) / 2;
                foreach (var data in DataSets)
                {
                    DrawBarSeries(graphic, data, offsetY);
                    if (!IsStacked)
                    {
                        offsetY += BarSize;
                    }
                }

                DrawCategoryLabels(graphic);
                DrawLegend(graphic);
            }

            return bitmap;
        }

        private void DrawHorizontalLines(Graphics graphic)
        {
            var y = MarginTop;
            foreach (var item in Categories)
            {
                graphic.DrawLine(Pens.LightGray, MarginLeft, y, Width - MarginRight, y);
                y += _categoryHeight;
            }

            graphic.DrawLine(Pens.LightGray, MarginLeft, y, Width - MarginRight, y);
        }

        private void DrawVerticalLines(Graphics graphic)
        {
            var x = _rootX;
            var realStepSize = StepSize * _widthUnit;
            for (int i = 0; i < _maxValue; i += StepSize)
            {
                x += realStepSize;
                if (x < Width - MarginRight)
                {
                    graphic.DrawLine(Pens.LightGray, x, MarginTop, x, Height - MarginBottom);
                }
            }

            x = _rootX;
            for (int i = 0; i > _minValue; i -= StepSize)
            {
                x -= realStepSize;
                if (Math.Abs(x) > MarginLeft)
                {
                    graphic.DrawLine(Pens.LightGray, x, MarginTop, x, Height - MarginBottom);
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

        private void DrawBarSeries(Graphics graphics, BarSeries series, int offsetY)
        {
            var y = MarginTop + (_categoryHeight / 2) + offsetY;
            using(var positiveNumberStringFormat = new StringFormat())
            using (var negativeNumberStringFormat = new StringFormat())
            using (var brush = new SolidBrush(series.Color))
            {
                positiveNumberStringFormat.LineAlignment = StringAlignment.Center;

                negativeNumberStringFormat.LineAlignment = StringAlignment.Center;
                negativeNumberStringFormat.Alignment = StringAlignment.Far;

                foreach (var value in series.Data)
                {
                    var length = _widthUnit * value;
                    if (length > 0)
                    {
                        graphics.FillRectangle(brush, _rootX, y, length, BarSize);
                        graphics.DrawString(string.Format(FormatBarValue, value), BarValueFont, Brushes.Gray, _rootX + length + 2, y + (BarSize / 2), positiveNumberStringFormat);
                    }
                    else if(length < 0)
                    {
                        graphics.FillRectangle(brush, _rootX + length, y, Math.Abs(length), BarSize);
                        graphics.DrawString(string.Format(FormatBarValue, value), BarValueFont, Brushes.Gray, _rootX + length - 2, y + (BarSize / 2), negativeNumberStringFormat);
                    }

                    y += _categoryHeight;
                }
            }
        }

        private void DrawLegend(Graphics graphic)
        {
            const int RectWidth = 25;
            const int RectHeight = 15;

            const int labelWidth = 130;
            var legendWidth = labelWidth * DataSets.Length;

            var left = MarginLeft + (Width - MarginLeft - MarginRight - legendWidth) / 2 + RectWidth;
            var top = Height - MarginBottom / 2;

            using (var textBrush = new SolidBrush(Color.FromArgb(100, 100, 100)))
            {
                foreach (var dataset in DataSets)
                {
                    if (string.IsNullOrEmpty(dataset.Label))
                    {
                        continue;
                    }

                    using (var brush = new SolidBrush(dataset.Color))
                    {
                        graphic.FillRectangle(brush, left, top, RectWidth, RectHeight);
                        graphic.DrawString(dataset.Label, Font, textBrush, left + RectWidth + 5, top);
                    }

                    left += labelWidth;
                }
            }
            }
        }
}