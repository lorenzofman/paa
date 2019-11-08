using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class Graph<T>
    {
        public Node<T> firstNode;

        public Graph(Node<T> node)
        {
            this.firstNode = node;
        }

        public void Foreach(Action<Node<T>, Node<T>> action, bool direct)
        {
            Foreach(this.firstNode, direct, action);
        }
        public void Foreach(Node<T> currentNode, bool direct, Action<Node<T>, Node<T>> action)
        {
            Foreach(currentNode, null, new HashSet<Node<T>>(), direct, action);
        }
        private void Foreach(Node<T> currentNode, Node<T> previousNode, HashSet<Node<T>> visitedNodes, bool direct, Action<Node<T>, Node<T>> action)
        {
            if (visitedNodes.Contains(currentNode))
            {
                return;
            }

            action.Invoke(currentNode, previousNode);

            visitedNodes.Add(currentNode);

            foreach (Node<T> neighboor in currentNode.outNeighboors)
            {
                Foreach(neighboor, currentNode, visitedNodes, direct, action);
            }
            if(direct)
            {
                return;
            }
            foreach (Node<T> neighboor in currentNode.inNeighboors)
            {
                Foreach(neighboor, currentNode, visitedNodes, direct, action);
            }
        }

    }

}
