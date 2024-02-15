using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryOperations
{
    internal class DictionaryOperations
    {
        public static string Translate(Dictionary<string, string> dict, string key)
        {
            return dict.TryGetValue(key, out string value) ? value : null;
        }    

        public static void AddWordToDict(Dictionary<string, string> dictionary, string key)
        {
            Console.Clear();
            while (true)
            {
                if(key == null)
                {
                    Console.WriteLine("Write the Slovak word to add to the dictionary: \n(write \"cancel\" to cancel the operation)\n");
                    key = Console.ReadLine();
                }
                
                if (key.ToLower() == "cancel")
                {
                    CancelOp();
                }

                if (IsString(key))
                {
                    Console.WriteLine("Write the corresponding English translation:");
                    string value = Console.ReadLine();

                    if (IsString(value))
                    {
                        if (!dictionary.ContainsKey(key))
                        {
                            dictionary.Add(key, value);
                            Console.WriteLine($"Word \"{key}\" successfully added to the dictionary.");
                            Console.ReadLine();
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"The word \"{key}\" already exists in the dictionary.");
                            Console.ReadLine();
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for translation. Please enter a string.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input for Slovak word. Please enter a string.");
                }
            }
        }

        public static void GetDict(Dictionary<string, string> dictionary)
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("What would you like to get:\na - all the words from dictionary\nn - number of words in dictionary\nc - cancel");
                char choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case 'a':
                        PrintAll(dictionary);
                        break;
                    case 'n':
                        GetNumberOfWords(dictionary);
                        break;

                    case 'c':
                        CancelOp();
                        return;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input! Pleas try a valid choice!");
                        Console.ReadLine();
                        return;
                }
            }
        }

        private static void PrintAll(Dictionary<string, string> dictionary)
        {
            Console.Clear();
            Console.WriteLine("Dictionary Contents:");
            foreach (var pair in dictionary)
            {
                Console.WriteLine($"\n> Slovak: {pair.Key}, English: {pair.Value}");
                Console.WriteLine( ">------------------------------------------<");
            }
            Console.WriteLine("\n\nPress enter to continue...");
            Console.ReadLine();
        }

        private static void GetNumberOfWords(Dictionary<string, string> dictionary)
        {
            Console.Clear();
            int numberOfWords = dictionary.Count;
            Console.WriteLine($"Number of words in the dictionary: {numberOfWords}");
            Console.WriteLine("\n\nPress enter to continue...");
            Console.ReadLine();
        }


        private static bool IsString(object variable)
        {
            return variable is string;
        }

        private static void CancelOp()
        {
            Random random = new Random();
            for (int i = 3; i != 0; i--)
            {
                Console.Clear();
                Console.WriteLine($"Canceling...{i}");
                Thread.Sleep(random.Next(100, 401));
            }
            Console.Clear();
            return; // Cancel the operation
        }
    }
}
