using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    class Program
    {
        private const int width = 5;
        private const int height = 5;
        private const int maxEuclidianDistance = 2;
        private static Point aInitialPosition = new Point(0, 0);
        private static Point bInitialPosition = new Point(4, 4);    

        private static Point aFinalPosition = new Point(4, 4);
        private static Point bFinalPosition = new Point(0, 0);

        private static Node<(Point, Point)> initialNode;

        private static List<List<(Point, Point)>> paths = new List<List<(Point, Point)>>();

        private static HashSet<List<(Point, Point)>> correctPaths = new HashSet<List<(Point, Point)>>();

        static void Main()
        {
            List<Point> points = CreateNodeMatrix(width, height);
            List<(Point, Point)> configurations = CreateConfigurations(points);
            FilterConfigurationGraph(configurations);
            Graph<(Point, Point)> configGraph = ConnectConfigurationGraph(configurations);
            configGraph.Foreach(initialNode, false, (currentNode, previousNode) => ConfigurationGraphAction(currentNode, previousNode));
            Console.WriteLine("Paths:");
            PrintCorrectPaths();
        }

        private static void PrintCorrectPaths()
        {
            foreach (List<(Point, Point)> correctPath in correctPaths)
            {
                foreach ((Point, Point) config in correctPath)
                {
                    Console.WriteLine(FormatConfig(config));
                }
                Console.WriteLine("$");
            }
        }

        private static void ConfigurationGraphAction(Node<(Point a, Point b)> currentPoint, Node<(Point a, Point b)> previousNode)
        {
            if(previousNode == null)
            {
                paths.Add(new List<(Point, Point)>());
            }
            if(previousNode == initialNode)
            {
                paths.Add(new List<(Point, Point)>());
                paths.Last().Add(initialNode.data);
            }

            List<(Point, Point)> currentPath = paths.Last();

            if (correctPaths.Contains(currentPath))
            {
                return;
            }

            currentPath.Add(currentPoint.data);

            if(currentPoint.data.a == aFinalPosition && currentPoint.data.b == bFinalPosition)
            {
                correctPaths.Add(currentPath);
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

        private static List<(Point, Point)> CreateConfigurations(List<Point> gridPoints)
        {
            List<Point> gridPointsDeepCopy = gridPoints.Select(x => x).ToList();
            List<(Point, Point)> points = new List<(Point, Point)>(gridPoints.Count * gridPoints.Count);
            for (int i = 0; i < gridPoints.Count; i++)
            {
                for (int j = 0; j < gridPoints.Count; j++)
                {
                    points.Add((gridPoints[i], gridPoints[j]));
                }
            }
            return points;
        }


        private static void FilterConfigurationGraph(List<(Point, Point)> configurations)
        {
            for (int i = configurations.Count - 1; i >= 0; i--)
            {
                (Point p1, Point p2) config = configurations[i];
                if (config.p1.EuclidianDistance(config.p2) < maxEuclidianDistance)
                {
                    configurations.Remove(config);
                }
            }
        }

        private static Graph<(Point, Point)> ConnectConfigurationGraph(List<(Point, Point)> configurations)
        {
            List<Node<(Point a, Point b)>> nodePoints = configurations.Select(point => new Node<(Point, Point)>(point)).ToList();
            initialNode = nodePoints.Find(nodeTuple => 
                nodeTuple.data.a == aInitialPosition && 
                nodeTuple.data.b == bInitialPosition);
            foreach(Node<(Point a, Point b)> n1 in nodePoints)
            {
                foreach (Node<(Point a, Point b)> n2 in nodePoints)
                {
                    if ((n1.data.a.EuclidianDistance(n2.data.a) + (n1.data.b.EuclidianDistance(n2.data.b)) == 1))
                    {
                        n1.AddNeighboor(n2);
                        Console.WriteLine($"Connecting {FormatConfig(n1.data)} -> {FormatConfig(n2.data)}");
                    }

                }
            }
            return new Graph<(Point, Point)>(nodePoints.First());
        }

        private static string FormatConfig((Point a, Point b) config)
        {
            return $"({config.a.x},{config.a.y}) - ({config.b.x},{config.b.y})";
        }
    }
}
