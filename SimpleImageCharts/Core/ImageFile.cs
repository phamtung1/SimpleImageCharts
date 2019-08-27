using System;
using System.Drawing;

namespace SimpleImageCharts.Core
{
    public class ImageFile : IImageFile
    {
        private readonly Image _image;
        private bool _disposed = false;

        public ImageFile(Image image)
        {
            _image = image;
        }

        public Image GetImage()
        {
            return _image;
        }

        public void Save(string filePath)
        {
            _image.Save(filePath);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _image.Dispose();
            }

            _disposed = true;
        }
    }
}