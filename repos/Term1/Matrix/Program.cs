using System;

namespace Matrix
{
    class Program
    {
        static void BuildMatrix(int[,] OldMatrix, int[,] NewMatrix, int b, int column)
        {
            for (int i = 0; i < b - 1; i++)
            {
                int jump = 0;
                for (int j = 0; j < b - 1; j++)
                {
                    if (j == column)
                    {
                        jump = 1;
                    }
                    NewMatrix[i, j] = OldMatrix[i + 1, j + jump];
                }
            }
        }
        static long Determinant(int[,] Matrix, int b)
        {
            long det = 0;
            if (b == 2)
            {
                det = Matrix[0, 0] * Matrix[1, 1] - Matrix[0, 1] * Matrix[1, 0];
            }
            else
            {
                int[,] NewMatrix = new int[b - 1, b - 1];
                for (int j = 0; j < b; j++)
                {
                    BuildMatrix(Matrix, NewMatrix, b, j);
                    det += j % 2 == 0 ? 1 : -1 * Matrix[0, j] * Determinant(NewMatrix, b - 1);
                }
            }
            return det;
        }
        static void Main(string[] args)
        {
            int size = Convert.ToInt32(Console.ReadLine());
            Random rnd = new Random();
            int[,] Matrix = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Matrix[i, j] = rnd.Next(1, 10);
                    Console.Write($"{Matrix[i, j]} ");
                }
                Console.Write('\n');
            }
            Console.WriteLine(Determinant(Matrix, size));
            Console.ReadKey();
        }
    }
}
