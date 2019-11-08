using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    class Program
    {
        private const int width = 2;
        private const int height = 2;
        private const int maxEuclidianDistance = 1;
        private static Point aInitialPosition = new Point(0, 0);
        private static Point bInitialPosition = new Point(1, 1);    

        private static Point aFinalPosition = new Point(1, 1);
        private static Point bFinalPosition = new Point(0, 0);

        private static Node<Configuration> initialNode;

        private static HashSet<List<Configuration>> correctPaths = new HashSet<List<Configuration>>();

        static void Main()
        {
            List<Point> points = CreateNodeMatrix(width, height);
            List<Configuration> configurations = CreateConfigurations(points);
            FilterConfigurationGraph(configurations);
            Graph<Configuration> configGraph = ConnectConfigurationGraph(configurations);
            configGraph.BreadthForeachSearch(initialNode, (currentNode) => ConfigurationGraphAction(currentNode));
            Console.WriteLine("Path:");
            PrintCorrectPaths();
        }

        private static void PrintCorrectPaths()
        {
            foreach (List<Configuration> correctPath in correctPaths)
            {
                foreach (Configuration config in correctPath)
                {
                    Console.WriteLine(FormatConfig(config));
                }
            }
        }

        private static void ConfigurationGraphAction(Node<Configuration> currentNode)
        {
            if (currentNode.data.a == aFinalPosition && currentNode.data.b == bFinalPosition)
            {
                List<Configuration> backTracePath = new List<Configuration>();
                backTracePath.AddRange(currentNode.backtraceNodes.Select(x => x.data));
                backTracePath.Add(currentNode.data);
                correctPaths.Add(backTracePath);
            }
        }

        private static List<Point> CreateNodeMatrix(int width, int height)
        {
            List<Point> points = new List<Point>(width * height);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    points.Add(new Point(i, j));
                }
            }
            return points;
        }

        private static List<Configuration> CreateConfigurations(List<Point> gridPoints)
        {
            List<Point> gridPointsDeepCopy = gridPoints.Select(x => x).ToList();
            List<Configuration> points = new List<Configuration>(gridPoints.Count * gridPoints.Count);
            for (int i = 0; i < gridPoints.Count; i++)
            {
                for (int j = 0; j < gridPoints.Count; j++)
                {
                    points.Add(new Configuration(gridPoints[i], gridPoints[j]));
                }
            }
            return points;
        }


        private static void FilterConfigurationGraph(List<Configuration> configurations)
        {
            for (int i = configurations.Count - 1; i >= 0; i--)
            {
                Configuration config = configurations[i];
                if (config.a.EuclidianDistance(config.b) < maxEuclidianDistance)
                {
                    configurations.Remove(config);
                }
            }
        }

        private static Graph<Configuration> ConnectConfigurationGraph(List<Configuration> configurations)
        {
            List<Node<Configuration>> nodePoints = configurations.Select(point => new Node<Configuration>(point)).ToList();
            initialNode = nodePoints.Find(nodeTuple => 
                nodeTuple.data.a == aInitialPosition && 
                nodeTuple.data.b == bInitialPosition);
            foreach(Node<Configuration> n1 in nodePoints)
            {
                foreach (Node<Configuration> n2 in nodePoints)
                {
                    if ((n1.data.a.EuclidianDistance(n2.data.a) + (n1.data.b.EuclidianDistance(n2.data.b)) == 1))
                    {
                        n1.AddNeighboor(n2);
                    }

                }
            }
            return new Graph<Configuration>(nodePoints.First());
        }

        private static string FormatConfig(Configuration config)
        {
            return $"({config.a.x},{config.a.y}) - ({config.b.x},{config.b.y})";
        }
    }
}
