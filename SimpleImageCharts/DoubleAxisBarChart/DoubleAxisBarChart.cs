using SimpleImageCharts.Core;
using System.Drawing;

namespace SimpleImageCharts.DoubleAxisBarChart
{
    public class DoubleAxisBarChart : IImageChart
    {
        public int MarginLeft { get; set; } = 150;

        public int MarginRight { get; set; } = 30;

        public int MarginBottom { get; set; } = 50;

        public int MarginTop { get; set; } = 40;

        private const int BarSize = 30;

        public Font Font { get; set; } = new Font("Arial", 12);

        public Font BarValueFont { get; set; } = new Font("Arial", 12, FontStyle.Bold);

        public string FormatBarValue { get; set; } = "{0}";

        public int StepSize { get; set; } = 5;

        public int Width { get; set; } = 600;

        public int Height { get; set; } = 300;

        public string[] Categories { get; set; }

        public DoubleAxisBarSeries FirstDataSet { get; set; }

        public DoubleAxisBarSeries SecondDataSet { get; set; }

        private int _categoryHeight;

        private float _widthUnit;

        private float _maxValue;

        public virtual Bitmap CreateImage()
        {
            _categoryHeight = (Height - MarginTop - MarginBottom) / Categories.Length;

            _maxValue = FindMaxValueFromBothDataSets() * 1.1f;

            _widthUnit = (Width - MarginLeft - MarginRight) / _maxValue;

            var bitmap = new Bitmap(Width, Height);
            using (var graphic = Graphics.FromImage(bitmap))
            using (var axisFont = new Font("Arial", 13, FontStyle.Bold))
            {
                graphic.Clear(Color.White);
                // Left X axis
                graphic.DrawLine(Pens.LightGray, MarginLeft, MarginTop, MarginLeft, Height - MarginBottom);
                using (var labelBrush = new SolidBrush(FirstDataSet.LabelColor))
                {
                    graphic.DrawString(FirstDataSet.Label, axisFont, labelBrush, MarginLeft, 10);
                }

                // Second X axis
                graphic.DrawLine(Pens.LightGray, Width - MarginRight, MarginTop, Width - MarginRight, Height - MarginBottom);
                using (var stringFormat = new StringFormat())
                using (var labelBrush = new SolidBrush(SecondDataSet.LabelColor))
                {
                    stringFormat.Alignment = StringAlignment.Far;
                    graphic.DrawString(SecondDataSet.Label, axisFont, labelBrush, Width - MarginRight, 10, stringFormat);
                }

                DrawHorizontalLines(graphic);

                DrawFirstBarSeries(graphic, FirstDataSet);
                DrawSecondBarSeries(graphic, SecondDataSet);
                DrawCategoyLabels(graphic);
            }

            return bitmap;
        }

        private float FindMaxValueFromBothDataSets()
        {
            var maxValue = 0f;
            for (int i = 0; i < FirstDataSet.Data.Length; i++)
            {
                var value = FirstDataSet.Data[i] + (SecondDataSet.Data.Length >= i + 1 ? SecondDataSet.Data[i] : 0);
                if (value > maxValue)
                {
                    maxValue = value;
                }
            }

            return maxValue;
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

        private void DrawCategoyLabels(Graphics graphic)
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

        private void DrawFirstBarSeries(Graphics graphics, DoubleAxisBarSeries series)
        {
            var spaceY = _categoryHeight;
            var y = MarginTop + ((spaceY - BarSize) / 2);
            using (var stringFormat = new StringFormat())
            {
                stringFormat.LineAlignment = StringAlignment.Center;
                stringFormat.Alignment = StringAlignment.Far;
                for (int i = 0; i < series.Data.Length; i++)
                {
                    var value = series.Data[i];
                    var color = series.Colors == null ? series.Color : series.Colors[i];
                    using (var brush = new SolidBrush(color))
                    {
                        var length = _widthUnit * value;
                        graphics.FillRectangle(brush, MarginLeft, y, length, BarSize);
                        graphics.DrawString(string.Format(FormatBarValue, value), BarValueFont, Brushes.White, MarginLeft + length - 2, y + (BarSize / 2), stringFormat);
                        y += spaceY;
                    }
                }
            }
        }

        private void DrawSecondBarSeries(Graphics graphics, DoubleAxisBarSeries series)
        {
            var spaceY = _categoryHeight;
            var y = MarginTop + ((spaceY - BarSize) / 2);
            using (var stringFormat = new StringFormat())
            {
                stringFormat.LineAlignment = StringAlignment.Center;
                //stringFormat.Alignment = StringAlignment.Far;

                for (int i = 0; i < series.Data.Length; i++)
                {
                    var value = series.Data[i];

                    stringFormat.Alignment = value <= 1 ? StringAlignment.Far : StringAlignment.Near;
                    var color = series.Colors == null ? series.Color : series.Colors[i];
                    using (var brush = new SolidBrush(color))
                    {
                        var length = _widthUnit * value;
                        var x = Width - MarginRight - length;
                        graphics.FillRectangle(brush, x, y, length, BarSize);

                        x -= 2;
                        Brush textBrush;
                        if(value <= 1)
                        {
                            textBrush = Brushes.DarkBlue;
                        }
                        else
                        {
                            textBrush = Brushes.White;
                        }

                        graphics.DrawString(string.Format(FormatBarValue, value), BarValueFont, textBrush, x + 2, y + (BarSize / 2), stringFormat);
                        y += spaceY;
                    }
                }
            }
        }
    }
}