using System;

namespace Graph
{
    class Program
    {
        static void Main()
        {
            Node<int> n1 = new Node<int>(4);
            Node<int> n2 = new Node<int>(3);
            Node<int> n3 = new Node<int>(-2);
            Node<int> n4 = new Node<int>(2);
            Node<int> n5 = new Node<int>(0);
            Node<int> n6 = new Node<int>(1);
            Node<int> n7 = new Node<int>(1);
            Node<int> n8 = new Node<int>(8);
            Node<int> n9 = new Node<int>(10);
            Node<int> n10 = new Node<int>(12);
            Node<int> n11 = new Node<int>(-9);
            Node<int> n12 = new Node<int>(-21);
            Node<int> n13 = new Node<int>(13);

            n1.AddNeighboor(n2, n3, n4);

            n2.AddNeighboor(n3, n4, n5);

            n3.AddNeighboor(n6, n7);

            n4.AddNeighboor(n6);

            n5.AddNeighboor(n6, n11);

            n6.AddNeighboor(n7, n8, n9, n10);

            n7.AddNeighboor(n9, n11, n12);

            n8.AddNeighboor(n13);

            n11.AddNeighboor(n12, n13);


            Graph<int> graph = new Graph<int>(n1);

            graph.DepthFirstSearch(-1, true);

        }
    }
}
