using System;
using System.Collections.Generic;
using System.Linq;

namespace ZombieClusters
{
    class Program
    {
        public class Graph
        {
            public Dictionary<int, HashSet<int>> AdjacencyList { get; } = new Dictionary<int, HashSet<int>>();

            public Graph() { }

            public Graph(IEnumerable<int> vertices, IEnumerable<Tuple<int, int>> edges)
            {
                foreach (var vertex in vertices)
                    AddVertex(vertex);

                foreach (var edge in edges)
                    AddEdges(edge);
            }

            private void AddVertex(int vertex)
            {
                AdjacencyList[vertex] = new HashSet<int>();
            }

            private void AddEdges(Tuple<int, int> edge)
            {
                if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
                {
                    AdjacencyList[edge.Item1].Add(edge.Item2);
                    AdjacencyList[edge.Item2].Add(edge.Item1);
                }
            }
        }

        public class Algorithm
        {
            public Algorithm() { }

            public int GetClusterCount(Graph graph)
            {
                int cluster = 0;
                var visited = new HashSet<int>();

                for (int i = 0; i < graph.AdjacencyList.Count; i++)
                {
                    if (visited.Contains(i)) continue;

                    var stack = new Stack<int>();
                    stack.Push(i);

                    while (stack.Count > 0)
                    {
                        var item = stack.Pop();

                        if (visited.Contains(item))
                            continue;

                        visited.Add(item);

                        foreach (var adj in graph.AdjacencyList[item])
                        {
                            if (!visited.Contains(adj))
                                stack.Push(adj);
                        }
                    }
                    cluster++;
                }
                return cluster;
            }
        }

        class Result
        {
            public static int zombieCluster(List<string> zombies)
            {
                var vertices = Enumerable.Range(0, zombies.Count);
                var edges = new List<Tuple<int, int>>();
                for (int i = 0; i < zombies.Count - 1; i++)
                {
                    for (int j = 0; j < zombies[i].Length; j++)
                    {
                        if (i != j && zombies[i][j] == '1')
                            edges.Add(Tuple.Create(i, j));
                    }
                }

                var graph = new Graph(vertices, edges);
                var algorithm = new Algorithm();

                return algorithm.GetClusterCount(graph);
            }
        }


        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int zombiesCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<string> zombies = new List<string>();

            for (int i = 0; i < zombiesCount; i++)
            {
                string zombiesItem = Console.ReadLine();
                zombies.Add(zombiesItem);
            }

            int result = Result.zombieCluster(zombies);

            Console.WriteLine(result);
            Console.ReadKey();
            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
