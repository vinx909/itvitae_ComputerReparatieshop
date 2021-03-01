using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;
using ComputerReparatieshop.Web.Exceptions;

namespace ComputerReparatieshop.Web.Models
{
    public class Employee_Returner
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [RegularExpression(@"^[0-9]{1,16}([.,][0-9]{1,3})?$")]
        [Range(0, 9999999999999999.99)]
        public string PayPerHour { get; set; }

        public Employee_Returner()
        {
            //required for views even with no visible references
        }
        public Employee_Returner(IEmployeeData data, int employeeId)
        {
            Employee employee = data.Get(employeeId);
            if (employee == null)
            {
                throw new NotFoundInDatabaseException();
            }
            Name = employee.Name;
            PayPerHour = ("" + employee.PayPerHour).Replace(",", ".");
        }

        public void CreateEmployee(int id, ref Employee employeeMemorySpace)
        {
            employeeMemorySpace = new Employee { Id = id, Name = Name };
            employeeMemorySpace.PayPerHour = ParsePayPerHour();
        }
        public void CreateEmployee(ref Employee employeeMemorySpace)
        {
            employeeMemorySpace = new Employee { Name = Name };
            employeeMemorySpace.PayPerHour = ParsePayPerHour();
        }
        private Decimal ParsePayPerHour()
        {
            return Decimal.Parse(PayPerHour.Replace(".", ","));
        }
    }
}