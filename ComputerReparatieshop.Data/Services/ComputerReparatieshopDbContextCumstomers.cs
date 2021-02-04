using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerReparatieshop.Data.Models;

namespace ComputerReparatieshop.Data.Services
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
    public class ComputerReparatieshopDbContextCumstomers : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
    public class ComputerReparatieshopDbContextEmployees : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
    public class ComputerReparatieshopDbContextImages : DbContext
    {
        public DbSet<Image> Images { get; set; }
    }
    public class ComputerReparatieshopDbContextOrders : DbContext
    {
        public DbSet<Order> Orders { get; set; }
    }
    public class ComputerReparatieshopDbContextParts : DbContext
    {
        public DbSet<Part> Parts { get; set; }
    }
    public class ComputerReparatieshopDbContextPartsLists : DbContext
    {
        public DbSet<PartsList> PartsLists { get; set; }
    }
    public class ComputerReparatieshopDbContextStatus : DbContext
    {
        public DbSet<Status> Status { get; set; }
    }
}
