using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class Node<T>
    {
        public T data;
        public HashSet<Node<T>> inNeighbors = new HashSet<Node<T>>();
        public HashSet<Node<T>> outNeighbors = new HashSet<Node<T>>();

        public Node(T data)
        {
            this.data = data;
        }

        public void AddNeighbor(params T[] Neighbors)
        {
            foreach (T Neighbor in Neighbors)
            {
                Node<T> NeighborNode = new Node<T>(Neighbor);
                AddNeighbor(NeighborNode);
            }
        }

        public void AddNeighbor(params Node<T>[] NeighborNodes)
        {
            foreach (Node<T> NeighborNode in NeighborNodes)
            {
                this.outNeighbors.Add(NeighborNode);
                NeighborNode.inNeighbors.Add(this);
            }
        }

        public override string ToString()
        {
            return $"Node<{ data.ToString() }>";
        }
    }
}
