using System;
using System.Drawing;
using System.Linq;

namespace SimpleImageCharts.ColumnChart
{
    public class ColumnChart
    {
        private const int MarginLeft = 30;

        private const int MarginRight = 30;

        private const int MarginTop = 50;

        private const int MarginBottom = 100;

        public string FormatColumnValue { get; set; } = "{0}";

        public int ColumnSize { get; set; } = 20;

        public Font Font { get; set; } = new Font("Arial", 10);

        public Font ColumnValueFont { get; set; } = new Font("Arial", 10, FontStyle.Bold);

        public int StepSize { get; set; } = 5;

        public int Width { get; set; } = 600;

        public int Height { get; set; } = 300;

        public string[] Categories { get; set; }

        public ColumnSeries[] DataSets { get; set; }

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
                graphic.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                graphic.Clear(Color.White);
                // Y axis line
                graphic.DrawLine(Pens.Black, MarginLeft, _rootY, Width - MarginRight, _rootY);

                DrawVerticalLines(graphic);
                var offsetX = -(DataSets.Length * ColumnSize) / 2 - DataSets.Select(x => x.OffsetX).Sum() / 2;
                foreach (var data in DataSets)
                {
                    DrawColumnSeries(graphic, data, offsetX + data.OffsetX);
                    offsetX += ColumnSize;
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
                    // graphic.DrawString(item, this.Font, Brushes.Gray, x, Height - MarginBottom, stringFormat);
                    DrawRotatedText(graphic, item, x, Height - MarginBottom / 2);
                    x += _categoryWidth;
                }
            }
        }

        private void DrawColumnSeries(Graphics graphics, ColumnSeries series, int offsetX)
        {
            var spaceX = _categoryWidth;
            var x = MarginLeft + (spaceX / 2) + offsetX;
            using (var stringFormat = new StringFormat())
            {
                stringFormat.Alignment = StringAlignment.Center;
                for (int i = 0; i < series.Data.Length; i++)
                {
                    var color = series.Colors == null ? series.Color : series.Colors[i];
                    using (var brush = new SolidBrush(color))
                    {
                        var value = series.Data[i];
                        var length = _heightUnit * value;
                        var text = string.Format(FormatColumnValue, value);
                        if (length >= 0)
                        {
                            graphics.FillRectangle(brush, x, _rootY - length, ColumnSize, length);
                            graphics.DrawString(text, this.ColumnValueFont, Brushes.DarkBlue, x + ColumnSize / 2, _rootY - length - 15, stringFormat);
                        }
                        else
                        {
                            graphics.FillRectangle(brush, x, _rootY, ColumnSize, Math.Abs(length));
                            graphics.DrawString(text, this.ColumnValueFont, Brushes.DarkBlue, x + ColumnSize / 2, _rootY - length, stringFormat);
                        }

                        x += spaceX;
                    }
                }
            }
        }

        private void DrawRotatedText(Graphics graphic, string text, float x, float y)
        {
            using (var format = new StringFormat())
            {
                format.Alignment = StringAlignment.Center;
                // move the origin to the drawing point
                graphic.TranslateTransform(x, y);
                graphic.RotateTransform(-45);
                var size = graphic.MeasureString(text, this.Font);
                graphic.DrawString(text, Font, Brushes.Gray, 0, 0, format);

                graphic.ResetTransform();
            }
        }
    }
}