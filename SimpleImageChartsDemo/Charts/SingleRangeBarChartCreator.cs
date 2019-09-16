using GdiSharp.Models;
using SimpleImageCharts.SingleRangeBarChart;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsChart.Charts
{
    public static class SingleRangeBarChartCreator
    {
        public static SingleRangeBarChart CreateChart(Size size)
        {
            const float MinValue = 10;
            const float MaxValue = 15;
            var values = new[] { 10, 11, 12, 13, 14, 15 };
            var rand = new Random();
            var entries = new SingleRangeBarEntry[values.Length];

            for (int i = 0; i < entries.Length; i++)
            {
                entries[i] = new SingleRangeBarEntry
                {
                    Value = values[i],
                    Color = Color.FromArgb(rand.Next(0, 200), rand.Next(0, 200), rand.Next(0, 200)),
                    Label = "Data " + i
                };
            }

            var chart = new SingleRangeBarChart
            {
                MinValue = MinValue,
                MaxValue = MaxValue,
                Size = size,
                Entries = entries,
                LeftLabel = "Min \nvalue = 10",
                CenterLabel = "Center = ?",
                RightLabel = "Max \nvalue = 15",
                Font = new SlimFont("Arial", 12),
                TextColor = Color.Black
            };
            return chart;
        }
    }
}
