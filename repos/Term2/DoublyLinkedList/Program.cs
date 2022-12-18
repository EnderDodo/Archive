using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DoublyLinkedList
{
    class Program
    {
        public static void Test1(string[] words)
        {
            LinkedList<string> sentence = new LinkedList<string>(words);
            //Display(sentence, "The linked list values:");
            //Console.WriteLine("sentence.Contains(\"jumps\") = {0}",
            //    sentence.Contains("jumps"));

            // Add the word 'today' to the beginning of the linked list.
            sentence.AddFirst("today");
            //Display(sentence, "Test 1: Add 'today' to beginning of the list:");

            // Move the first node to be the last node.
            LinkedListNode<string> mark1 = sentence.First;
            sentence.RemoveFirst();
            sentence.AddLast(mark1);
            //Display(sentence, "Test 2: Move first node to be last node:");

            // Change the last node to 'yesterday'.
            sentence.RemoveLast();
            sentence.AddLast("yesterday");
            //Display(sentence, "Test 3: Change the last node to 'yesterday':");

            // Move the last node to be the first node.
            mark1 = sentence.Last;
            sentence.RemoveLast();
            sentence.AddFirst(mark1);
            //Display(sentence, "Test 4: Move last node to be first node:");

            // Indicate the last occurence of 'the'.
            sentence.RemoveFirst();
            LinkedListNode<string> current = sentence.FindLast("the");
            //IndicateNode(current, "Test 5: Indicate last occurence of 'the':");

            // Add 'lazy' and 'old' after 'the' (the LinkedListNode named current).
            sentence.AddAfter(current, "old");
            sentence.AddAfter(current, "lazy");
            //IndicateNode(current, "Test 6: Add 'lazy' and 'old' after 'the':");

            // Indicate 'fox' node.
            current = sentence.Find("fox");
            //IndicateNode(current, "Test 7: Indicate the 'fox' node:");

            // Add 'quick' and 'brown' before 'fox':
            sentence.AddBefore(current, "quick");
            sentence.AddBefore(current, "brown");
            //IndicateNode(current, "Test 8: Add 'quick' and 'brown' before 'fox':");

            // Keep a reference to the current node, 'fox',
            // and to the previous node in the list. Indicate the 'dog' node.
            mark1 = current;
            LinkedListNode<string> mark2 = current.Previous;
            current = sentence.Find("dog");
            //IndicateNode(current, "Test 9: Indicate the 'dog' node:");

            // The AddBefore method throws an InvalidOperationException
            // if you try to add a node that already belongs to a list.

            // Remove the node referred to by mark1, and then add it
            // before the node referred to by current.
            // Indicate the node referred to by current.
            sentence.Remove(mark1);
            sentence.AddBefore(current, mark1);
            //IndicateNode(current, "Test 11: Move a referenced node (fox) before the current node (dog):");

            // Remove the node referred to by current.
            sentence.Remove(current);
            //IndicateNode(current, "Test 12: Remove current node (dog) and attempt to indicate it:");

            // Add the node after the node referred to by mark2.
            sentence.AddAfter(mark2, current);
            //IndicateNode(current, "Test 13: Add node removed in test 11 after a referenced node (brown):");

            // The Remove method finds and removes the
            // first node that that has the specified value.
            sentence.Remove("old");
            //Display(sentence, "Test 14: Remove node that has the value 'old':");

            // When the linked list is cast to ICollection(Of String),
            // the Add method adds a node to the end of the list.
            sentence.RemoveLast();
            ICollection<string> icoll = sentence;
            icoll.Add("rhinoceros");
            //Display(sentence, "Test 15: Remove last node, cast to ICollection, and add 'rhinoceros':");

            //Console.WriteLine("Test 16: Copy the list to an array:");
            // Create an array with the same number of
            // elements as the linked list.
            string[] sArray = new string[sentence.Count];
            sentence.CopyTo(sArray, 0);

            /*foreach (string s in sArray)
            {
                Console.WriteLine(s);
            }*/

            // Release all the nodes.
            sentence.Clear();
        }

        public static void Test2(string[] words)
        {

            MyLinkedList<string> sentence = new MyLinkedList<string>(words);
            //Display(sentence, "The linked list values:");
            //Console.WriteLine("sentence.Contains(\"jumps\") = {0}",
            //    sentence.Contains("jumps"));

            // Add the word 'today' to the beginning of the linked list.
            sentence.AddFirst("today");
            //Display(sentence, "Test 1: Add 'today' to beginning of the list:");

            // Move the first node to be the last node.
            Node<string> mark1 = sentence.First;
            sentence.RemoveFirst();
            sentence.AddLast(mark1);
            //Display(sentence, "Test 2: Move first node to be last node:");

            // Change the last node to 'yesterday'.
            sentence.RemoveLast();
            sentence.AddLast("yesterday");
            //Display(sentence, "Test 3: Change the last node to 'yesterday':");

            // Move the last node to be the first node.
            mark1 = sentence.Last;
            sentence.RemoveLast();
            sentence.AddFirst(mark1);
            //Display(sentence, "Test 4: Move last node to be first node:");

            // Indicate the last occurence of 'the'.
            sentence.RemoveFirst();
            Node<string> current = sentence.FindLast("the");
            //IndicateNode(current, "Test 5: Indicate last occurence of 'the':");

            // Add 'lazy' and 'old' after 'the' (the LinkedListNode named current).
            sentence.AddAfter(current, "old");
            sentence.AddAfter(current, "lazy");
            //IndicateNode(current, "Test 6: Add 'lazy' and 'old' after 'the':");
            // Indicate 'fox' node.
            current = sentence.Find("fox");
            //IndicateNode(current, "Test 7: Indicate the 'fox' node:");

            // Add 'quick' and 'brown' before 'fox':
            sentence.AddBefore(current, "quick");
            sentence.AddBefore(current, "brown");
            //IndicateNode(current, "Test 8: Add 'quick' and 'brown' before 'fox':");

            // Keep a reference to the current node, 'fox',
            // and to the previous node in the list. Indicate the 'dog' node.
            mark1 = current;
            Node<string> mark2 = current.Prev;
            current = sentence.Find("dog");
            //IndicateNode(current, "Test 9: Indicate the 'dog' node:");

            // The AddBefore method throws an InvalidOperationException
            // if you try to add a node that already belongs to a list.

            // Remove the node referred to by mark1, and then add it
            // before the node referred to by current.
            // Indicate the node referred to by current.
            sentence.Remove(mark1);
            sentence.AddBefore(current, mark1);
            //IndicateNode(current, "Test 11: Move a referenced node (fox) before the current node (dog):");

            // Remove the node referred to by current.
            sentence.Remove(current);
            //IndicateNode(current, "Test 12: Remove current node (dog) and attempt to indicate it:");

            // Add the node after the node referred to by mark2.
            sentence.AddAfter(mark2, current);
            //IndicateNode(current, "Test 13: Add node removed in test 11 after a referenced node (brown):");

            // The Remove method finds and removes the
            // first node that that has the specified value.
            sentence.Remove("old");
            //Display(sentence, "Test 14: Remove node that has the value 'old':");

            // When the linked list is cast to ICollection(Of String),
            // the Add method adds a node to the end of the list.
            sentence.RemoveLast();
            ICollection<string> icoll = sentence;
            icoll.Add("rhinoceros");
            //Display(sentence, "Test 15: Remove last node, cast to ICollection, and add 'rhinoceros':");

            //Console.WriteLine("Test 16: Copy the list to an array:");
            // Create an array with the same number of
            // elements as the linked list.
            string[] sArray = new string[sentence.Count];
            sentence.CopyTo(sArray, 0);

            /*foreach (string s in sArray)
            {
                Console.WriteLine(s);
            }*/

            // Release all the nodes.
            sentence.Clear();
        }

        static void Main(string[] args)
        {
            Random rand = new Random();

            int n = 1000;

            
            string[] words = new string[n];

            string[] alphabet = { "the", "fox", "jumps", "over", "dog" };

            for (int i = 0; i < n; i++)
            {
                words[i] = alphabet[rand.Next(5)];
            }

            words[4] = "the";
            words[5] = "fox";
            words[6] = "jumps";
            words[7] = "over";
            words[8] = "dog";

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 100; i++)
            {
                Test1(words);
            }
            sw.Stop();
            Console.WriteLine("DefaultListTime: " + sw.Elapsed.TotalMilliseconds);

            sw.Restart();

            sw.Start();
            for (int i = 0; i < 100; i++)
            {
                Test2(words);
            }
            MyLinkedList<string> sentence = new MyLinkedList<string>(words);
            sentence.Print();

            sw.Stop();
            Console.WriteLine("MyListTime: " + sw.Elapsed.TotalMilliseconds);

            //Node<int> node = new Node<int>(7);


            /*MyLinkedList<int> list = new MyLinkedList<int>();
            for (int i = 0; i < n; i++)
            {
                list.Add(new Random().Next(100));
            }
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var sortedList = list.Sort();

            Console.WriteLine();

            foreach (var item in sortedList)
            {
                Console.WriteLine(item);
            }*/
        }
    }
}
