using System;
using System.Collections;
using System.Collections.Generic;

namespace DLList
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public Node<T> Prev { get; set; }
        public T Value { get; set; }
        public Node(T value)
        {
            Value = value;
        }
        public Node() { }
    }

    public class MyLinkedList<T> : IComparable, ICloneable, IEnumerable<T>, ICollection<T> where T : IComparable
    {
        public int Count { get; private set; }
        public Node<T> First { get; set; }
        public Node<T> Last { get; set; }
        public bool IsReadOnly => false;

        public MyLinkedList() { }

        public MyLinkedList(T[] arr)
        {
            foreach (var item in arr)
            {
                AddLast(item);
            }
        }

        public void AddLast(Node<T> node)
        {
            if (node == null) throw new ArgumentNullException();

            if (Count != 0)
            {
                node.Prev = Last;
                Last.Next = node;
                Last = node;
            }
            else
            {
                First = node;
                Last = node;
            }
            Count++;
        }
        public void AddLast(T data) => AddLast(new Node<T>(data));

        public void AddBefore(Node<T> node, Node<T> newNode)
        {
            if (node == null || newNode == null) throw new ArgumentNullException();

            if (node == First)
            {
                AddFirst(newNode);
                return;
            }

            node.Prev.Next = newNode;
            newNode.Next = node;
            node.Prev = newNode;
            newNode.Prev = node.Prev;
        }

        public void AddBefore(Node<T> node, T data) => AddBefore(node, new Node<T>(data));

        public void AddFirst(Node<T> node)
        {
            if (node == null) throw new ArgumentNullException();

            if (Count != 0)
            {
                node.Next = First;
                First.Prev = node;
                First = node;
            }
            else
            {
                First = node;
                Last = node;
            }
            Count++;
        }

        public void AddFirst(T data) => AddFirst(new Node<T>(data));

        public void AddAfter(Node<T> node, Node<T> newNode)
        {
            if (node == null || newNode == null) throw new ArgumentNullException();

            if (node == Last)
            {
                AddLast(node);
                return;
            }

            newNode.Next = node.Next;
            node.Next = newNode;
            newNode.Prev = node;
            newNode.Next.Prev = newNode;
        }

        public void AddAfter(Node<T> node, T data) => AddAfter(node, new Node<T>(data));

        public void Clear()
        {
            First = null;
            Last = null;
        }

        public Node<T> Find(T data)
        {
            if (data == null) throw new ArgumentNullException();

            for (Node<T> temp = First; temp != null; temp = temp.Next)
            {
                if (temp.Value.Equals(data))
                    return temp;
            }
            return null;
        }

        public bool Contains(T data) => Find(data) != null;

        public Node<T> FindLast(T data)
        {
            if (data == null) throw new ArgumentNullException();

            for (Node<T> temp = Last; temp != null; temp = temp.Prev)
            {
                if (temp.Value.Equals(data))
                    return temp;
            }
            return null;
        }

        public bool Remove(Node<T> node)
        {
            if (node == null) throw new ArgumentNullException();

            if (node == First)
            {
                RemoveFirst();
                return true;
            }
            if (node == Last)
            {
                RemoveLast();
                return true;
            }

            if (Count == 1)
                Clear();
            else
            {
                node.Next.Prev = node.Prev;
                node.Prev.Next = node.Next;
            }
            return true;
        }

        public bool Remove(T data)
        {
            Node<T> temp = Find(data);
            if (temp == null)
                return false;
            return Remove(temp);
        }

        public void RemoveFirst()
        {
            First.Next.Prev = null;
            First = First.Next;
        }

        public void RemoveLast()
        {
            Last.Prev.Next = null;
            Last = Last.Prev;
        }

        public void CopyTo(T[] array, int index)
        {
            if (array == null) throw new ArgumentNullException();

            if (index < 0 || index > array.Length) throw new IndexOutOfRangeException();

            for (Node<T> temp = First; temp != null && index < array.Length; temp = temp.Next, index++)
            {
                array[index] = temp.Value;
            }
        }

        public void Print()
        {
            for (Node<T> temp = First; temp != null; temp = temp.Next)
            {
                Console.WriteLine(temp.Value);
            }
            Console.WriteLine();
        }

        public int CompareTo(object obj) => Count - (obj as MyLinkedList<T>).Count;

        public object Clone()
        {
            MyLinkedList<T> list = new MyLinkedList<T>();
            for (Node<T> temp = First; temp != null; temp = temp.Next)
            {
                list.AddLast(temp.Value);
            }
            return list;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (Node<T> temp = First; temp != null; temp = temp.Next)
            {
                yield return temp.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)GetEnumerator();

        public void Add(T item) => AddLast(item);

        public MyLinkedList<T> Sort()
        {
            return MergeSort(this);
        }

        private MyLinkedList<T> MergeSort(MyLinkedList<T> list)
        {
            if (list.Count <= 1)
                return list;

            MyLinkedList<T> left = new MyLinkedList<T>();
            MyLinkedList<T> right = new MyLinkedList<T>();

            int index = 0;

            for (Node<T> temp = list.First; temp != null; temp = temp.Next, index++)
            {
                if (index < list.Count / 2)
                    left.AddLast(temp.Value);
                else
                    right.AddLast(temp.Value);
            }

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        public MyLinkedList<T> Merge(MyLinkedList<T> left, MyLinkedList<T> right)
        {

            Node<T> leftIter = left.First;
            Node<T> rightIter = right.First;

            var result = new MyLinkedList<T>();

            while (leftIter != null && rightIter != null)
            {
                if (leftIter.Value.CompareTo(rightIter.Value) > 0)
                {
                    result.AddLast(rightIter.Value);
                    rightIter = rightIter.Next;
                }
                else
                {
                    result.AddLast(leftIter.Value);
                    leftIter = leftIter.Next;
                }
            }

            while (rightIter != null)
            {
                result.AddLast(rightIter.Value);
                rightIter = rightIter.Next;
            }
            while (leftIter != null)
            {
                result.AddLast(leftIter.Value);
                leftIter = leftIter.Next;
            }

            return result;
        }
    }
}
