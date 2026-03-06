using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentGrades
{
    public class StudentGrades
    {
        private double[][] grades;

        public int StudentCount => grades?.Length ?? 0;

        public void Initialize(int studentCount)
        {
            grades = new double[studentCount][];
        }

        public void PopulateGrades()
        {
            for (int i = 0; i < grades.Length; i++)
            {
                Console.Write($"Enter number of subjects for Student {i + 1}: ");
                int subjects = int.Parse(Console.ReadLine());
                grades[i] = new double[subjects];

                for (int j = 0; j < subjects; j++)
                {
                    Console.Write($"  Enter grade {j + 1}: ");
                    grades[i][j] = double.Parse(Console.ReadLine());
                }
            }
        }

        public void DisplayGrades()
        {
            for (int i = 0; i < grades.Length; i++)
            {
                Console.WriteLine($"Student {i + 1}: [{string.Join(", ", grades[i])}]");
            }
        }

        public double GetAverageGrade(int index) => (index >= 0 && index < grades.Length) ? grades[index].Average() : 0;

        public double GetTotalSum() => grades.Sum(row => row.Sum());

        public static StudentGrades operator +(StudentGrades a, StudentGrades b)
        {
            var res = new StudentGrades();
            res.Initialize(a.StudentCount + b.StudentCount);
            Array.Copy(a.grades, 0, res.grades, 0, a.StudentCount);
            Array.Copy(b.grades, 0, res.grades, a.StudentCount, b.StudentCount);
            return res;
        }

        public static bool operator ==(StudentGrades a, StudentGrades b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            if (a.StudentCount != b.StudentCount) return false;
            for (int i = 0; i < a.StudentCount; i++)
                if (!a.grades[i].SequenceEqual(b.grades[i])) return false;
            return true;
        }

        public static bool operator !=(StudentGrades a, StudentGrades b) => !(a == b);

        public override bool Equals(object obj) => obj is StudentGrades other && this == other;
        public override int GetHashCode() => grades?.GetHashCode() ?? 0;
    }

    class Program
    {
        static void Main(string[] args)
        {
            RunTask10();
        }

        static void PassByVal(int x) => x = 20;
        static void PassByRef(ref int x) => x = 20;

        static void PassRefByVal(List<int> list) => list.Add(1);
        static void PassRefByRef(ref List<int> list) => list = new List<int>();

        static (int sum, int sub) CalcSumSub(int a, int b) => (a + b, a - b);

        static int SumDigits(int n) => Math.Abs(n).ToString().Sum(c => c - '0');

        static bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++) if (n % i == 0) return false;
            return true;
        }

        static void MinMaxArray(int[] arr, ref int min, ref int max)
        {
            min = arr.Min();
            max = arr.Max();
        }

        static long Factorial(int n)
        {
            long res = 1;
            for (int i = 1; i <= n; i++) res *= i;
            return res;
        }

        static string ChangeChar(string s, int pos, char c)
        {
            char[] arr = s.ToCharArray();
            arr[pos] = c;
            return new string(arr);
        }

        static int SecondLargest(int[] arr) => arr.Distinct().OrderByDescending(x => x).ElementAt(1);

        static void RunTask10()
        {
            Console.WriteLine("Enter numbers separated by space:");
            int[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int maxDist = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int last = Array.LastIndexOf(arr, arr[i]);
                int dist = last - i - 1;
                if (dist > maxDist) maxDist = dist;
            }
            Console.WriteLine($"Max distance: {maxDist}");
        }

        static void Copy2D()
        {
            int[,] first = { { 1, 2 }, { 3, 4 } };
            int[,] second = new int[2, 2];
            Array.Copy(first, second, first.Length);
        }

        static void PrintReverse(int[] arr)
        {
            for (int i = arr.Length - 1; i >= 0; i--) Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }
}