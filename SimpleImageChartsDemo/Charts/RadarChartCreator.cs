using SimpleImageCharts.RadarChart;
using System;
using System.Drawing;

namespace WindowsFormsChart.Charts
{
    public static class RadarChartCreator
    {
        public static RadarChart CreateChart(Size size)
        {
            var random = new Random();
            var categories = new[] { "Eating", "Sleeping", "Doing Nothing", "Playing", "Relaxing", "Watching" };
            var chart = new RadarChart
            {
             //   MaxDataValue = 100,
                StepSize = 10,
                Size = size,
                Categories = categories,
                DataSets = new[]
                {
                    new RadarChartSeries
                    {
                        Label = "My Life",
                        Color = Color.LightCoral,
                        Data = GenerateRandomArray(random, categories.Length, 1, 50),
                    },
                    new RadarChartSeries
                    {
                        Label = "My Wife Life",
                        Color = Color.LightBlue,
                        Data = GenerateRandomArray(random, categories.Length, 1, 100),
                    }
                }
            };

            return chart;
        }

        private static int[] GenerateRandomArray(Random random, int length, int min, int max)
        {
            var result = new int[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = random.Next(min, max);
            }

            return result;
        }
    }
}