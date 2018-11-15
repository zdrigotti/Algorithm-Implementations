using System;

namespace Mergesort
{
    class Mergesort
    {
        /// <summary>
        /// Sorts an array using the mergesort algorithm
        /// </summary>
        /// <param name="array">Array to sort</param>
        /// <param name="start">Starting index</param>
        /// <param name="end">Ending index</param>
        public static void MergeSort(int[] array, int start, int end)
        {
            if (start < end)
            {
                int middle = (start + end) / 2;

                MergeSort(array, start, middle);
                MergeSort(array, middle + 1, end);

                Merge(array, start, middle, end);
            }
        }

        /// <summary>
        /// Merges an array in ascending order from 
        /// start -> middle and middle + 1 -> end
        /// </summary>
        /// <param name="array">Array to sort</param>
        /// <param name="start">Starting index</param>
        /// <param name="middle">Middle index</param>
        /// <param name="end">Ending index</param>
        private static void Merge(int[] array, int start, int middle, int end)
        {
            int bottomIndex = start;
            int topIndex = middle + 1;
            int[] tempArray = new int[end - start + 1];
            int count = 0;

            for (int i = start; i <= end; i++)
            {
                if (bottomIndex > middle)
                {
                    tempArray[count++] = array[topIndex++];
                }
                else if (topIndex > end)
                {
                    tempArray[count++] = array[bottomIndex++];
                }
                else if (array[bottomIndex] < array[topIndex])
                {
                    tempArray[count++] = array[bottomIndex++];
                }
                else
                {
                    tempArray[count++] = array[topIndex++];
                }
            }

            for (int i = 0; i < count; i++)
            {
                array[start++] = tempArray[i];
            }
        }

        static void Main(string[] args)
        {
            int[] inputArray = { 10, 3, 4, 55, 23, 1, 8, 20, 18, 15, 21, 7, 20, 20, 20 };

            MergeSort(inputArray, 0, inputArray.Length - 1);

            foreach (int value in inputArray)
            {
                Console.WriteLine(value);
            }
            
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
