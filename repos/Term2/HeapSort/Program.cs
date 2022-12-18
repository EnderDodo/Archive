using System;

namespace HeapSort
{
    class Program
    {
        
        static void MakeHeap<T>(T[] array, int n, int root) where T : IComparable
        {
            int largest = root;
            int left = root * 2 + 1;
            int right = root * 2 + 2;
            if (left < n && array[left].CompareTo(array[largest]) > 0)
                largest = left;
            if (right < n && array[right].CompareTo(array[largest]) > 0)
                largest = right;
            if (largest != root)
            {
                T swap = array[root];
                array[root] = array[largest];
                array[largest] = swap;

                MakeHeap(array, n, largest);
            }
        }
        static void HeapSort<T>(T[] array) where T : IComparable
        {
            int n = array.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
                MakeHeap(array, n, i);
            for (int i = n - 1; i > 0; i--)
            {
                T temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                MakeHeap(array, i, 0);
            }
        }
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                Random rand = new Random();
                array[i] = rand.Next(1000);
                Console.WriteLine(array[i]);
            }
            HeapSort(array);
            Console.WriteLine();
            Console.WriteLine("Sorted array:");
            for (int i = 0; i < n; i++)
                Console.WriteLine(array[i]);
        }
    }
}
