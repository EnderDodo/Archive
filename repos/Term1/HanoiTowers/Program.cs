using System;

namespace HanoiTowers
{
	class Program
	{
		static void hanoi(int n, int a, int b, int temp)
		{
			if (n == 1)
				Console.WriteLine($"{n} {a} {b}");
			else
			{
				hanoi(n - 1, a, temp, b);
				Console.WriteLine($"{n} {a} {b}");
				hanoi(n - 1, temp, b, a);
			}
		}
		static void Main(string[] args)
		{
			int n;
			n = Convert.ToInt32(Console.ReadLine());
			hanoi(n, 1, 3, 2);
		}
	}
}
