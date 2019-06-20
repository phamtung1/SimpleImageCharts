using System;
using System.Drawing;
using System.Linq;

namespace SimpleImageCharts.HorzBarChart
{
    public class HorzBarChart
    {
        private const int MarginLeft = 100;

        private const int MarginRight = 30;

        private const int MarginTop = 10;

        private const int MarginBottom = 50;

        private const int BarHeight = 15;

        public bool IsStacked { get; set; } = false;

        public int StepSize { get; set; } = 5;

        public int Width { get; set; } = 600;

        public int Height { get; set; } = 300;

        public string[] Categories { get; set; }

        public HorzBarSeries[] DataSets { get; set; }

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
                graphic.DrawLine(Pens.Black, _rootX, MarginTop, _rootX, Height - MarginBottom);

                // DrawHorizontalLines(graphic);
                DrawVerticalLines(graphic);
                var offsetY = IsStacked ? 0 : -(DataSets.Length * BarHeight) / 2;
                foreach (var data in DataSets)
                {
                    DrawBarSeries(graphic, data, offsetY);
                    if (!IsStacked)
                    {
                        offsetY += BarHeight;
                    }
                }

                DrawCategoyLabels(graphic);
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

        private void DrawCategoyLabels(Graphics graphic)
        {
            var y = MarginTop + _categoryHeight / 2;
            using(var font = new Font("Arial", 10))
            using (StringFormat stringFormat = new StringFormat())
            {
                stringFormat.Alignment = StringAlignment.Far;

                foreach (var item in Categories)
                {
                    graphic.DrawString(item, font, Brushes.Gray, MarginLeft - 10, y, stringFormat);
                    y += _categoryHeight;
                }
            }
        }

        private void DrawBarSeries(Graphics graphics, HorzBarSeries series, int offsetY)
        {
            var spaceY = _categoryHeight;
            var y = MarginTop + (spaceY / 2) + offsetY;
            using (var brush = new SolidBrush(series.Color))
            {
                foreach (var value in series.Data)
                {
                    var length = _widthUnit * value;
                    if (length >= 0)
                    {
                        graphics.FillRectangle(brush, _rootX, y, length, BarHeight);
                    }
                    else
                    {
                        graphics.FillRectangle(brush, _rootX + length, y, Math.Abs(length), BarHeight);
                    }

                    y += spaceY;
                }
            }
        }
    }
}