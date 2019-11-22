using Graph;
using System;
using System.Collections.Generic;

namespace Dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<int> n0 = new Node<int>(0);
            Node<int> n1 = new Node<int>(1);
            Node<int> n2 = new Node<int>(2);
            Node<int> n3 = new Node<int>(3);
            Node<int> n4 = new Node<int>(4);

            n0.AddNeighboor(
                new Path<int>(n1, 3),
                new Path<int>(n2, 1));

            n1.AddNeighboor(
                new Path<int>(n0, 3),
                new Path<int>(n2, 7),
                new Path<int>(n3, 5));

            n2.AddNeighboor(
                new Path<int>(n0, 3),
                new Path<int>(n1, 7),
                new Path<int>(n3, 2));

            n3.AddNeighboor(
                new Path<int>(n1, 5),
                new Path<int>(n2, 2),
                new Path<int>(n4, 7));

            n4.AddNeighboor(
                new Path<int>(n1, 4),
                new Path<int>(n3, 7));
            Graph<int> graph = new Graph<int>(n0);
            List<Node<int>> path = Dijkstra.ShortestPath(graph, n0, n4);
            foreach(Node<int> node in path)
            {
                Console.WriteLine(node);
            }
        }
    }
}
