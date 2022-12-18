using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lists1
{
    class List<T>
    {
        public Node<T> head;
        private Node<T> CreateNode(T data)
        {
            return new Node<T>() { Data = data, Next = null };
        }
        public void AddFirst(T data)
        {
            Node<T> newNode = CreateNode(data);
            newNode.Next = head;
            head = newNode;
        }
        public void AddAfter(Node<T> prevNode, T data)
        {
            if (prevNode == null)
                return;

            Node<T> newNode = CreateNode(data);
            newNode.Next = prevNode.Next;
            prevNode.Next = newNode;
        }

        public void AddLast(T data)
        {
            Node<T> temp = head;
            if (head == null)
            {
                AddFirst(data);
                return;
            }
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            AddAfter(temp, data);
        }
        public void AddLast(Node<T> node1)
        {
            Node<T> temp = head;
            if (head == null)
            {
                head = node1;
                return;
            }
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = node1;
        }

        public Node<T> Find(T data)
        {
            Node<T> temp = head;
            while (temp != null && !temp.Data.Equals(data))
            {
                temp = temp.Next;
            }
            return temp;
        }

        public void Remove(Node<T> aNode)
        {
            if (aNode == null) return;

            Node<T> temp = head;

            if (head == aNode)
            {
                head = aNode.Next;
            }

            while (temp != null && temp.Next != aNode)
            {
                temp = temp.Next;
            }

            if (temp == null)
            {
                return;
            }
            temp.Next = aNode.Next;
        }

        public Node<T> GetKFromEnd(int number)
        {
            Node<T> first = head;
            Node<T> second = head;

            int k = 0;

            while (k != number)
            {
                second = second.Next;
                k++;
            }

            while (second.Next != null)
            {
                first = first.Next;
                second = second.Next;
            }

            return first.Next;
        }
        public bool IsPalyndrome()
        {
            Stack<Node<T>> leStack = new Stack<Node<T>>();

            Node<T> first = head;

            while (first != null)
            {
                leStack.Push(first);
                first = first.Next;
            }

            int n = leStack.Count / 2;

            first = head;

            for (int i = 0; i < n; i++)
            {
                if (!first.Data.Equals(leStack.Pop().Data))
                {
                    return false;
                }
                first = first.Next;
            }

            return true;
        }
        public void DuplicatesErase()
        {
            Hashtable table = new Hashtable();
            Node<T> gg = head;
            Node<T> prev = head;
            while (gg != null)
            {
                if (table.ContainsKey(gg.Data))
                {
                    prev.Next = gg.Next;
                }
                else
                {
                    table.Add(gg.Data, true);
                    prev = gg;
                }
                gg = gg.Next;
            }
        }
        public List<T> Reverse()
        {
            List<T> list = new List<T>();
            
            for (Node<T> node = head; node != null; node = node.Next)
            {
                list.AddFirst(node.Data);
            }
            return list;
        }
        public void Reversee()
        {
            head = Reverse().head;
        }
        public bool IsLoop()
        {
            Node<T> slow = head;
            Node<T> fast = head;

            
            while (fast.Next.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
                if (slow == fast)
                    return true;
            }


            return false;
        }
        public override string ToString()
        {
            Node<T> node = head;
            string value = "";
            while (node != null)
            {
                value += node.Data.ToString() + " ";
                node = node.Next;
            }
            return value;
        }
        
    }
}
