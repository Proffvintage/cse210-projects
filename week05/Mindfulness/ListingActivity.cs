using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt peace this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(string name, string description)
        : base(name, description)
    {
    }

    public override void Run()
    {
        Start();

        string prompt = GetRandomItem(_prompts);
        Console.WriteLine("List as many ideas as you can that fit the prompt below:\n");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"--- {prompt} ---");
        Console.ResetColor();
        Console.WriteLine();
        Console.Write("Starting in: ");
        ShowCountdown(5);
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("(Write one per line. Press Enter after each. Stop when time runs out.)");
        Console.ResetColor();

        List<string> items = new List<string>();
        DateTime end = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < end)
        {
            int remaining = (int)(end - DateTime.Now).TotalSeconds;
            if (remaining <= 0) break;

            Console.Write("> ");
            string line = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(line))
            {
                items.Add(line.Trim());
            }
        }

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"You listed {items.Count} items.");
        Console.ResetColor();

        End();
    }
}
