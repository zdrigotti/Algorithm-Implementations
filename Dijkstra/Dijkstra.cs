using System;

namespace Dijkstra
{
    class Dijkstra
    {
        /// <summary>
        /// Calculates the shortest path to each vertex in the graph given a source vertex
        /// </summary>
        /// <param name="graph">Graph to calculate paths within</param>
        /// <param name="source">Vertex to calculate distances from</param>
        /// <param name="size">Size of the graph</param>
        /// <returns>An indexed array containing the distance to each vertex</returns>
        public static int[] CalculatePaths(int[,] graph, int source, int size)
        {
            int[] distances = new int[size];
            bool[] visited = new bool[size];

            for (int i = 0; i < size; i++)
            {
                distances[i] = (source == i) ? 0 : int.MaxValue;
                visited[i] = false;
            }

            for (int count = 0; count < size; count++)
            {
                int u = MinimumDistanceVertex(distances, visited, size);

                visited[u] = true;

                for (int v = 0; v < size; v++)
                {
                    if (!visited[v] && graph[u, v] != 0
                        && distances[u] != int.MaxValue
                        && distances[u] + graph[u, v] < distances[v])
                    {
                        distances[v] = distances[u] + graph[u, v];
                    }
                }
            }

            return distances;
        }

        /// <summary>
        /// Determines the index of the vertex with the minimum distance from the source
        /// </summary>
        /// <param name="distances">Current distances from the source vertex</param>
        /// <param name="visited">Vertices that have been visited</param>
        /// <param name="size">Size of the distances array</param>
        /// <returns>Index of the vertex with the minimum distance from the source</returns>
        private static int MinimumDistanceVertex(int[] distances, bool[] visited, int size)
        {
            int minValue = int.MaxValue, minIndex = -1;

            for (int v = 0; v < size; v++)
            {
                if (!visited[v] && distances[v] <= minValue)
                {
                    minValue = distances[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        static void Main(string[] args)
        {
            // Construct our graph
            int[,] graph = {
                {0, 4, 0, 0, 0, 0, 0, 8, 0},
                {4, 0, 8, 0, 0, 0, 0, 11, 0},
                {0, 8, 0, 7, 0, 4, 0, 0, 2},
                {0, 0, 7, 0, 9, 14, 0, 0, 0},
                {0, 0, 0, 9, 0, 10, 0, 0, 0},
                {0, 0, 4, 14, 10, 0, 2, 0, 0},
                {0, 0, 0, 0, 0, 2, 0, 1, 6},
                {8, 11, 0, 0, 0, 0, 1, 0, 7},
                {0, 0, 2, 0, 0, 0, 6, 7, 0}
             };

            // Calculate our shortest paths and print
            int[] shortestPaths = CalculatePaths(graph, 0, 9);

            Console.WriteLine("Vertex    Distance from source");

            for (int i = 0; i < shortestPaths.Length; ++i)
            {
                Console.WriteLine("{0}\t  {1}", i, shortestPaths[i]);
            }
            
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
