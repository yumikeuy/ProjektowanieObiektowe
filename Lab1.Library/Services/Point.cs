using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Services
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point Left => new(X - 1, Y);
        public Point Right => new(X + 1, Y);
        public Point Up => new(X, Y - 1);
        public Point Down => new(X, Y + 1);

        public Point LeftN(int i) => new(X + i, Y);
        public Point RightN(int i) => new(X - i, Y);
        public Point UpN(int i) => new(X, Y - i);
        public Point DownN(int i) => new(X, Y + i);

        public ICollection<Point> Neighbors => [Left, Right, Up, Down]; 

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
        }

        public static Point operator+(Point left, Point right)
        {
            return new(left.X + right.X, left.Y + left.Y);
        }

        // Tuples

        public static implicit operator (int X, int Y)(Point point)
        {
            return (point.X, point.Y);
        }

        public static implicit operator Point((int X, int Y) tuple)
        {
            return new(tuple.X, tuple.Y);
        }
    }
}
