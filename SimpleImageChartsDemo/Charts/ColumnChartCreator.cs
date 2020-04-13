using SimpleImageCharts.ColumnChart;
using System;
using System.Drawing;

namespace WindowsFormsChart.Charts
{
    public static class ColumnChartCreator
    {
        public static ColumnChart CreateChart(Size size)
        {
            var categories = new[] { "Product A", "Product B", "Product C", "Product D", "Product E" };
            var rand = new Random();
            var datasets = new ColumnSeries[3];
            for (int i = 0; i < datasets.Length; i++)
            {
                var data = new float[categories.Length];
                for (int j = 0; j < categories.Length; j++)
                {
                    data[j] = i * 10 + 2;// rand.Next(30) - 10;
                }

                var dataset = new ColumnSeries
                {
                    Color = Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256)),
                    Data = data
                };
                datasets[i] = dataset;
            }

            datasets[0].OffsetX = 20;
            datasets[1].OffsetX = 10;
            var chart = new ColumnChart
            {
                ColumnSize = 50,
                Size = size,
                Categories = categories,
                DataSets = datasets
            };

            return chart;
        }
    }
}