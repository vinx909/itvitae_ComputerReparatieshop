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
    public class Order_Detail
    {
        public int OrderId { get; set; }
        public string EmployeeName { get; set; }
        public string CustomerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public string StatusColour { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        [RegularExpression(@"^[0-9]{1,16}([.,][0-9]{1,3})?$")]
        [Range(0, 9999999999999999.99)]
        public decimal HoursWorked { get; set; }

        public Order_Detail()
        {
            //required for views even with no visible references
        }
        public Order_Detail(IEmployeeData employeeData, ICustomerData customerData, IStatusData statusData, IOrderData orderData, int orderId)
        {
            Order order = orderData.Get(orderId);
            if(order == null)
            {
                throw new NotFoundInDatabaseException();
            }

            Employee employee = employeeData.Get(order.EmployeeId);
            IEnumerable<Status> statuses = statusData.GetAll();

            Construtor(employee, customerData, statuses, order);
        }
        public Order_Detail(IEmployeeData employeeData, ICustomerData customerData, IEnumerable<Status> statuses, Order order) : this(employeeData.Get(order.EmployeeId), customerData, statuses, order)
        {
            Employee employee = employeeData.Get(order.EmployeeId);

            Construtor(employee, customerData, statuses, order);
        }
        public Order_Detail(Employee employee, ICustomerData customerData, IStatusData statusData, Order order) : this(employee, customerData, statusData.GetAll(), order)
        {
            IEnumerable<Status> statuses = statusData.GetAll();

            Construtor(employee, customerData, statuses, order);
        }
        public Order_Detail(Employee employee, ICustomerData customerData, IEnumerable<Status> statuses, Order order)
        {
            Construtor(employee, customerData, statuses, order);
        }
        
        private void Construtor(Employee employee, ICustomerData customerData, IEnumerable<Status> statuses, Order order)
        {
            Status status = statuses.FirstOrDefault(s => s.Id == order.StatusId);

            OrderId = order.Id;
            EmployeeName = employee.Name;
            CustomerName = customerData.Get(order.CustomerId).Name;
            StartDate = order.StartDate;
            EndDate = order.EndDate.GetValueOrDefault();
            Description = order.Description;
            Status = status.StatusDescription;
            StatusColour = status.StatusColour;
            HoursWorked = order.HoursWorked;
        }
    }
}