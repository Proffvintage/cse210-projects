using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Mindfulness Studio");
            Console.ResetColor();
            Console.WriteLine("------------------");
            Console.WriteLine("1) Breathing Activity");
            Console.WriteLine("2) Reflection Activity");
            Console.WriteLine("3) Listing Activity");
            Console.WriteLine("4) Quit");
            Console.Write("\nChoose an activity: ");

            string choice = Console.ReadLine();
            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity(
                        "Breathing Activity",
                        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
                    break;

                case "2":
                    activity = new ReflectingActivity(
                        "Reflection Activity",
                        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize your power and how you can use it in other aspects of your life.");
                    break;

                case "3":
                    activity = new ListingActivity(
                        "Listing Activity",
                        "This activity will help you reflect on the good things in your life by having you list as many items as you can in a certain area.");
                    break;

                case "4":
                    running = false;
                    continue;

                default:
                    Console.WriteLine("Invalid choice. Press Enter to continue...");
                    Console.ReadLine();
                    continue;
            }

            Console.Clear();
            activity.Run();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"\nSaved at {DateTime.Now:hh:mm tt}. Press Enter to return to the menu.");
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
