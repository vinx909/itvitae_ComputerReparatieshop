using System.Collections.Generic;
using ComputerReparatieshop.Domain.Models;

namespace ComputerReparatieshop.Web.Models
{
    public class Order_Edit
    {
        public Order Order { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Status> Statuses { get; set; }
    }
}