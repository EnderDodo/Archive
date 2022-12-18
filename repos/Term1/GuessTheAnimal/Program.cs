using System;

namespace GuessTheAnimal
{
    class Program
    {
        public static void Init(Node root)
        {
            root.Left = new Node() { Data = "Оно лает?" };
            root.Right = new Node() { Data = "Оно покрыто чешуёй?" };
            root.Left.Left = new Node() { Data = "Собака" };
            root.Left.Right = new Node() { Data = "Кошка" };
            root.Right.Left = new Node() { Data = "Рыба" };
            root.Right.Right = new Node("Птица");
        }

        static void Main(string[] args)
        {
            Node root = new Node() { Data = "Это млекопитающее?" };
            Init(root);


            while (true)
            {
                string answer;

                Node currentNode = root;
                Node prevNode = new Node();
                while (currentNode.Data[currentNode.Data.Length - 1] == '?')
                {
                    Console.WriteLine(currentNode.Data);
                    answer = Console.ReadLine();

                    prevNode = currentNode;
                    if (answer.ToLower() == "да")
                    {
                        currentNode = currentNode.Left;
                    }
                    else
                    {
                        currentNode = currentNode.Right;
                    }

                }
                Console.WriteLine("Это " + currentNode.Data + "?");
                answer = Console.ReadLine();
                if (answer.ToLower() == "да")
                {
                    Console.WriteLine("---------------------");
                    continue;
                }
                else
                {
                    Console.WriteLine("А кто тогда??");
                    answer = Console.ReadLine();
                    Console.WriteLine("Какой вопрос поможит отличить животное " + currentNode.Data + " от животного " + answer + "?");
                    string question = Console.ReadLine();
                    if (question[question.Length - 1] != '?')
                    {
                        question += "?";
                    }
                    string animal = currentNode.Data;
                    currentNode.Data = question;
                    currentNode.Left = new Node() { Data = answer };
                    currentNode.Right = new Node() { Data = animal };

                }
                Console.WriteLine("---------------------");
            }
        }
    }
}