using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerReparatieshop.Data.Models;

namespace ComputerReparatieshop.Data.Services
{
    public class SqlCustomerData : ICustomerData
    {
        private readonly ComputerReparatieshopDbContext db;

        public SqlCustomerData(ComputerReparatieshopDbContext db)
        {
            this.db = db;
        }

        public void Create(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            db.Customers.Remove(customer);
            db.SaveChanges();
        }

        public void Edit(Customer customer)
        {
            var entry = db.Entry(customer);
            entry.State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public Customer Get(int id)
        {
            return db.Customers.Find(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return db.Customers;
        }
    }
}
