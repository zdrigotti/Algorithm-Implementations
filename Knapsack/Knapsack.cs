using System;

namespace Knapsack
{
    class Knapsack
    {
        /// <summary>
        /// Determines the maximum value of items that can be placed
        /// in a knapsack given a weight constraing
        /// </summary>
        /// <param name="W">Capacity of the knapsack</param>
        /// <param name="wt">Weights of the items</param>
        /// <param name="val">Values of the items</param>
        /// <param name="n">Number of items</param>
        /// <returns>Maximum value</returns>
        public static int KS(int W, int[] wt, int[] val, int n)
        {
            int[,] K = new int[n + 1, W + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int w = 0; w <= W; w++)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;
                    else if (wt[i - 1] <= w)
                        K[i, w] = Math.Max(val[i - 1] + K[i - 1, w - wt[i - 1]], K[i - 1, w]);
                    else
                        K[i, w] = K[i - 1, w];
                }
            }

            return K[n, W];
        }

        static void Main(string[] args)
        {
            // Build out our knapsack
            int[] val = { 60, 120, 100 };
            int[] wt = { 2, 3, 3 };
            int capacity = 5;

            // Determine the highest value
            Console.WriteLine("Maximum value: " + KS(capacity, wt, val, val.Length));

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
