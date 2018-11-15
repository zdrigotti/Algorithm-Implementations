using System;

namespace LongestCommenSubsequence
{
    class LongestCommonSubsequence
    {
        /// <summary>
        /// Determines and prints the longest common subsequence
        /// between two strings
        /// </summary>
        /// <param name="x">First string</param>
        /// <param name="y">Second string</param>
        /// <param name="m">Length of the first string</param>
        /// <param name="n">Length of the second string</param>
        public static void LCS(string x, string y, int m, int n)
        {
            int[,] L = new int[m + 1, n + 1];

            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                        L[i, j] = 0;
                    else if (x[i - 1] == y[j - 1])
                        L[i, j] = L[i - 1, j - 1] + 1;
                    else
                        L[i, j] = Math.Max(L[i - 1, j], L[i, j - 1]);
                }
            }

            int index = L[m, n];
            char[] lcs = new char[index + 1];
            lcs[index] = '\0';

            int k = m, l = n;

            while (k > 0 && l > 0)
            {
                if (x[k - 1] == y[l - 1])
                {
                    lcs[index--] = x[k - 1];

                    k--;
                    l--;
                }
                else if (L[k - 1, l] > L[k, l - 1])
                    k--;
                else
                    l--;                
            }
            
            for (int i = 0; i < lcs.Length; i++)
            {
                Console.Write(lcs[i]);
            }
        }

        static void Main(string[] args)
        {
            string x = "AGGTAB";
            string y = "GXTXAYB";

            LCS(x, y, x.Length, y.Length);
            
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
