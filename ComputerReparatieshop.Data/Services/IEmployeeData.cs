using System.Collections.Generic;
using ComputerReparatieshop.Data.Models;

namespace ComputerReparatieshop.Data.Services
{
    public interface IEmployeeData
    {
        IEnumerable<Employee> GetAll();
        Employee Get(int employeeId);
    }
}
