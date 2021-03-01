using System.Collections.Generic;
using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;
using ComputerReparatieshop.Web.Exceptions;

namespace ComputerReparatieshop.Web.Models
{
    public class Order_Edit
    {
        public Order Order { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Status> Statuses { get; set; }

        public Order_Edit(ICustomerData customerData, IEmployeeData employeeData, IStatusData statusData, Order order)
        {
            Order = order;
            Customers = customerData.GetAll();
            Employees = employeeData.GetAll();
            Statuses = statusData.GetAll();
        }

        public Order_Edit(ICustomerData customerDb, IEmployeeData employeeDb, IStatusData statusDb, IOrderData orderDb, int id): this(customerDb, employeeDb, statusDb, orderDb.Get(id))
        {
            if(Order == null)
            {
                throw new NotFoundInDatabaseException();
            }
        }
    }
}