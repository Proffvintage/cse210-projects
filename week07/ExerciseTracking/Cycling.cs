using System;

public class Cycling : Activity
{
    private double _speedMph;

    public Cycling(DateTime date, int minutes, double speedMph)
        : base(date, minutes)
    {
        _speedMph = speedMph;
    }

    protected override string GetName() => "Cycling";

    public override double GetDistance()
    {
        return _speedMph * (GetMinutes() / 60.0);
    }

    public override double GetSpeed() => _speedMph;

    public override double GetPace()
    {
        return 60.0 / _speedMph;
    }
}
