using System;

public class Running : Activity
{
    private double _distanceMiles;

    public Running(DateTime date, int minutes, double distanceMiles)
        : base(date, minutes)
    {
        _distanceMiles = distanceMiles;
    }

    protected override string GetName() => "Running";

    public override double GetDistance() => _distanceMiles;

    public override double GetSpeed()
    {
        return (_distanceMiles / GetMinutes()) * 60.0;
    }

    public override double GetPace()
    {
        return GetMinutes() / _distanceMiles;
    }
}
