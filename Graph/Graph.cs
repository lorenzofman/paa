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

            foreach (Node<T> neighboor in currentNode.outNeighboors)
            {
                DepthForeachSearch(neighboor, new List<Node<T>>(previousNodes), visitedNodes, action);
            }
        }

        #endregion

        #region BFS
        public void BreadthForeachSearch(Action<Node<T>> action)
        {
            BreadthForeachSearch(this.firstNode, action);
        }
        public void BreadthForeachSearch(Node<T> firstNode, Action<Node<T>> action)
        {
            Queue<Node<T>> queue = new Queue<Node<T>>();
            HashSet<Node<T>> visitedNodes = new HashSet<Node<T>>();

            queue.Enqueue(firstNode);
            visitedNodes.Add(firstNode);
            action.Invoke(firstNode);

            BreadthForeachSearch(firstNode, visitedNodes, queue, action);
        }

        private void BreadthForeachSearch(Node<T> previousNode, HashSet<Node<T>> visitedNodes, Queue<Node<T>> queue, Action<Node<T>> action)
        {
            if(queue.Count == 0)
            {
                return;
            }

            Node<T> currentNode = queue.Dequeue();

            foreach (Node<T> neighboor in currentNode.outNeighboors)
            {
                if (visitedNodes.Contains(neighboor))
                {
                    continue;
                }
                neighboor.backtraceNodes.AddRange(previousNode.backtraceNodes);
                neighboor.backtraceNodes.Add(previousNode);
                visitedNodes.Add(neighboor);
                action.Invoke(neighboor);
                queue.Enqueue(neighboor);
            }
            BreadthForeachSearch(currentNode, visitedNodes, queue, action);
           
        }
        #endregion
    }

}
