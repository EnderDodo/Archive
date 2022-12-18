using System;
using System.Collections.Generic;
using System.Text;

namespace Lists1
{
    class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node()
        {

        }
        public Node(T Data)
        {
            this.Data = Data;
        }
        public void Remove()
        {
            if (this.Next == null)
            {
                return;
            }

            Node<T> temp = this;

            while (temp.Next.Next != null)
            {
                temp.Data = temp.Next.Data;
                temp = temp.Next;
            }

            temp.Data = temp.Next.Data;
            temp.Next = null;
        }
    }
}
