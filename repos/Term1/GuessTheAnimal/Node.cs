using System;
using System.Collections.Generic;
using System.Text;

namespace GuessTheAnimal
{
    class Node
    {
        public string Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node() { }
        public Node(string Data)
        {
            this.Data = Data;

        }
    }
    
}
