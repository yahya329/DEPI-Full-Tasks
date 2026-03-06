using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace StudentAssignments.Task4
{
    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }

    class TaskFourProgram
    {
        static void Main(string[] args)
        {
            List<Product> ProductList = new List<Product>
            {
                new Product { Name = "Tea", Category = "Beverages", UnitPrice = 2.00m, UnitsInStock = 10 },
                new Product { Name = "Coffee", Category = "Beverages", UnitPrice = 5.50m, UnitsInStock = 0 },
                new Product { Name = "Laptop", Category = "Electronics", UnitPrice = 1500.00m, UnitsInStock = 5 },
                new Product { Name = "Mouse", Category = "Electronics", UnitPrice = 25.00m, UnitsInStock = 2 },
                new Product { Name = "Sugar", Category = "Condiments", UnitPrice = 1.50m, UnitsInStock = 20 }
            };

            // LINQ - Restriction Operators
            var outOfStock = ProductList.Where(p => p.UnitsInStock == 0);
            var expensiveInStock = ProductList.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00m);

            string[] digitsArr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var shortDigits = digitsArr.Where((name, index) => name.Length < index);

            // LINQ - Element Operators
            var firstOut = ProductList.FirstOrDefault(p => p.UnitsInStock == 0);
            var firstExpensive = ProductList.FirstOrDefault(p => p.UnitPrice > 1000);

            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var secondNum = numbers.Where(n => n > 5).ElementAtOrDefault(1);

            // LINQ - Quantifiers
            bool hasEi = false;
            if (File.Exists("dictionary_english.txt"))
            {
                string[] dictionary = File.ReadAllLines("dictionary_english.txt");
                hasEi = dictionary.Any(word => word.Contains("ei"));
            }

            var catWithOutStock = ProductList.GroupBy(p => p.Category)
                                            .Where(g => g.Any(p => p.UnitsInStock == 0));

            var catAllInStock = ProductList.GroupBy(p => p.Category)
                                          .Where(g => g.All(p => p.UnitsInStock > 0));

            // Output Results
            Console.WriteLine("--- Out of Stock ---");
            foreach (var p in outOfStock) Console.WriteLine(p.Name);

            Console.WriteLine("\n--- Second Number > 5 ---");
            Console.WriteLine(secondNum);

            Console.WriteLine("\n--- Categories with Out of Stock Items ---");
            foreach (var group in catWithOutStock) Console.WriteLine(group.Key);

            Console.ReadKey();
        }
    }
}