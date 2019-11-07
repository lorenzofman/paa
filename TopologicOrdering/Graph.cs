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
        
        public List<Node<T>> TopologicalReordering()
        {
            List<Node<T>> orderedNodes = new List<Node<T>>();
            
            if(HasCycles())
            {
                Console.WriteLine("Has cycles");
                return orderedNodes;
            }

            Queue<Node<T>> nodes = new Queue<Node<T>>(FetchRootNodes());
            
            while(nodes.Count > 0)
            {
                Node<T> node = nodes.Dequeue();
                foreach(Node<T> outNeighbor in node.outNeighbors)
                {
                    outNeighbor.inNeighbors.Remove(node);
                    if(outNeighbor.inNeighbors.Count == 0)
                    {
                        nodes.Enqueue(outNeighbor);
                    }
                }
                orderedNodes.Add(node);
            }
            return orderedNodes;
        }
        private List<Node<T>> FetchRootNodes()
        {
            List<Node<T>> rootNodes = new List<Node<T>>();
            ForeachNode(firstNode, false, (node) =>
            {
                if (node.inNeighbors.Count == 0)
                {
                    rootNodes.Add(node);
                }
            });
            return rootNodes;
        }

        private bool HasCycles()
        {
            List<Node<T>> allNodes = new List<Node<T>>();
            ForeachNode(firstNode, true, node =>
            {
                allNodes.Add(node);
            });
            foreach(Node<T> node in allNodes)
            {
                foreach(Node<T> outNeighbor in node.outNeighbors)
                {
                    if(outNeighbor.outNeighbors.Contains(node))
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        private void ForeachNode(Node<T> currentNode, bool direct, Action<Node<T>> action)
        {
            ForeachNode(currentNode, new HashSet<Node<T>>(), direct, action);
        }
        private void ForeachNode(Node<T> currentNode, HashSet<Node<T>> visitedNodes, bool direct, Action<Node<T>> action)
        {
            if (visitedNodes.Contains(currentNode))
            {
                return;
            }

            action.Invoke(currentNode);

            visitedNodes.Add(currentNode);

            foreach (Node<T> Neighbor in currentNode.outNeighbors)
            {
                ForeachNode(Neighbor, visitedNodes, direct, action);
            }
            if(direct)
            {
                return;
            }
            foreach (Node<T> Neighbor in currentNode.inNeighbors)
            {
                ForeachNode(Neighbor, visitedNodes, direct, action);
            }
        }
    }

}
