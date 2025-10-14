using System;

public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    protected Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public string GetShortName() => _shortName;
    public string GetDescription() => _description;
    public int GetPoints() => _points;

    public virtual bool IsComplete() => false;

    public virtual string GetDetailsString()
    {
        string check = IsComplete() ? "X" : " ";
        return $"[{check}] {GetShortName()} ({GetDescription()})";
    }

    public abstract int RecordEvent();

    public abstract string ToSaveString();

    public static Goal FromSaveString(string line)
    {
        if (string.IsNullOrWhiteSpace(line)) throw new FormatException("Empty goal line.");
        string[] parts = line.Split('|');
        string type = parts[0];

        switch (type)
        {
            case "SimpleGoal":
            {
                if (parts.Length < 5) throw new FormatException("SimpleGoal line malformed.");
                string name = parts[1];
                string desc = parts[2];
                int pts = int.Parse(parts[3]);
                bool isComplete = bool.Parse(parts[4]);
                return new SimpleGoal(name, desc, pts, isComplete);
            }

            case "EternalGoal":
            {
                if (parts.Length < 4) throw new FormatException("EternalGoal line malformed.");
                string name = parts[1];
                string desc = parts[2];
                int pts = int.Parse(parts[3]);
                return new EternalGoal(name, desc, pts);
            }

            case "ChecklistGoal":
            {
                if (parts.Length < 7) throw new FormatException("ChecklistGoal line malformed.");
                string name = parts[1];
                string desc = parts[2];
                int pts = int.Parse(parts[3]);
                int target = int.Parse(parts[4]);
                int bonus = int.Parse(parts[5]);
                int count = int.Parse(parts[6]);
                return new ChecklistGoal(name, desc, pts, target, bonus, count);
            }

            default:
                throw new NotSupportedException($"Unknown goal type '{type}'.");
        }
    }
}
