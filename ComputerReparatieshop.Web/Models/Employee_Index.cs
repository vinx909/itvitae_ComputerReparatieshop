using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;

namespace ComputerReparatieshop.Web.Models
{
    public class Employee_Index : AmountPerStatusModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public Employee_Index(IEmployeeData employeeData) : base()
        {
            Employees = employeeData.GetAll();
        }
    }
}