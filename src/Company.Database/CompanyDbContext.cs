using Company.Domain;
using Microsoft.EntityFrameworkCore;

namespace Company.Database
{
    public class CompanyDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DepartmentConfiguration).Assembly);
        }
    }
}
