using System;

public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description)
        : base(name, description)
    {
    }

    public override void Run()
    {
        Start();

        DateTime end = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < end)
        {
            int remaining = (int)Math.Max(0, (end - DateTime.Now).TotalSeconds);
            if (remaining == 0) break;

            Console.Write("Breathe in...");
            int inCount = Math.Min(4, remaining);
            ShowCountdown(inCount);
            Console.WriteLine();

            remaining = (int)Math.Max(0, (end - DateTime.Now).TotalSeconds);
            if (remaining == 0) break;

            Console.Write("Breathe out...");
            int outCount = Math.Min(6, remaining);
            ShowCountdown(outCount);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Steady rhythm. Calm focus.");
            Console.ResetColor();
        }

        End();
    }
}
