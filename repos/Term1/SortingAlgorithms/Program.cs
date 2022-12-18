using System;
using System.Diagnostics;
using System.IO;

namespace SortingAlgorithms
{
    class Program
    {
        static void Merge(int[] array, int a, int b, int c)
        {
            int left = a;
            int right = b + 1;
            int[] tempArray = new int[c - a + 1];
            int index = 0;
            while ((left <= b) && (right <= c))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }
                index++;
            }
            for (int i = left; i <= b; i++)
            {
                tempArray[index] = array[i];
                index++;
            }
            for (int i = right; i <= c; i++)
            {
                tempArray[index] = array[i];
                index++;
            }
            for (int i = 0; i < tempArray.Length; i++)
            {
                array[a + i] = tempArray[i];
            }
        }

        static void MergeSort(int[] array, int a, int c)
        {
            if (a < c)
            {
                int b = (a + c) / 2;
                MergeSort(array, a, b);
                MergeSort(array, b + 1, c);
                Merge(array, a, b, c);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество чисел в массиве: ");
            int num, o;
            num = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[num];
            for (int i = 0; i < num; i++)
            {
                Random rnd = new Random();
                array[i] = rnd.Next();
            }
            StreamWriter sW = new StreamWriter(@"c:\Users\Denis\Desktop\Unsorted.txt", false);
            for (int i = 0; i < num; i++)
                sW.WriteLine(array[i]);
            sW.Close();

            int lineAmount = 0;
            foreach (string line in File.ReadLines(@"c:\Users\Denis\Desktop\Unsorted.txt"))
            {
                lineAmount++;
            }
            int[] toSort = new int[lineAmount];
            int fuk = 0;
            foreach (string line in File.ReadLines(@"c:\Users\Denis\Desktop\Unsorted.txt"))
            {
                toSort[fuk] = Convert.ToInt32(line);
                fuk++;
            }

            int[] toSortAgain = new int[lineAmount];
            int[] toSortYetAgain = new int[lineAmount];
            for (int i = 0; i < lineAmount; i++)
            {
                toSortAgain[i] = toSort[i];
                toSortYetAgain[i] = toSort[i];
            }

            Stopwatch stopWatch1 = new Stopwatch();
            stopWatch1.Start();
            Array.Sort(toSort);
            stopWatch1.Stop();
            TimeSpan ts = stopWatch1.Elapsed;
            Console.WriteLine("Array.Sort() RunTime: {0} milliseconds\n\n", ts.TotalMilliseconds);

            Stopwatch stopWatch2 = new Stopwatch();
            stopWatch2.Start();
            for (int i = 0; i < lineAmount; i++)
                for (int k = 0; k < lineAmount - 1; k++)
                {
                    if (toSortAgain[k] > toSortAgain[k + 1])
                    {
                        o = toSortAgain[k];
                        toSortAgain[k] = toSortAgain[k + 1];
                        toSortAgain[k + 1] = o;
                    }
                }
            stopWatch2.Stop();
            TimeSpan tS = stopWatch2.Elapsed;
            Console.WriteLine("Bubble Sort RunTime: {0} milliseconds\n\n", tS.TotalMilliseconds);

            Stopwatch stopWatch3 = new Stopwatch();
            stopWatch3.Start();
            MergeSort(toSortYetAgain, 0, toSortYetAgain.Length - 1);
            stopWatch3.Stop();
            TimeSpan TS = stopWatch3.Elapsed;
            Console.WriteLine("Merge Sort RunTime: {0} milliseconds\n\n", TS.TotalMilliseconds);

            StreamWriter sortedWriter = new StreamWriter(@"c:\Users\Denis\Desktop\Sorted.txt", false);
            for (int i = 0; i < num; i++)
                sortedWriter.WriteLine(toSortYetAgain[i]);
            sortedWriter.Close();
        }
    }
}
