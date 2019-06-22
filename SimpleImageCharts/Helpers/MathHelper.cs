using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SimpleImageCharts.Helpers
{
    public static class MathHelper
    {
        public static PointF DegreeToPoint(float degree, float radius, PointF center)
        {
            var radian = degree * Math.PI / 180.0;

            return new PointF
            {
                X = (float)Math.Cos(radian) * radius + center.X,
                Y = (float)Math.Sin(-radian) * radius + center.Y
            };
        }
    }
}
