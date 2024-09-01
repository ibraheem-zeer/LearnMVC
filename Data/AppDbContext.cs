using LearnMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnMVC.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS01;Database=MVC;Trusted_Connection=True;TrustServerCertificate=True");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
