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
            List<Node<T>> nodes = new List<Node<T>>(allNodes);
            while(nodes.Count > 0)
            {
                (int cost, Node<T> node) min = Min(nodes, costsLookup);
                nodes.Remove(min.node);
                Node<T> v = min.node;
                foreach(Path<T> u in v.outNeighboors)
                {
                    if(visitedNodes.Contains(u.node))
                    {
                        continue;
                    }
                    visitedNodes.Add(u.node);
                    int alt = costsLookup[v] + u.cost;
                    if (alt < costsLookup[u.node])
                    {
                        costsLookup[u.node] = alt;
                        previousNodeLookup[u.node] = v;
                    }
                }
            }
            List<Node<T>> invertedPath = new List<Node<T>>();
            for (Node<T> node = target; node != null; node = previousNodeLookup[node])
            {
                invertedPath.Add(node);
            }
            invertedPath.Reverse();
            return invertedPath;
        }

        private static (int cost, Node<T> node) Min<T>(List<Node<T>> nodes, Dictionary<Node<T>, int> costsLookup)
        {
            (int cost, Node<T> node) min = (costsLookup[nodes[0]], nodes[0]);
            for (int i = 1; i < nodes.Count; i++)
            {
                if(costsLookup[nodes[i]] < min.cost)
                {
                    min = (costsLookup[nodes[i]], nodes[i]);
                }
            }
            return min;
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
