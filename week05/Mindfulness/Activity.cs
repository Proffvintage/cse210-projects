using System;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _durationSeconds;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _durationSeconds = 0;
    }

    public abstract void Run();

    protected void Start()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(_name);
        Console.ResetColor();
        Console.WriteLine(_description);
        Console.Write("\nEnter duration (seconds): ");

        int seconds = ReadPositiveInt();
        SetDuration(seconds);

        Console.WriteLine("\nGet ready to begin...");
        ShowSpinner(2);
        Console.WriteLine("Find a comfortable position. Unclench your jaw. Drop your shoulders.");
        Console.WriteLine("Beginning in:");
        ShowCountdown(3);
        Console.Clear();
    }

    // Common end flow
    protected void End()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Session complete.");
        Console.ResetColor();
        ShowSpinner(2);
        Console.WriteLine($"You completed the {_name} for {_durationSeconds} seconds.");
        ShowSpinner(2);
    }

    protected int GetDuration()
    {
        return _durationSeconds;
    }

    private void SetDuration(int seconds)
    {
        _durationSeconds = Math.Max(0, seconds);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] frames = new[] { "|", "/", "-", "\\" };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < end)
        {
            Console.Write($"\r{frames[i % frames.Length]}");
            Thread.Sleep(200);
            i++;
        }
        Console.Write("\r \r");
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{i} ");
            Thread.Sleep(1000);
        }
        Console.Write("\r   \r");
    }

    protected static T GetRandomItem<T>(System.Collections.Generic.List<T> list)
    {
        if (list == null || list.Count == 0) return default(T);
        Random rnd = new Random();
        int idx = rnd.Next(0, list.Count);
        return list[idx];
    }

    private int ReadPositiveInt()
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out int value) && value > 0)
            {
                return value;
            }
            Console.Write("Please enter a positive integer for seconds: ");
        }
    }
}
