using GdiSharp.Components;
using GdiSharp.Components.Base;
using GdiSharp.Models;
using SimpleImageCharts.Core;
using SimpleImageCharts.Core.Models;
using System;
using System.Drawing;
using System.Linq;

namespace SimpleImageCharts.ColumnChart
{
    public class ColumnChart : BaseChart, IColumnChart
    {
        public string FormatColumnValue { get; set; } = "{0}";

        public int ColumnSize { get; set; } = 20;

        public SlimFont ColumnValueFont { get; set; } = new SlimFont("Arial", 12, FontStyle.Bold);

        public int StepSize { get; set; } = 5;

        public string[] Categories { get; set; }

        public ColumnSeries[] DataSets { get; set; }

        private float _categoryWidth;

        private float _rootY;

        private float _heightUnit;

        private float _maxValue;

        private float _minValue;

        public ColumnChart()
        {
            Padding = new Padding(30, 50, 30, 120);
        }

        protected override void Init(GdiContainer mainContainer, GdiRectangle chartContainer)
        {
            base.Init(mainContainer, chartContainer);
            _categoryWidth = chartContainer.Size.Width / Categories.Length;

            _maxValue = DataSets.SelectMany(x => x.Data).Max(x => x) * 1.1f;
            _minValue = DataSets.SelectMany(x => x.Data).Min(x => x) * 1.1f;

            if (_minValue > 0)
            {
                _minValue = 0;
            }

            var maxLength = (Math.Abs(_minValue) + _maxValue);
            
            _heightUnit = maxLength == 0 ? 1 : chartContainer.Size.Height / maxLength;

            _rootY = Padding.Top + (_heightUnit * Math.Abs(_maxValue));
        }

        protected override void DrawAfterRender(Graphics graphics)
        {
            base.DrawAfterRender(graphics);

            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            graphics.Clear(Color.White);
            // Y axis line
            graphics.DrawLine(Pens.Black, Padding.Left, _rootY, Size.Width - Padding.Right, _rootY);

            DrawVerticalLines(graphics);
            var offsetX = -(DataSets.Length * ColumnSize) / 2 - DataSets.Select(x => x.OffsetX).Sum() / 2;
            foreach (var data in DataSets)
            {
                DrawColumnSeries(graphics, data, offsetX + data.OffsetX);
                offsetX += ColumnSize;
            }

            // draw column values after draw all columns so that if the column will not overlap the texts
            offsetX = -(DataSets.Length * ColumnSize) / 2 - DataSets.Select(x => x.OffsetX).Sum() / 2;
            foreach (var data in DataSets)
            {
                DrawColumnSeriesValues(graphics, data, offsetX + data.OffsetX);
                offsetX += ColumnSize;
            }

            DrawCategoyLabels(graphics);
        }

        private void DrawVerticalLines(Graphics graphic)
        {
            float x = Padding.Left;
            foreach (var item in Categories)
            {
                graphic.DrawLine(Pens.LightGray, x, Padding.Top, x, Size.Height - Padding.Bottom);
                x += _categoryWidth;
            }

            graphic.DrawLine(Pens.LightGray, x, Padding.Top, x, Size.Height - Padding.Bottom);
        }

        private void DrawCategoyLabels(Graphics graphic)
        {
            var x = Padding.Left + _categoryWidth / 2;
            using (StringFormat stringFormat = new StringFormat())
            {
                stringFormat.Alignment = StringAlignment.Center;
                foreach (var item in Categories)
                {
                    // graphic.DrawString(item, this.Font, Brushes.Gray, x, Height - MarginBottom, stringFormat);
                    DrawRotatedText(graphic, item, x, Size.Height - Padding.Bottom / 2);
                    x += _categoryWidth;
                }
            }
        }

        private void DrawColumnSeries(Graphics graphics, ColumnSeries series, int offsetX)
        {
            var spaceX = _categoryWidth;
            var x = Padding.Left + (spaceX / 2) + offsetX;
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
                        }
                        else
                        {
                            graphics.FillRectangle(brush, x, _rootY, ColumnSize, Math.Abs(length));
                        }

                        x += spaceX;
                    }
                }
            }
        }

        private void DrawColumnSeriesValues(Graphics graphics, ColumnSeries series, int offsetX)
        {
            var spaceX = _categoryWidth;
            var x = Padding.Left + (spaceX / 2) + offsetX;
            using (var stringFormat = new StringFormat())
            using (var font = ColumnValueFont.ToFatFont())
            {
                stringFormat.Alignment = StringAlignment.Center;
                for (int i = 0; i < series.Data.Length; i++)
                {
                    var value = series.Data[i];
                    var length = _heightUnit * value;
                    var text = string.Format(FormatColumnValue, value);
                    if (length >= 0)
                    {
                        graphics.DrawString(text, font, Brushes.DarkBlue, x + ColumnSize / 2, _rootY - length - 15, stringFormat);
                    }
                    else
                    {
                        graphics.DrawString(text, font, Brushes.DarkBlue, x + ColumnSize / 2, _rootY - length, stringFormat);
                    }

                    x += spaceX;
                }
            }
        }

        private void DrawRotatedText(Graphics graphic, string text, float x, float y)
        {
            using (var format = new StringFormat())
            using (var font = Font.ToFatFont())
            {
                format.Alignment = StringAlignment.Center;
                // move the origin to the drawing point
                graphic.TranslateTransform(x, y);
                graphic.RotateTransform(-45);
                var size = graphic.MeasureString(text, font);
                graphic.DrawString(text, font, Brushes.Gray, 0, 0, format);

                graphic.ResetTransform();
            }
        }
    }
}