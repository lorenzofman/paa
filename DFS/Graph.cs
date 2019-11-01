using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class Graph<T> where T: IComparable
    {
        public Node<T> firstNode;

        public Graph(Node<T> node)
        {
            this.firstNode = node;
        }

        public Node<T> DepthFirstSearch(T element, bool verbose = false )
        {
            return DepthFirstSearch(firstNode, element, new HashSet<Node<T>>(), verbose);
        }

        private Node<T> DepthFirstSearch(Node<T> currentNode, T element, HashSet<Node<T>> visitedNodes, bool verbose)
        {
            Console.WriteLine($"Visiting node: {currentNode}");
            if (visitedNodes.Contains(currentNode))
            {
                if (verbose)
                {
                    Console.WriteLine("\tReturning because node was already visited");
                }
                return null;
            }

            if(currentNode.data.CompareTo(element) == 0)
            {
                if(verbose)
                {
                    Console.WriteLine($"\tElement found\n");
                }
                return currentNode;
            }

            if (verbose)
            {
                Console.WriteLine($"\tElement not found, adding node to visitedNodes\n");
            }
            visitedNodes.Add(currentNode);

            int i = 0;
            foreach(Node<T> neighboor in currentNode.neighboors)
            {
                Console.WriteLine($"Entering {currentNode} neighboor: {i++}");
                Node<T> neighboorSearch = DepthFirstSearch(neighboor, element, visitedNodes, verbose);
                if (neighboorSearch != null)
                {
                    return neighboorSearch;
                }
            }

            return null;
        }
    }

}
