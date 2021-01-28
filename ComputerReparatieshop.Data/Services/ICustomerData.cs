using System.Collections.Generic;
using ComputerReparatieshop.Data.Models;

namespace ComputerReparatieshop.Data.Services
{
    public interface ICustomerData
    {
        IEnumerable<Customer> GetAll();
        Customer Get(int id);
    }
}
