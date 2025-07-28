using HrManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HrManagement.Data
{
    public class HrManagementDbContext : DbContext
    {
        public HrManagementDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Department> departments { get; set; }
        public DbSet<Employee> employees { get; set; }
    }
}
