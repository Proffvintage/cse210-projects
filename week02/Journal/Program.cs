using System;
using System.Collections.Generic;
using System.IO;

class Entry
{
    public string Prompt { get; set; }
    public string Text { get; set; }

    public Entry(string prompt, string text)
    {
        Prompt = prompt;
        Text = text;
    }

    public void Display()
    {
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Entry: {Text}");
        Console.WriteLine();
    }

    public string ToFileString()
    {
        return $"{Prompt}|{Text}";
    }

    public static Entry FromFileString(string line)
    {
        string[] parts = line.Split('|');
        if (parts.Length >= 2)
        {
            return new Entry(parts[1], parts[2]);
        }
        return null;
    }
}

class PromptGenerator
{
    private List<string> prompts = new List<string>()
    {
        "What were the things you learnt today?",
        "How are feeling right now?",
        "What do you want to do right now?",
        "What was the best part of your day?",
        "What was the worst part of your day? What do you think you can do to better it?",
        "What is a skill or hobby you would like to develop, and why?",
        "What is a mistake you made recently, and what did you learn from it?",
    };

    private Random rand = new Random();

    public string GetRandomPrompt()
    {
        int index = rand.Next(prompts.Count);
        return prompts[index];
    }
}

class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter sw = new StreamWriter(file))
        {
            foreach (Entry entry in entries)
            {
                sw.WriteLine(entry.ToFileString());
            }
        }
    }

    public void LoadFromFile(string file)
    {
        entries.Clear();
        if (File.Exists(file))
        {
            string[] lines = File.ReadAllLines(file);
            foreach (string line in lines)
            {
                Entry entry = Entry.FromFileString(line);
                if (entry != null)
                {
                    entries.Add(entry);
                }
            }
        }

    }
}
