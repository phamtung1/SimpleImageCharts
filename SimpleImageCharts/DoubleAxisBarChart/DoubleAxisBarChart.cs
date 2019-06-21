using System.Drawing;

namespace SimpleImageCharts.DoubleAxisBarChart
{
    public class DoubleAxisBarChart
    {
        private const int MarginLeft = 100;

        private const int MarginRight = 30;

        private const int MarginTop = 10;

        private const int MarginBottom = 50;

        private const int BarSize = 20;

        public int StepSize { get; set; } = 5;

        public int Width { get; set; } = 600;

        public int Height { get; set; } = 300;

        public string[] Categories { get; set; }

        public DoubleAxisBarSeries FirstDataSet { get; set; }

        public DoubleAxisBarSeries SecondDataSet { get; set; }

        private int _categoryHeight;

        private float _widthUnit;

        private float _maxValue;

        public Bitmap CreateImage()
        {
            _categoryHeight = (Height - MarginTop - MarginBottom) / Categories.Length;

            _maxValue = FindMaxValueFromBothDataSets() * 1.1f;

            _widthUnit = (Width - MarginLeft - MarginRight) / _maxValue;

            var bitmap = new Bitmap(Width, Height);
            using (var graphic = Graphics.FromImage(bitmap))
            {
                graphic.Clear(Color.White);
                // Left X axis
                graphic.DrawLine(Pens.Black, MarginLeft, MarginTop, MarginLeft, Height - MarginBottom);

                // Second X axis
                graphic.DrawLine(Pens.Black, Width - MarginRight, MarginTop, Width - MarginRight, Height - MarginBottom);

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
                var value = FirstDataSet.Data[i] + SecondDataSet.Data[i];
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
                    graphic.DrawString(item, new Font("Arial", 10), Brushes.Gray, MarginLeft - 10, y, stringFormat);
                    y += _categoryHeight;
                }
            }
        }

        private void DrawFirstBarSeries(Graphics graphics, DoubleAxisBarSeries series)
        {
            var spaceY = _categoryHeight;
            var y = MarginTop + ((spaceY - BarSize) / 2);
            using (var brush = new SolidBrush(series.Color))
            {
                foreach (var value in series.Data)
                {
                    var length = _widthUnit * value;
                    graphics.FillRectangle(brush, MarginLeft, y, length, BarSize);

                    y += spaceY;
                }
            }
        }

        private void DrawSecondBarSeries(Graphics graphics, DoubleAxisBarSeries series)
        {
            var spaceY = _categoryHeight;
            var y = MarginTop + ((spaceY - BarSize) / 2);
            using (var brush = new SolidBrush(series.Color))
            {
                foreach (var value in series.Data)
                {
                    var length = _widthUnit * value;
                    graphics.FillRectangle(brush, Width - MarginRight - length, y, length, BarSize);

                    y += spaceY;
                }
            }
        }
    }
}