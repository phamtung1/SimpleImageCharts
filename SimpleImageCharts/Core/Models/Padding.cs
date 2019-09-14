namespace SimpleImageCharts.Core.Models
{
    public struct Padding
    {
        public readonly int Right;

        public readonly int Top;

        public readonly int Bottom;

        public readonly int Left;

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