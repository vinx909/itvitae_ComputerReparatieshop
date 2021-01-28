using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerReparatieshop.Data.Models;

namespace ComputerReparatieshop.Data.Services
{
    public class InMemoryEmployeeData : IEmployeeData
    {
        List<Employee> employees;

        public InMemoryEmployeeData()
        {
            employees = new List<Employee>() {
                new Employee { Id = 0, Name = "Bob J", PayPerHour = 1600 },
                new Employee { Id = 1, Name = "James E", PayPerHour = 2700 },
                new Employee { Id = 2, Name = "Emma T", PayPerHour = 599 },
                new Employee { Id = 3, Name = "Tim W", PayPerHour = 4500 }
            };
        }

        public Employee Get(int id)
        {
            return employees.Find(e => e.Id == id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return employees.OrderBy(e => e.Name);
        }
    }
}
