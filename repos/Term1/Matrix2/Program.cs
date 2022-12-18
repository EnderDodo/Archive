using System;

namespace Matrix2
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            string[] size = a.Split(' ');
            int b = Convert.ToInt32(size[0]);
            int c = Convert.ToInt32(size[1]);
            int[] stolbi = new int[c];
            for (int i = 0; i < c; i++)
                stolbi[i] = 0;
            int[] stroki = new int[b];
            for (int i = 0; i < b; i++)
                stroki[i] = 0;
            Random rnd = new Random();
            int[,] Matrix = new int[b, c];
            for (int i = 0; i < b; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    Matrix[i, j] = rnd.Next(0, 100);
                    Console.Write($"{Matrix[i, j]} ");
                }
                Console.Write('\n');
            }
            for (int i = 0; i < b; i++)
            {
                for (int j = 0; j < c; j++)
                {
                   if (Matrix[i, j] == 0)
                    {
                        stroki[i] = 1;
                        stolbi[j] = 1;
                    }
                }
            }
            for (int i = 0; i < b; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (stroki[i] == 1 || stolbi[j] == 1)
                    {
                        Matrix[i, j] = 0;
                    }
                }
            }
            Console.Write('\n');
            for (int i = 0; i < b; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    Console.Write($"{Matrix[i, j]} ");
                }
                Console.Write('\n');
            }
            Console.ReadKey();
        }
    }
}
