using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depi_Tasks
{
    struct ValuePoint
    {
        public int X;
    }


    class RefPoint
    {
        public int X;
    }

    class Student
    {
        public string Name { get; set; }
    }


    class Car
    {
        public string Model { get; set; }
    }

    class Book
    {
        public void Read()
        {
            Console.WriteLine("Reading the book !");
        }
    }

    internal class C__First_Task
    {
        static void Main(string[] args)
        {
            ModifyChallenge();
            Task2_ReferenceEquality();
            Task3_SwapMystery();
            Task4_ShallowCopy();
            Task5_NullReferenceTrap();
        }

        // Task 1
        static void Modify(ValuePoint vp, RefPoint rp)
        {
            vp.X = 100;
            rp.X = 100;
        }

        static void ModifyChallenge()
        {
            Console.WriteLine("Task 1:");

            ValuePoint vp;
            vp.X = 10;

            RefPoint rp = new RefPoint();
            rp.X = 10;

            Modify(vp, rp);

            Console.WriteLine("ValuePoint X = " + vp.X);
            Console.WriteLine("RefPoint X = " + rp.X);
        }

        // Task 2
        static void Task2_ReferenceEquality()
        {
            Console.WriteLine("\nTask 2:");

            Student s1 = new Student { Name = "Ali" };
            Student s2 = new Student { Name = "Ali" };
            Student s3 = s1;

            Console.WriteLine(s1 == s2);
            Console.WriteLine(s1 == s3);
        }

        // Task 3
        static void Swap(int a, int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void SwapRef(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void Task3_SwapMystery()
        {
            Console.WriteLine("\nTask 3:");

            int x = 5;
            int y = 10;

            Swap(x, y);

            Console.WriteLine("After Swap:");
            Console.WriteLine("x = " + x);
            Console.WriteLine("y = " + y);

            SwapRef(ref x, ref y);

            Console.WriteLine("After SwapRef:");
            Console.WriteLine("x = " + x);
            Console.WriteLine("y = " + y);
        }

        // Task 4
        static void Task4_ShallowCopy()
        {
            Console.WriteLine("\nTask 4:");

            Car car1 = new Car { Model = "Toyota" };

            Car car2 = car1;

            car2.Model = "Tesla";

            Console.WriteLine(car1.Model);
        }

        // Task 5
        static void Task5_NullReferenceTrap()
        {
            Console.WriteLine("\nTask 5:");

            Book myBook = null;

            if (myBook != null)
            {
                myBook.Read();
            }
            else
            {
                Console.WriteLine("Book is null ");
                myBook = new Book();
                myBook.Read();
            }
        }
    }
}
