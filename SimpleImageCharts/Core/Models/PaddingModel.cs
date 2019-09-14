namespace SimpleImageCharts.Core.Models
{
    public class PaddingModel
    {
        public int Right { get; set; }

        public int Top { get; set; }

        public int Bottom { get; set; }

        public int Left { get; set; }

        public PaddingModel(int value)
        {
            Left = Top = Right = Bottom = value;
        }
    }
}