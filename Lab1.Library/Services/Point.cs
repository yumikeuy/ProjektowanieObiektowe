using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Services
{
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point Left => (X - 1, Y);
        public Point Right => (X + 1, Y);
        public Point Up => (X, Y - 1);
        public Point Down => (X, Y + 1);

        public Point Abs => (Math.Abs(X), Math.Abs(Y));
        public int Max => Math.Max(X, Y);
        public Point LeftN(int i) => (X + i, Y);
        public Point RightN(int i) => (X - i, Y);
        public Point UpN(int i) => (X, Y - i);
        public Point DownN(int i) => (X, Y + i);

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
            return (left.X + right.X, left.Y + right.Y);
        }
        public static Point operator -(Point left, Point right)
        {
            return (left.X - right.X, left.Y - right.Y);
        }
        public static Point operator /(Point left, int a)
        {
            return (left.X / a, left.Y / a);
        }
        public static Point operator *(Point left, int a)
        {
            return (left.X * a, left.Y * a);
        }
        public static bool operator ==(Point left, Point right)
        {
            return left.X == right.X && left.Y == right.Y;
        }
        public static bool operator !=(Point left, Point right)
        {
            return !(left == right);
        }
        public static bool operator >(Point left, Point right)
        {
            return left.X > right.X && left.Y > right.Y;
        }
        public static bool operator <(Point left, Point right)
        {
            return left.X < right.X && left.Y < right.Y;
        }
        public static bool operator >=(Point left, Point right)
        {
            return left.X >= right.X && left.Y >= right.Y;
        }
        public static bool operator <=(Point left, Point right)
        {
            return left.X <= right.X && left.Y <= right.Y;
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
         

        public static implicit operator (int X, int Y)(Point point)
        {
            return (point.X, point.Y);
        }

        public static implicit operator Point((int X, int Y) tuple)
        {
            return new(tuple.X, tuple.Y);
        }

        public int LinearDistance(Point point)
        {
            return (this - point).Abs.Max;
        }

        public static int LinearDistance(Point point1, Point point2)
        {
            return point1.LinearDistance(point2);
        }
    }
}
