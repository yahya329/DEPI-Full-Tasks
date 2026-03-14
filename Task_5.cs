using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EF_Lab
{
    public class Book
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishedDate { get; set; }
    }

    public class myApp : DbContext
    {

        public DbSet<Book> Books { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=LibraryDb;Trusted_Connection=True;");
        }
    }
}
