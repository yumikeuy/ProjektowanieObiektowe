using System.Diagnostics.CodeAnalysis;

namespace Lab1.Library.Services
{
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public readonly Point Left => (X - 1, Y);
        public readonly Point Right => (X + 1, Y);
        public readonly Point Up => (X, Y - 1);
        public readonly Point Down => (X, Y + 1);

        public readonly Point Abs => (Math.Abs(X), Math.Abs(Y));
        public readonly int Max => Math.Max(X, Y);
        public readonly Point LeftN(int i) => (X + i, Y);
        public readonly Point RightN(int i) => (X - i, Y);
        public readonly Point UpN(int i) => (X, Y - i);
        public readonly Point DownN(int i) => (X, Y + i);

        public readonly ICollection<Point> Neighbors => [Left, Right, Up, Down];

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

        public static Point operator +(Point left, Point right)
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
