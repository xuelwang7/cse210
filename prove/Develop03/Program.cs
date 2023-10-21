using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Reference
{
    public string Verse { get; }
    public string Book { get; }
    public Reference(string reference)
    {
        var parts = reference.Split(' ');
        Book = parts[0];
        Verse = parts[1];
    }
}

class Scripture
{
    private string reference;
    private string text;
    private List<string> hiddenWords;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.text = text;
        hiddenWords = new List<string>();
    }

    public void HideRandomWords()
    {
        string[] words = text.Split(' ');
        Random random = new Random();

        int numWordsToHide = random.Next(1, words.Length + 1);

        for (int i = 0; i < numWordsToHide; i++)
        {
            int index = random.Next(words.Length);
            if (!hiddenWords.Contains(words[index]))
            {
                hiddenWords.Add(words[index]);
            }
        }
    }

    public bool AllWordsHidden()
    {
        return hiddenWords.Count == text.Split(' ').Length;
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine($"Scripture: {reference}");
        string[] words = text.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            if (hiddenWords.Contains(words[i]))
                Console.Write("***** ");
            else
                Console.Write(words[i] + " ");
        }
        Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.WriteLine("Enter the reference (e.g., 'John 3:16'): ");
        string reference = Console.ReadLine();

        Console.WriteLine("Enter the scripture text: ");
        string text = Console.ReadLine();

        Scripture scripture = new Scripture(reference, text);

        while (!scripture.AllWordsHidden())
        {
            scripture.Display();

            string input = Console.ReadLine().ToLower();
            if (input == "quit")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else if (input == "")
            {
                scripture.HideRandomWords();
            }
        }
    }
}
