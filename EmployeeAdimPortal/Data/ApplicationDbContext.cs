using Microsoft.EntityFrameworkCore;
using EmployeeAdminPortal.Models.Entities;

namespace EmployeeAdminPortal.Data
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public  DbSet<Employee>? Employees { get; set; }


    }
}
