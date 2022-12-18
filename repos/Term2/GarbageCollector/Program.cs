using System;
using System.Diagnostics;

namespace GarbageCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 100000000;

            for (int i = 0; i < n; i++)
            {
                MyClass item = new();
                if (MyClass.flag)
                {
                    MyClass.timer.Stop();
                    Console.WriteLine(MyClass.count);
                    
                    Console.WriteLine($"Elapsed Ticks: {MyClass.timer.ElapsedTicks}");
                    Console.WriteLine($"Elapsed Milliseconds: {MyClass.timer.ElapsedMilliseconds}");

                    MyClass.flag = false;
                    break;
                }
            }

        }
        
    }

    internal class MyClass
    {
        public static bool flag = false;
        public static Stopwatch timer = new Stopwatch();
        public static int count = 0;
        public long MyProperty1 { get; set; }
        public long MyProperty2 { get; set; }
        public long MyProperty3 { get; set; }
        public long MyProperty4 { get; set; }
        public long MyProperty5 { get; set; }
        public long MyProperty6 { get; set; }
        public long MyProperty7 { get; set; }
        public long MyProperty8 { get; set; }
        public long MyProperty9 { get; set; }

        public MyClass()
        {
            count++;
        }

        ~MyClass()
        {
            flag = true;
            timer.Start();
        }

    }
}
