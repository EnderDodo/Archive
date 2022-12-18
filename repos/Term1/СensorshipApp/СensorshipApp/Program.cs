using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace СensorshipApp
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] bannedWords;
            string allData;

            Console.WriteLine("Input path to file:");
            string path = @Console.ReadLine().Trim('"');

            if (!File.Exists(path))
            {
                Console.WriteLine("File is not found. Try again\n");
                return;
            }


            Console.WriteLine("Input count of banned words:");
            int countBannedWords = int.Parse(Console.ReadLine());

            bannedWords = new string[countBannedWords];

            Console.WriteLine("Input banned words");
            for (int i = 0; i < bannedWords.Length; i++)
            {
                bannedWords[i] = Console.ReadLine();
            }

            Console.WriteLine();

            try
            {
                allData = File.ReadAllText(path);

                foreach (string word in bannedWords)
                {
                    allData = allData.Replace(word, "*");
                }

                File.WriteAllText(path, allData);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message + "\n" + "Try again" + "\n");
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" + "Try repeat" + "\n");
                return;
            }

            Console.WriteLine("Success!\n");
        }
    }
}
