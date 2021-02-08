using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerReparatieshop.Data.Models;

namespace ComputerReparatieshop.Data.Services
{
    public class InMemoryCustomerData : ICustomerData
    {
        List<Customer> customers;

        public InMemoryCustomerData()
        {
            customers = new List<Customer>()
            {
                new Customer { Id = 0, Auth = 0, Name = "Tim F" },
                new Customer { Id = 1, Auth = 0, Name = "James J" },
                new Customer { Id = 2, Auth = 0, Name = "Jeroen H" }
            };
        }

        public void Create(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Edit(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            return customers.Find(c => c.Id == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return customers.OrderBy(c => c.Name);
        }
    }
}
