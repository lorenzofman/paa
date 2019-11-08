using System;

namespace Graph
{
    public struct Point
    {
        public int x, y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            return obj is Point point &&
                   this.x == point.x &&
                   this.y == point.y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.x, this.y);
        }

        public static bool operator == (Point a, Point b)
        {
            return a.x == b.x && a.y == b.y;
        }

        public static bool operator !=(Point a, Point b)
        {
            return !(a == b);
        }

        public int EuclidianDistance(Point other)
        {
            return Math.Abs(other.x - this.x) + Math.Abs(other.y - this.y);
        }

        public override string ToString()
        {
            return $"({this.x},{this.y})";
        }

    }
}
