using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
                "In all thy ways acknowledge him, and he shall direct thy paths."
            ),
            new Scripture(
                new Reference("Moroni", 10, 4, 5),
                "And if ye shall ask with a sincere heart, with real intent, having faith in Christ. " +
                "He will manifest the truth of it unto you, by the power of the Holy Ghost." +
                "And by the power of the Holy Ghost ye may know the truth of all things."
            ),
            new Scripture(
                new Reference("Moses", 1, 39),
                "For behold, this is my work and my glory—to bring to pass the immortality and eternal life of man."
            )
        };

        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            scripture.Display();

            Console.WriteLine("\nPress ENTER to continue or type 'quit' to finish:");
            string input = Console.ReadLine();

            if (input?.ToLower() == "quit")
                return;

            scripture.HideRandomWords();
        }

        Console.Clear();
        scripture.Display();
        Console.WriteLine("\nAll words in this scripture are hidden. Program finished.");
    }
}

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        string[] splitWords = text.Split(' ');
        foreach (string w in splitWords)
        {
            _words.Add(new Word(w));
        }
    }

    public void Display()
    {
        Console.WriteLine(_reference.GetDisplayText());
        foreach (Word word in _words)
        {
            Console.Write(word.GetDisplayText() + " ");
        }
        Console.WriteLine();
    }

    public void HideRandomWords()
    {
        int wordsToHide = _random.Next(2, 4);
        for (int i = 0; i < wordsToHide; i++)
        {
            int index = _random.Next(_words.Count);
            _words[index].Hide();
        }
    }

    public bool AllWordsHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
                return false;
        }
        return true;
    }
}
