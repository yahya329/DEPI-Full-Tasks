using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Depi_Tasks
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }

        public ICollection<Stud> Students { get; set; }
    }

    public class Stud
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal GPA { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }

    public class AppDbContext : DbContext
    {
        public DbSet<Stud> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = 10,
                    Title = "Database",
                    Duration = 40
                }
            );
        }
    }

    // this is the RUN on main OK :)

    // Manual Seeding of data for testing purposes

    class Program
    {
      
        static void Main(string[] args)
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.Courses.Any())
                {
                    var courses = new List<Course>
                {
                    new Course { Title = "C#", Duration = 30 },
                    new Course { Title = "ASP.NET", Duration = 35 },
                    new Course { Title = "Algorithms", Duration = 25 }
                };

                    context.Courses.AddRange(courses);
                    context.SaveChanges();
                }

                if (!context.Students.Any())
                {
                    var students = new List<Student>
                {
                    new Student { Name = "Ali", Age = 21, GPA = 3.2m, CourseId = 1 },
                    new Student { Name = "Sara", Age = 22, GPA = 3.8m, CourseId = 2 },
                    new Student { Name = "Omar", Age = 20, GPA = 2.9m, CourseId = 3 },
                    new Student { Name = "Mona", Age = 23, GPA = 3.5m, CourseId = 1 }
                };

                    context.Students.AddRange(students);
                    context.SaveChanges();
                }
            }

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var seeder = new DynSeedingTest(context);
                seeder.Seed();
            }

        }

    }



    internal class Task_6
    {

    }
}
