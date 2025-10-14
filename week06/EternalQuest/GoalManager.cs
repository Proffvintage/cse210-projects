using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Run()
    {
        bool done = false;
        while (!done)
        {
            Console.WriteLine();
            Console.WriteLine($"You have {_score} points.");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create a New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    done = true;
                    break;
                default:
                    Console.WriteLine("Please enter a valid option (1-6).");
                    break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("The type of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine() ?? "";
        Console.Write("What is a short description of it? ");
        string desc = Console.ReadLine() ?? "";
        Console.Write("What is the amount of points associated with this goal? ");
        int points = ReadInt();

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, desc, points));
                Console.WriteLine("Simple goal created.");
                break;

            case "2":
                _goals.Add(new EternalGoal(name, desc, points));
                Console.WriteLine("Eternal goal created.");
                break;

            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = ReadInt();
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = ReadInt();
                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                Console.WriteLine("Checklist goal created.");
                break;

            default:
                Console.WriteLine("Unknown goal type.");
                break;
        }
    }

    private void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet. Create one first.");
            return;
        }

        Console.WriteLine("Your goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record. Create one first.");
            return;
        }

        ListGoals();
        Console.Write("Which goal did you accomplish? (enter number) ");
        int index = ReadInt();

        if (index < 1 || index > _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        Goal g = _goals[index - 1];
        int gained = g.RecordEvent();
        _score += gained;

        if (gained > 0)
        {
            Console.WriteLine($"Event recorded! You gained {gained} points.");
        }
        else
        {
            Console.WriteLine("No points awarded for this event.");
        }
        Console.WriteLine($"New total score: {_score} points.");
    }

    private void SaveGoals()
    {
        Console.Write("Enter filename to save (e.g., goals.txt): ");
        string file = Console.ReadLine() ?? "goals.txt";

        using (StreamWriter sw = new StreamWriter(file))
        {
            sw.WriteLine(_score);

            foreach (Goal g in _goals)
            {
                sw.WriteLine(g.ToSaveString());
            }
        }

        Console.WriteLine($"Goals and score saved to '{file}'.");
    }

    private void LoadGoals()
    {
        Console.Write("Enter filename to load (e.g., goals.txt): ");
        string file = Console.ReadLine() ?? "goals.txt";

        if (!File.Exists(file))
        {
            Console.WriteLine($"File '{file}' not found.");
            return;
        }

        string[] lines = File.ReadAllLines(file);
        if (lines.Length == 0)
        {
            Console.WriteLine("File was empty.");
            return;
        }

        _goals.Clear();
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i])) continue;
            Goal g = Goal.FromSaveString(lines[i]);
            _goals.Add(g);
        }

        Console.WriteLine("Goals and score loaded.");
    }

    private int ReadInt()
    {
        while (true)
        {
            string s = Console.ReadLine();
            if (int.TryParse(s, out int value))
                return value;
            Console.Write("Please enter a valid integer: ");
        }
    }
}
