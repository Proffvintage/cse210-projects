using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time you acted with courage.",
        "Recall a moment when you stayed calm under pressure.",
        "Think of a situation when you helped someone in need.",
        "Remember a time when you turned a challenge into progress."
    };

    private List<string> _questions = new List<string>
    {
        "What made this moment meaningful?",
        "How did you prepare or decide to act?",
        "What emotions did you notice?",
        "How did this experience change you?",
        "What could you carry forward from it?"
    };

    public ReflectingActivity(string name, string description)
        : base(name, description)
    {
    }

    public override void Run()
    {
        Start();

        string prompt = GetRandomItem(_prompts);
        Console.WriteLine("Consider this prompt:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"— {prompt}");
        Console.ResetColor();
        Console.WriteLine("\nPicture it clearly. We’ll begin the questions shortly.");
        ShowCountdown(4);
        Console.WriteLine();

        DateTime end = DateTime.Now.AddSeconds(GetDuration());

        Random rnd = new Random();
        while (DateTime.Now < end)
        {
            string question = _questions[rnd.Next(_questions.Count)];
            Console.WriteLine(question);
            ShowSpinner(6);
            Console.WriteLine();
        }

        End();
    }
}
