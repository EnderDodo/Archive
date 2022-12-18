using System;

namespace Lists1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.AddLast("1");
            list.AddLast("2");
            list.AddLast("3");
            list.AddLast("4");
            list.AddLast("5");
            list.AddLast("6");
            list.AddLast("7");
            list.Reversee();
            //List<string> llist = list.Reverse();
            //Node<string> temp;
            //for (temp = list.head; temp.Next != null; temp = temp.Next)
            //{ }
            //list.AddLast(llist.head);

            Console.WriteLine(list.ToString());
        }
    }
}
