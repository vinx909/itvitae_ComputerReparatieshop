using ComputerReparatieshop.Domain.Models;
using System.Data.Entity;

namespace ComputerReparatieshop.Infrastructure.Sql.Services
{
    public class ComputerReparatieshopDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartsList> PartsLists { get; set; }
        public DbSet<Status> Status { get; set; }
    }
}
