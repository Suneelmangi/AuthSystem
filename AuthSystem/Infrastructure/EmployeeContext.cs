using AuthSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthSystem.Infrastructure
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
        {
        }

        public EmployeeContext(DbContextOptions<EmployeeContext> options)
          : base(options)

        {

        }
       
        public DbSet<Employee> employees { get; set; }
        public DbSet<Students> Students { get; set; }
    }

}
