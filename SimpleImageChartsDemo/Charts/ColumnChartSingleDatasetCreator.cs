using SimpleImageCharts.ColumnChart;
using SimpleImageCharts.Core.Models;
using System;
using System.Drawing;

namespace WindowsFormsChart.Charts
{
    public static class ColumnChartSingleDatasetCreator
    {
        public static ColumnChart CreateChart(Size size)
        {
            var categories = new[] { "A Long Product Name", "Product B", "Product C", "Another Long Name D", "Product E" };
            var rand = new Random();
            var datasets = new ColumnSeries[1];
            var colors = new Color[categories.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256));
            }

            for (int i = 0; i < datasets.Length; i++)
            {
                var data = new float[categories.Length];
                for (int j = 0; j < categories.Length; j++)
                {
                    data[j] = 100 - (j * 10);
                }

                datasets[i] = new ColumnSeries
                {
                    Colors = colors,
                    Data = data
                };
            }

            var chart = new ColumnChart
            {
                Padding = new Padding(60, 50, 30, 150),
                YAxisMinText = "Min",
                YAxisMaxText = "Max",
                ColumnValuesVisible = false,
                IsOneHundredPercentChart = true,
                ColumnSize = 50,
                Size = size,
                Categories = categories,
                DataSets = datasets,
            };

            return chart;
        }
    }
}