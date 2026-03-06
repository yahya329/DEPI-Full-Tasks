using System;
using System.Collections.Generic;

namespace StudentAssignments
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Select a Task to Run ===");
                Console.WriteLine("1. Student Grade Lab");
                Console.WriteLine("2. Temperature Check (Ternary)");
                Console.WriteLine("3. Divisibility by 3 and 4");
                Console.WriteLine("4. Positive or Negative Check");
                Console.WriteLine("5. Max and Min of 3 Numbers");
                Console.WriteLine("6. Days in Month");
                Console.WriteLine("7. Vowel or Consonant");
                Console.WriteLine("0. Exit");
                Console.Write("\nChoice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": RunStudentLab(); break;
                    case "2": Task1_Temp(); break;
                    case "3": Task2_Divisible(); break;
                    case "4": Task3_PosNeg(); break;
                    case "5": Task4_MaxMin(); break;
                    case "6": Task5_Month(); break;
                    case "7": Task6_Vowel(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid choice."); break;
                }

                Console.WriteLine("\nPress any key to return to menu...");
                Console.ReadKey();
            }
        }

        static void RunStudentLab()
        {
            Console.Write("How many students? ");
            int count = int.Parse(Console.ReadLine());

            List<string> names = new List<string>();
            List<int> grades = new List<int>();

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter student {i + 1} name: ");
                names.Add(Console.ReadLine());
                Console.Write($"Enter {names[i]}'s grade: ");
                grades.Add(int.Parse(Console.ReadLine()));
            }

            double sum = 0;
            int highest = grades[0];
            int lowest = grades[0];

            foreach (int g in grades)
            {
                sum += g;
                if (g > highest) highest = g;
                if (g < lowest) lowest = g;
            }

            Console.WriteLine("\n--- Student Report ---");
            for (int i = 0; i < names.Count; i++)
            {
                string letter;
                int g = grades[i];
                if (g >= 90) letter = "A";
                else if (g >= 80) letter = "B";
                else if (g >= 70) letter = "C";
                else if (g >= 60) letter = "D";
                else letter = "F";

                Console.WriteLine($"Name: {names[i]}, Grade: {g}, Letter: {letter}");
            }
            Console.WriteLine("---------------------");
            Console.WriteLine($"Average: {sum / count:F1}");
            Console.WriteLine($"Highest: {highest}");
            Console.WriteLine($"Lowest: {lowest}");
        }

        static void Task1_Temp()
        {
            Console.Write("Enter temperature: ");
            int t = int.Parse(Console.ReadLine());
            string res = (t < 10) ? "Just Cold" : (t > 30) ? "Just Hot" : "Just Good";
            Console.WriteLine(res);
        }

        static void Task2_Divisible()
        {
            Console.Write("Input: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine((n % 3 == 0 && n % 4 == 0) ? "Yes" : "No");
        }

        static void Task3_PosNeg()
        {
            Console.Write("Input: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(n < 0 ? "negative" : "positive");
        }

        static void Task4_MaxMin()
        {
            Console.Write("Enter 3 numbers (space separated): ");
            string[] parts = Console.ReadLine().Split(' ');
            int a = int.Parse(parts[0]);
            int b = int.Parse(parts[1]);
            int c = int.Parse(parts[2]);

            Console.WriteLine($"max element = {Math.Max(a, Math.Max(b, c))}");
            Console.WriteLine($"min element = {Math.Min(a, Math.Min(b, c))}");
        }

        static void Task5_Month()
        {
            Console.Write("Month Number: ");
            int m = int.Parse(Console.ReadLine());
            if (m == 2) Console.WriteLine("Days: 28 or 29");
            else if (m == 4 || m == 6 || m == 9 || m == 11) Console.WriteLine("Days: 30");
            else Console.WriteLine("Days: 31");
        }

        static void Task6_Vowel()
        {
            Console.Write("Input character: ");
            char c = char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();
            string v = "aeiou";
            Console.WriteLine(v.Contains(c) ? "vowel" : "consonant");
        }
    }
}