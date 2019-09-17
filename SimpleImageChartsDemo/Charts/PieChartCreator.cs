using SimpleImageCharts.Enum;
using SimpleImageCharts.PieChart;
using System;
using System.Drawing;

namespace WindowsFormsChart.Charts
{
    public static class PieChartCreator
    {
        public static PieChart CreatePie(Size size)
        {
            PieEntry[] entries = CreatePieEntries();

            var chart = new PieChart
            {
                Size = size,
                Entries = entries
            };

            return chart;
        }

        public static PieChart CreateDonut(Size size)
        {
            PieEntry[] entries = CreatePieEntries();

            var chart = new PieChart
            {
                Size = size,
                Entries = entries,
                IsDonut = true,
                PieAlign = HorizontalAlign.Right
            };

            return chart;
        }

        private static PieEntry[] CreatePieEntries()
        {
            var rand = new Random();
            var entries = new PieEntry[10];
            for (int i = 0; i < entries.Length; i++)
            {
                entries[i] = new PieEntry
                {
                    Value = (float)rand.Next(10, 40) / 10,
                    Color = Color.FromArgb(rand.Next(0, 200), rand.Next(0, 200), rand.Next(0, 200)),
                    Label = "Data " + i
                };
            }

            return entries;
        }
    }
}