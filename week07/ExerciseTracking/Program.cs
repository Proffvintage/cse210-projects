using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var activities = new List<Activity>
        {
            new Running(new DateTime(2024, 9, 3), 30, 3.0),

            new Cycling(new DateTime(2024, 9, 4), 40, 18.5),

            new Swimming(new DateTime(2024, 9, 5), 25, 40)
        };

        foreach (var a in activities)
        {
            Console.WriteLine(a.GetSummary());
        }
    }
}
