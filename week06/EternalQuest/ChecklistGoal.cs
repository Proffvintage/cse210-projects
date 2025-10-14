using System;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _bonusPoints;
    private int _currentCount;

    public ChecklistGoal(string shortName, string description, int points, int targetCount, int bonusPoints, int currentCount = 0)
        : base(shortName, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = currentCount;
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override string GetDetailsString()
    {
        string check = IsComplete() ? "X" : " ";
        return $"[{check}] {GetShortName()} ({GetDescription()}) -- Completed {_currentCount}/{_targetCount}";
    }

    public override int RecordEvent()
    {
        int awarded = GetPoints();
        if (!IsComplete())
        {
            _currentCount++;
            if (IsComplete())
            {
                awarded += _bonusPoints;
            }
        }
        else
        {
            awarded = 0;
        }
        return awarded;
    }

    public override string ToSaveString()
    {
        return $"ChecklistGoal|{GetShortName()}|{GetDescription()}|{GetPoints()}|{_targetCount}|{_bonusPoints}|{_currentCount}";
    }
}
