using System;
using System.IO;

namespace KR
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] boxSize = new int[3];
            int[] holeSize = new int[2];
            int fuk = 0;
            foreach (string line in File.ReadLines(@"box.txt"))
            {
                if (fuk < 3)
                    boxSize[fuk] = Convert.ToInt32(line);
                else holeSize[fuk - 3] = Convert.ToInt32(line);
                fuk++;
            }
            for (int i = 0; i < 2; i++)
            {
                if (boxSize[i] > boxSize[i + 1])
                {
                    fuk = boxSize[i];
                    boxSize[i] = boxSize[i + 1];
                    boxSize[i + 1] = fuk;
                }
            }
            if (holeSize[0] > holeSize[1])
            {
                fuk = holeSize[0];
                holeSize[0] = holeSize[1];
                holeSize[1] = fuk;
            }
            if (holeSize[1] >= boxSize[1] && holeSize[0] >= boxSize[0])
                Console.WriteLine("It fits!!");
            else
                Console.WriteLine("It doesn't fit...");
        }
    }
}
