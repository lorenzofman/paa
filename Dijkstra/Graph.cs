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

        #region DFS

        public void DepthForeachSearch(Action<Node<T>, List<Node<T>>> action)
        {
            DepthForeachSearch(this.firstNode, action);
        }
        public void DepthForeachSearch(Node<T> currentNode, Action<Node<T>, List<Node<T>>> action)
        {
            DepthForeachSearch(currentNode, new List<Node<T>>(), new HashSet<Node<T>>(), action);
        }
        private void DepthForeachSearch(Node<T> currentNode, List<Node<T>> previousNodes, HashSet<Node<T>> visitedNodes, Action<Node<T>, List<Node<T>>> action)
        {
            if (visitedNodes.Contains(currentNode))
            {
                return;
            }

            visitedNodes.Add(currentNode);

            previousNodes.Add(currentNode);

            action.Invoke(currentNode, previousNodes);

            foreach (Path<T> neighboor in currentNode.outNeighboors)
            {
                DepthForeachSearch(neighboor.node, new List<Node<T>>(previousNodes), visitedNodes, action);
            }
        }

        #endregion
    }

}
