using System;
using System.Collections.Generic;

namespace Graph
{
    class Program
    {
        static void Main()
        {
            Node<int> n1 = new Node<int>(1);
            Node<int> n2 = new Node<int>(2);
            Node<int> n3 = new Node<int>(3);
            Node<int> n4 = new Node<int>(4);
            Node<int> n5 = new Node<int>(5);
            Node<int> n6 = new Node<int>(6);
            Node<int> n7 = new Node<int>(7);

            n1.AddNeighboor(n4, n5, n7);
            n2.AddNeighboor(n3, n5, n6);
            n3.AddNeighboor(n4, n5);
            n4.AddNeighboor(n5);
            n5.AddNeighboor(n7);
            n6.AddNeighboor(n7);

            Graph<int> graph = new Graph<int>(n1);

            List<Node<int>> list = graph.TopologicalReordering();
            foreach(Node<int> element in list)
            {
                Console.WriteLine(element.ToString());
            }

        }
    }
}
