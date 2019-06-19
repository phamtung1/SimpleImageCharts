using System;
using System.Drawing;
using System.IO;

namespace SimpleImageCharts
{
    public static class Class1
    {
        public static string StreamToString(Stream imageStream)
        {
            using (var memoryStream = new MemoryStream())
            {
                imageStream.CopyTo(memoryStream);
                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }

        public static Image Decode(string imageString)
        {
            byte[] imageBytes = Convert.FromBase64String(imageString);
            return Image.FromStream(new MemoryStream(imageBytes));
        }
    }
}