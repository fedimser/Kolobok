using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace KolobokGame
{
    public class Geometry
    {

        public static float dist(PointF p1, PointF p2)
        {
            return (float) Math.Sqrt((double)(sqr(p1.X-p2.X) +sqr(p1.Y-p2.Y)));
        }

        public static PointF divide(PointF p1,PointF p2, float k)
        {
            return new PointF(p1.X + k * (p2.X - p1.X), p1.Y + k * (p2.Y - p1.Y));
        }

        public static Point divide(Point p1, Point p2, float k)
        {
            return new Point(Convert.ToInt32(p1.X + k * (p2.X - p1.X)), Convert.ToInt32(p1.Y + k * (p2.Y - p1.Y)));
        }


        private static float sqr(float x)
        {
            return x * x;
        }

        
    }
}
