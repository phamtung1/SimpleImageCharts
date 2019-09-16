namespace SimpleImageCharts.Core.Models
{
    public class Padding
    {
        public int Right { get; set; }

        public int Top { get; set; }

        public int Bottom { get; set; }

        public int Left { get; set; }

        public Padding(int all)
        {
            Left = Top = Right = Bottom = all;
        }

        public Padding(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }
    }
}