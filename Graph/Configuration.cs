using System;
using System.Collections.Generic;

namespace Graph
{
    public struct Configuration
    {
        public Point a;
        public Point b;

        public Configuration(Point a, Point b)
        {
            this.a = a;
            this.b = b;
        }

        public override string ToString()
        {
            return $"{a} <-> {b}";
        }
    }
}
