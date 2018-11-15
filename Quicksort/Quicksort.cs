using System;

namespace Quicksort
{
    class Quicksort
    {
        /// <summary>
        /// Sorts an array using the quicksort algorithm
        /// </summary>
        /// <param name="array">Array to sort</param>
        /// <param name="low">Lower index to sort with</param>
        /// <param name="high">Higher index to sort with</param>
        public static void QuickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = RandomPartition(array, low, high);
                QuickSort(array, low, partitionIndex);
                QuickSort(array, partitionIndex + 1, high);
            }
        }

        /// <summary>
        /// Swaps the value at low with a random index in the array,
        /// then partitions the array
        /// </summary>
        /// <param name="array">Array to sort</param>
        /// <param name="low">Lower index to sort with</param>
        /// <param name="high">Higher index to sort with</param>
        /// <returns>Partition index</returns>
        private static int RandomPartition(int[] array, int low, int high)
        {
            Random random = new Random();
            int randomValue = random.Next(low, high + 1);
            Swap(array, low, randomValue);

            return Partition(array, low, high);
        }

        /// <summary>
        /// Picks the value at low as the pivot, then sorts the values
        /// between low and high around that pivot
        /// </summary>
        /// <param name="array">Array to sort</param>
        /// <param name="low">Lower index to sort with</param>
        /// <param name="high">Higher index to sort with</param>
        /// <returns>Partition index</returns>
        private static int Partition(int[] array, int low, int high)
        {
            int pivot = array[low];
            int i = low - 1, j = high + 1;

            while (true)
            {
                do { i++; }
                while (array[i] < pivot);

                do { j--; }
                while (array[j] > pivot);

                if (i >= j) { return j; }

                Swap(array, i, j);
            }
        }

        /// <summary>
        /// Swaps the given indices in the input array
        /// </summary>
        /// <param name="array">Array to swap values within</param>
        /// <param name="i">First index to swap</param>
        /// <param name="j">Second index to swap</param>
        public static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        static void Main(string[] args)
        {
            int[] inputArray = { 10, 3, 4, 55, 23, 1, 8, 20, 18, 15, 21, 7, 20, 20, 20 };

            QuickSort(inputArray, 0, inputArray.Length - 1);

            foreach (int value in inputArray)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
