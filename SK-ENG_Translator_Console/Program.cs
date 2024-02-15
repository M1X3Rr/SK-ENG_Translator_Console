/***********************************************************
 * Console Application, that has a dictionary of Slovak word translated to english
 * You can add word's to dictionary, 
 * App starts by initializing the dictionary, with 5 standard words
 * (counting is just for visuals and takes random time) 
 ***********************************************************/


using System;
using System.Collections.Generic;
using DictionaryOperations;

Dictionary<string, string> engToSk = new Dictionary<string, string>();

Console.Write("Starting the Slovak to English translator...");
InitializeDictionary(engToSk);

Console.WriteLine("\nStarting words loaded...");
Thread.Sleep(1000);
Console.Clear();

while (true)
{
    Console.Clear();
    Console.WriteLine("ENGLISH TO SLOVAK TRANSLATOR");
    Console.WriteLine("\ng - get data\nt - translate your word\ne - exit");
    char choice = Console.ReadKey().KeyChar;

    switch (choice)
    {
        case 'g':
            DictionaryOperations.DictionaryOperations.GetDict(engToSk);
            break;
        case 't':
            TranslateWord(engToSk);
            break;
        case 'e':
            Console.Clear();
            Console.WriteLine("Exiting...");
            return;
        default:
            Console.Clear();
            Console.WriteLine("Invalid input! Please try a valid choice!");
            Console.ReadLine();
            break;
    }
}

static void InitializeDictionary(Dictionary<string, string> dictionary)
{
    int count = 1;
    LoadWord(dictionary, "pes", "dog", count++);
    LoadWord(dictionary, "macka", "cat", count++);
    LoadWord(dictionary, "kon", "horse", count++);
    LoadWord(dictionary, "lev", "lion", count++);
    LoadWord(dictionary, "liska", "fox", count++);
}


static void TranslateWord(Dictionary<string, string> dictionary)
{
    Console.Clear();
    Console.WriteLine("Please input the word to translate:");

    string key = Console.ReadLine();
    string translation = DictionaryOperations.DictionaryOperations.Translate(dictionary, key);

    if (translation != null)
    {
        Console.WriteLine($"English translation for \"{key}\" is \"{translation}\".");
        Console.ReadLine();
    }
    else
    {
        Console.Clear();
        Console.WriteLine($"Word \"{key}\" isn't in the dictionary!\nWould you like to add \"{key}\" to the dictionary? (Y/N)");

        char choice = Console.ReadKey().KeyChar;

        switch (choice)
        {
            case 'y':
                DictionaryOperations.DictionaryOperations.AddWordToDict(dictionary, key);
                break;
            case 'n':
                return;
            default:
                Console.Clear();
                Console.WriteLine("Invalid input! Please try a valid choice!");
                Console.ReadLine();
                return;
        }
    }
}


static void LoadWord(Dictionary<string, string> dictionary, string key, string value, int count)
{
    Random random = new Random();
    dictionary.Add(key, value);
    Console.Write($"  {count}");
    Thread.Sleep(random.Next(300, 601));
}