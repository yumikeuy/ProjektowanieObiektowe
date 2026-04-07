using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Extensions.PointExtensions
{
    public static class PointExtension
    {
        public static Point Left(this Point p)
        {
            return new(p.X - 1, p.Y);
        }
        public static Point Right(this Point p)
        {
            return new(p.X + 1, p.Y);
        }
        public static Point Up(this Point p)
        {
            return new(p.X, p.Y - 1);
        }
        public static Point Down(this Point p)
        {
            return new(p.X, p.Y + 1);
        }
    }
}
