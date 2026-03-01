using AzureAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureAPI.Infrastructure.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
