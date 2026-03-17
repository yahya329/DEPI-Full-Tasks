using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depi_Tasks
{
    internal class DynSeedingTest
    {
        private readonly AppDbContext _context;

        public DynSeedingTest(AppDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (!_context.Courses.Any())
            {
                var courses = new List<Course>
            {
                new Course { Title = "AI", Duration = 50 },
                new Course { Title = "Machine Learning", Duration = 45 }
            };

                _context.Courses.AddRange(courses);
                _context.SaveChanges();
            }
        }
    }
}
