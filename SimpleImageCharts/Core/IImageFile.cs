using System;
using System.Drawing;

namespace SimpleImageCharts.Core
{
    public interface IImageFile : IDisposable
    {
        Image GetImage();

        void Save(string filePath);
    }
}