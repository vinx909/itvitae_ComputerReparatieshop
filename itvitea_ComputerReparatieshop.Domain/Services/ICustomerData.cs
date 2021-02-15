using System.Collections.Generic;
using ComputerReparatieshop.Domain.Models;

namespace ComputerReparatieshop.Domain.Services
{
    public interface ICustomerData
    {
        IEnumerable<Customer> GetAll();
        Customer Get(int id);
        void Create(Customer customer);
        void Edit(Customer customer);
        void Delete(Customer customer);
    }
}
