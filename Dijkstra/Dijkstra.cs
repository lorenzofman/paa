using Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dijkstra
{
    class Dijkstra
    {
        private static int infinity = int.MaxValue;
        public static List<Node<T>> ShortestPath<T>(Graph<T> graph, Node<T> source, Node<T> target)
        {
            List<Node<T>> allNodes = FetchAllNodes(graph);
            if (allNodes.Count == 0)
            {
                return null;
            }

            HashSet<Node<T>> visitedNodes = new HashSet<Node<T>>(allNodes.Count);
            Dictionary<Node<T>, int> costsLookup = CreateCostsStructure(source, infinity, allNodes);

            Dictionary<Node<T>, Node<T>> previousNodeLookup = new Dictionary<Node<T>, Node<T>>();
            allNodes.ForEach(node => previousNodeLookup.Add(node, null));
            allNodes.Remove(source);
            List<Node<T>> nodesQueue = new List<Node<T>>(allNodes);
            while(nodesQueue.Count > 0)
            {
                (int cost, Node<T> node) min = nodesQueue.Select(node => (costsLookup[node], node)).Min();
                nodesQueue.Remove(min.node);
                Node<T> u = min.node;
                foreach(Path<T> v in u.outNeighboors)
                {
                    if(visitedNodes.Contains(v.node))
                    {
                        continue;
                    }
                    visitedNodes.Add(v.node);
                    int alt = costsLookup[u] + v.cost;
                    if (alt < costsLookup[v.node])
                    {
                        costsLookup[v.node] = alt;
                        previousNodeLookup[v.node] = u;
                    }
                }
            }
            List<Node<T>> invertedPath = new List<Node<T>>();
            for (Node<T> node = target; node != null; target = previousNodeLookup[target])
            {
                invertedPath.Add(node);
            }
            invertedPath.Reverse();
            return invertedPath;
        }

        private static Dictionary<Node<T>, int> CreateCostsStructure<T>(Node<T> node, int infinity, List<Node<T>> allNodes)
        {
            Dictionary<Node<T>, int> costs = new Dictionary<Node<T>, int>(allNodes.Count)
            {
                { node, 0 }
            };

            for (int i = 1; i < allNodes.Count; i++)
            {
                costs.Add(allNodes[i], infinity);
            }

            return costs;
        }

        private static List<Node<T>> FetchAllNodes<T>(Graph<T> graph)
        {
            List<Node<T>> nodes = new List<Node<T>>();
            graph.DepthForeachSearch((node, _) => nodes.Add(node));
            return nodes;
        }
    }
}
