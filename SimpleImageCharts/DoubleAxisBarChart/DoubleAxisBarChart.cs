using GdiSharp.Components;
using GdiSharp.Components.Base;
using GdiSharp.Models;
using SimpleImageCharts.Core;
using SimpleImageCharts.Core.Models;
using System.Drawing;

namespace SimpleImageCharts.DoubleAxisBarChart
{
    public class DoubleAxisBarChart : BaseChart, IDoubleAxisBarChart
    {
        private const int BarSize = 30;

        public SlimFont BarValueFont { get; set; } = new SlimFont("Arial", 12, FontStyle.Bold);

        public string FormatBarValue { get; set; } = "{0}";

        public int StepSize { get; set; } = 5;

        public string[] Categories { get; set; }

        public DoubleAxisBarSeries FirstDataSet { get; set; }

        public DoubleAxisBarSeries SecondDataSet { get; set; }

        private float _categoryHeight;

        private float _widthUnit;

        private float _maxValue;

        public DoubleAxisBarChart()
        {
            Size = new Size(600, 300);
            Padding = new Padding(150, 40, 30, 50);
        }

        protected override void Init(GdiContainer mainContainer, GdiRectangle chartContainer)
        {
            base.Init(mainContainer, chartContainer);
            _categoryHeight = chartContainer.Size.Height / Categories.Length;

            _maxValue = FindMaxValueFromBothDataSets() * 1.1f;

            _widthUnit = chartContainer.Size.Width / _maxValue;
        }

        protected override void Draw(Graphics graphics)
        {
            base.Draw(graphics);

            using (var axisFont = new Font("Arial", 13, FontStyle.Bold))
            {
                graphics.Clear(Color.White);
                // Left X axis
                graphics.DrawLine(Pens.LightGray, Padding.Left, Padding.Top, Padding.Left, Size.Height - Padding.Bottom);
                using (var labelBrush = new SolidBrush(FirstDataSet.LabelColor))
                {
                    graphics.DrawString(FirstDataSet.Label, axisFont, labelBrush, Padding.Left, 10);
                }

                // Second X axis
                graphics.DrawLine(Pens.LightGray, Size.Width - Padding.Right, Padding.Top, Size.Width - Padding.Right, Size.Height - Padding.Bottom);
                using (var stringFormat = new StringFormat())
                using (var labelBrush = new SolidBrush(SecondDataSet.LabelColor))
                {
                    stringFormat.Alignment = StringAlignment.Far;
                    graphics.DrawString(SecondDataSet.Label, axisFont, labelBrush, Size.Width - Padding.Right, 10, stringFormat);
                }

                DrawHorizontalLines(graphics);

                DrawFirstBarSeries(graphics, FirstDataSet);
                DrawSecondBarSeries(graphics, SecondDataSet);
                DrawCategoyLabels(graphics);
            }
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
            float y = Padding.Top;
            foreach (var item in Categories)
            {
                graphic.DrawLine(Pens.LightGray, Padding.Left, y, Size.Width - Padding.Right, y);
                y += _categoryHeight;
            }

            graphic.DrawLine(Pens.LightGray, Padding.Left, y, Size.Width - Padding.Right, y);
        }

        private void DrawCategoyLabels(Graphics graphic)
        {
            var y = Padding.Top + _categoryHeight / 2;
            using (StringFormat stringFormat = new StringFormat())
            using (var font = Font.ToFatFont())
            {
                stringFormat.Alignment = StringAlignment.Far;
                foreach (var item in Categories)
                {
                    graphic.DrawString(item, font, Brushes.Gray, Padding.Left - 10, y, stringFormat);
                    y += _categoryHeight;
                }
            }
        }

        private void DrawFirstBarSeries(Graphics graphics, DoubleAxisBarSeries series)
        {
            var spaceY = _categoryHeight;
            var y = Padding.Top + ((spaceY - BarSize) / 2);
            using (var stringFormat = new StringFormat())
            using (var font = BarValueFont.ToFatFont())
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
                        graphics.FillRectangle(brush, Padding.Left, y, length, BarSize);
                        graphics.DrawString(string.Format(FormatBarValue, value), font, Brushes.White, Padding.Left + length - 2, y + (BarSize / 2), stringFormat);
                        y += spaceY;
                    }
                }
            }
        }

        private void DrawSecondBarSeries(Graphics graphics, DoubleAxisBarSeries series)
        {
            var spaceY = _categoryHeight;
            var y = Padding.Top + ((spaceY - BarSize) / 2);
            using (var stringFormat = new StringFormat())
            using (var font = BarValueFont.ToFatFont())
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
                        var x = Size.Width - Padding.Right - length;
                        graphics.FillRectangle(brush, x, y, length, BarSize);

                        x -= 2;
                        Brush textBrush = value <= 1 ? Brushes.DarkBlue : Brushes.White;

                        graphics.DrawString(string.Format(FormatBarValue, value), font, textBrush, x + 2, y + (BarSize / 2), stringFormat);
                        y += spaceY;
                    }
                }
            }
        }
    }
}