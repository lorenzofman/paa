﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class Graph<T> where T : IComparable
    {
        public Node<T> firstNode;

        public Graph(Node<T> node)
        {
            this.firstNode = node;
        }
        
        public List<Node<T>> FetchRootNodes()
        {
            List<Node<T>> rootNodes = new List<Node<T>>();
            GraphForeach(firstNode, (node) =>
            {
                if(node.inNeighboors.Count == 0)
                {
                    rootNodes.Add(node);
                }
            }, false);
            return rootNodes;
        }

        private void GraphForeach(Node<T> currentNode, Action<Node<T>> action, bool direct)
        {
            GraphForeach(currentNode, new HashSet<Node<T>>(), action, direct);
        }
        private void GraphForeach(Node<T> currentNode, HashSet<Node<T>> visitedNodes, Action<Node<T>> action, bool direct)
        {
            if (visitedNodes.Contains(currentNode))
            {
                return;
            }

            action.Invoke(currentNode);

            visitedNodes.Add(currentNode);

            foreach (Node<T> neighboor in currentNode.outNeighboors)
            {
                GraphForeach(neighboor, visitedNodes, action, direct);
            }
            if(direct)
            {
                return;
            }
            foreach (Node<T> neighboor in currentNode.inNeighboors)
            {
                GraphForeach(neighboor, visitedNodes, action, direct);
            }
        }

    }

}
