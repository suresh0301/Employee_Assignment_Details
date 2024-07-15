using AssignmentEmployeeDetails.Models;
using Microsoft.EntityFrameworkCore;
namespace AssignmentEmployeeDetails.Entity
{
    public class EmployeeDbContext:DbContext
    {

        public EmployeeDbContext(DbContextOptions options): base(options)
        {

        }


        public DbSet<EmployeeDemo> Employees { get; set; }
    }
}
