using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class Topologic<T> where T : IComparable
    {
        public List<Node<T>> Reordering(Graph<T> graph)
        {
            List<Node<T>> orderedNodes = new List<Node<T>>();
            Queue<Node<T>> nodes = new Queue<Node<T>>(graph.FetchRootNodes());
            while (nodes.Count > 0)
            {
                Node<T> node = nodes.Dequeue();
                foreach (Node<T> outNeighboor in node.outNeighboors)
                {
                    outNeighboor.inNeighboors.Remove(node);
                    if (outNeighboor.inNeighboors.Count == 0)
                    {
                        nodes.Enqueue(outNeighboor);
                    }
                }
                orderedNodes.Add(node);
            }
            return orderedNodes;
        }
    }
}
