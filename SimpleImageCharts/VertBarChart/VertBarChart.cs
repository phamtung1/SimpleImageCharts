using System;
using System.Drawing;
using System.Linq;

namespace SimpleImageCharts.VertBarChart
{
    public class VertBarChart
    {
        private const int MarginLeft = 30;

        private const int MarginRight = 30;

        private const int MarginTop = 50;

        private const int MarginBottom = 100;

        private const int BarWidth = 15;

        public int StepSize { get; set; } = 5;

        public int Width { get; set; } = 600;

        public int Height { get; set; } = 300;

        public string[] Categories { get; set; }

        public VertBarSeries[] DataSets { get; set; }

        private int _categoryWidth;

        private float _rootY;

        private float _heightUnit;

        private float _maxValue;

        private float _minValue;

        public Bitmap CreateImage()
        {
            _categoryWidth = (Width - MarginLeft - MarginRight) / Categories.Length;

            _maxValue = DataSets.SelectMany(x => x.Data).Max(x => x) * 1.1f;
            _minValue = DataSets.SelectMany(x => x.Data).Min(x => x) * 1.1f;

            if (_minValue > 0)
            {
                _minValue = 0;
            }

            _heightUnit = (Height - MarginTop - MarginBottom) / (Math.Abs(_minValue) + _maxValue);

            _rootY = MarginTop + (_heightUnit * Math.Abs(_maxValue));

            var bitmap = new Bitmap(Width, Height);
            using (var graphic = Graphics.FromImage(bitmap))
            {
                graphic.Clear(Color.White);
                // Y axis line
                graphic.DrawLine(Pens.Black, MarginLeft, _rootY, Width - MarginRight, _rootY);

                DrawVerticalLines(graphic);
                var offsetX = -(DataSets.Length * BarWidth) / 2;
                foreach (var data in DataSets)
                {
                    DrawBarSeries(graphic, data, offsetX);
                    offsetX += BarWidth;
                }

                DrawCategoyLabels(graphic);
            }

            return bitmap;
        }

        private void DrawVerticalLines(Graphics graphic)
        {
            var x = MarginLeft;
            foreach (var item in Categories)
            {
                graphic.DrawLine(Pens.LightGray, x, MarginTop, x, Height - MarginBottom);
                x += _categoryWidth;
            }

            graphic.DrawLine(Pens.LightGray, x, MarginTop, x, Height - MarginBottom);
        }

        private void DrawCategoyLabels(Graphics graphic)
        {
            var x = MarginLeft + _categoryWidth / 2;
            using (StringFormat stringFormat = new StringFormat())
            {
                stringFormat.Alignment = StringAlignment.Center;
                foreach (var item in Categories)
                {
                    graphic.DrawString(item, new Font("Arial", 10), Brushes.Gray, x, Height - MarginBottom, stringFormat);
                    x += _categoryWidth;
                }
            }
        }

        private void DrawBarSeries(Graphics graphics, VertBarSeries series, int offsetX)
        {
            var spaceX = _categoryWidth;
            var x = MarginLeft + (spaceX / 2) + offsetX;
            using (var brush = new SolidBrush(series.Color))
            {
                foreach (var value in series.Data)
                {
                    var length = _heightUnit * value;
                    if (length >= 0)
                    {
                        graphics.FillRectangle(brush, x, _rootY - length, BarWidth, length);
                    }
                    else
                    {
                        graphics.FillRectangle(brush, x, _rootY, BarWidth, Math.Abs(length));
                    }

                    x += spaceX;
                }
            }
        }
    }
}