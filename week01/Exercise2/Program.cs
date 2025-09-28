using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage? ");
        string percentage = Console.ReadLine();
        int number = int.Parse(percentage);

        string grade;

        if (number >= 90)
        {
            grade = "A";
        }
        else if (number >= 80)
        {
            grade = "B";
        }
        else if (number >= 70)
        {
            grade = "C";
        }
        else if (number >= 60)
        {
            grade = "D";
        }

        else if (number < 0 || number > 100)
        {
            Console.WriteLine("Sorry, choose a percentage between 0 and 100");
        }

        else
        {
            grade = "F";
        }

        string sign = "";
        int lastDigit = (int)number % 10;

        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }

        if (number >= 90 && sign == "+")
        {
            sign = "";
        }
        else if (number < 60)
        {
            sign = "";
        }

        Console.WriteLine($"Your grade is {grade}{sign}");

        if (number >= 70)
        {
            Console.WriteLine("Congratulations, You passed!");
        }
        else
        {
            Console.WriteLine("Try again. Don`t give up!");
        }



    }
}
