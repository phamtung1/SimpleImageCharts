using SimpleImageCharts.Core;
using System.Collections.Generic;
using System.Drawing;

namespace SimpleImageCharts.SingleRangeBarChart
{
    public interface ISingleRangeBarChart : IBaseChart
    {
        string CenterLabel { get; set; }
        IEnumerable<SingleRangeBarEntry> Entries { get; set; }
        string LeftLabel { get; set; }
        float MaxValue { get; set; }
        float MinValue { get; set; }
        string RightLabel { get; set; }
        Color TextColor { get; set; }
    }
}