using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerReparatieshop.Infrastructure.Services
{
    public class InMemoryCustomerData : ICustomerData
    {
        private readonly List<Customer> customers;

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
            customers.Add(customer);
        }

        public void Delete(Customer customer)
        {
            customers.Remove(customer);
        }

        public void Edit(Customer customer)
        {
            foreach (Customer toEdit in customers)
            {
                if (toEdit.Id == customer.Id)
                {
                    toEdit.Name = customer.Name;
                    toEdit.Auth = customer.Auth;
                    break;
                }
            }
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
