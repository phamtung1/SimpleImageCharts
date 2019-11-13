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
            var categories = new[] { "Eating", "Sleeping", "Doing Nothing", "Playing", "Relaxing", "Eating", "Sleeping", "Doing Nothing", "Playing", "Relaxing" };
            var chart = new RadarChart
            {
             //   MaxDataValue = 100,
                StepSize = 1,
                Size = size,
                Categories = categories,
                DataSets = new[]
                {
                    new RadarChartSeries
                    {
                        Label = "My Life",
                        Color = Color.LightCoral,
                        Data = new[] { 0f, 2f, 0f, 0f, 4f, 1f, 0f, 0f, 0f, 0f } //GenerateRandomArray(random, categories.Length, 1, 10),
                    },
                    new RadarChartSeries
                    {
                        Label = "My Wife Life",
                        Color = Color.LightBlue,
                        Data = new[] { 0f, 2f, 0f, 0f, 4f, 1f, 0f, 0f, 0f, 0f } // GenerateRandomArray(random, categories.Length, 1, 10),
                    }
                }
            };

            return chart;
        }

        private static float[] GenerateRandomArray(Random random, int length, int min, int max)
        {
            var result = new float[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = random.Next(min, max) / 2f;
            }

            return result;
        }
    }
}