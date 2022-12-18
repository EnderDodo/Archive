using System;
using System.Diagnostics;
using System.IO;

namespace LeCensureApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords;
            string toCensor;
            int numberOfLines = 0;
            int fuk = 0;
            foreach (string line in File.ReadLines(@"c:\Users\Denis\Desktop\BADWORDS.txt"))
            {
                numberOfLines++;
            }
            bannedWords = new string[numberOfLines];
            foreach (string line in File.ReadLines(@"c:\Users\Denis\Desktop\BADWORDS.txt"))
            {
                bannedWords[fuk] = line;
                fuk++;
            }
            toCensor = File.ReadAllText(@"c:\Users\Denis\Desktop\UncensoredText.txt");
            foreach (string word in bannedWords)
            {
                toCensor = toCensor.Replace(word, "[:-(]");
            }
            File.WriteAllText(@"c:\Users\Denis\Desktop\CensoredText.txt", toCensor);
            Console.WriteLine("Success, we guess...");
        }
    }
}
