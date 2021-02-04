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
