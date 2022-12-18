using System;
using System.IO;

namespace KR2
{
    class Program
    {
        static void MaxDig(int a, int max)
        {
            if (a == 0)
                Console.WriteLine(max);
            else
            {
                if (a % 10 > max)
                    max = a % 10;
                MaxDig(a / 10, max);
            }

        }
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            int maxdig = 0;
            MaxDig(num, maxdig);
        }
    }
}
