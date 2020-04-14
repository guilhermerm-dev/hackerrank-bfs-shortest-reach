using System;
using System.Linq;
using System.Collections.Generic;

namespace hackerrank_bfs_shortest_reach
{
    class Program
    {

        private static readonly int _edgeWeight = 6;

        static void Main()
        {
            int numberOfQueries = int.Parse(Console.ReadLine());

            for (int numberOfQuery = 1; numberOfQuery <= numberOfQueries; numberOfQuery++)
            {
                int[] numberOfNodesAndEdges = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

                int numberOfNodes = numberOfNodesAndEdges[0];
                int numberOfEdges = numberOfNodesAndEdges[1];

                List<int[]> connections = new List<int[]>();

                for (int i = 0; i < numberOfEdges; i++)
                {
                    int[] connection = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
                    connections.Add(connection);
                }

                int sourceNode = int.Parse(Console.ReadLine());

                Node[] nodes = new Node[numberOfNodes + 1];
                nodes[0] = null;
                for (int i = 1; i <= numberOfNodes; i++)
                {
                    nodes[i] = new Node(i);
                }

                connections.ForEach(connection =>
                {
                    Node nodeU = nodes[connection[0]];
                    Node nodeV = nodes[connection[1]];
                    nodeU.ConnectTo(nodeV);
                });

                FindDistances(nodes[sourceNode]);

                for (int node = 1; node <= numberOfNodes; node++)
                {
                    if (node != sourceNode)
                    {
                        Console.Write($"{nodes[node].Distance} ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static void FindDistances(Node start)
        {
            if (start == null)
                return;

            start.SetDistance(0);
            List<Node> queue = new List<Node> { start };
            while (queue.Count() != 0)
            {
                Node current = queue.First();
                queue.Remove(current);
                foreach (Node neighbor in current.Neighbors)
                {
                    if (WasTheNeighborVisited(neighbor))
                    {
                        neighbor.SetDistance(current.Distance + _edgeWeight);
                        queue.Add(neighbor);
                    }
                }
            }
        }


        private static bool WasTheNeighborVisited(Node neighbor)
        {
            return neighbor.Distance.Equals(-1);
        }
    }
}
