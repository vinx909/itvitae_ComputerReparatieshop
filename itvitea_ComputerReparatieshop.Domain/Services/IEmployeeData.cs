using ComputerReparatieshop.Domain.Models;
using System.Collections.Generic;

namespace ComputerReparatieshop.Domain.Services
{
    public interface IEmployeeData
    {
        IEnumerable<Employee> GetAll();
        Employee Get(int id);
        void Create(Employee employee);
        void Edit(Employee employee);
        void Delete(Employee employee);
    }
}
