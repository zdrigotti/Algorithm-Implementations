using System;
using System.Collections.Generic;

namespace TopologicalSort
{
    class Topologicalsort
    {
        /// <summary>
        /// Given a graph, performs a topological sort
        /// </summary>
        /// <param name="graph">Graph to sort</param>
        /// <returns>List of graph values sorted topologically</returns>
        public static List<int> TopologicalSort(List<int>[] graph)
        {
            int vertices = graph.Length;
            List<int> sorted = new List<int>();
            bool[] visited = new bool[vertices];

            for (int vertex = 0; vertex < vertices; vertex++)
            {
                if (!visited[vertex])
                {
                    DFS(graph, visited, sorted, vertex);
                }
            }

            sorted.Reverse();
            return sorted;
        }

        /// <summary>
        /// Performs a depth first search over the graph starting at a 
        /// given vertex
        /// </summary>
        /// <param name="graph">Graph to sort</param>
        /// <param name="visited">Visited nodes</param>
        /// <param name="sorted">Current list of sorted nodes</param>
        /// <param name="vertex">Current vertex</param>
        public static void DFS(List<int>[] graph, bool[] visited, List<int> sorted, int vertex)
        {
            visited[vertex] = true;

            foreach (int adjacentVertex in graph[vertex])
            {
                if (!visited[adjacentVertex])
                {
                    DFS(graph, visited, sorted, adjacentVertex);
                }
            }

            sorted.Add(vertex);
        }

        static void Main(string[] args)
        {
            // Construct our graph
            int n = 6;
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }

            graph[5].Add(0);
            graph[5].Add(2);
            graph[4].Add(0);
            graph[4].Add(1);
            graph[2].Add(3);
            graph[3].Add(1);

            // Sort it
            List<int> sortedValues = TopologicalSort(graph);

            foreach(int value in sortedValues)
            {
                Console.WriteLine(value);
            }
            
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
