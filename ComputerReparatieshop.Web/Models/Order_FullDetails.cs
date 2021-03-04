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
    public class Order_FullDetails
    {

        public Order_Detail Details { get; set; }
        public IEnumerable<OrderPart_Detail> OrderParts { get; set; }
        [RegularExpression(@"^[0-9]{1,16}([.,][0-9]{1,3})?$")]
        [Range(0, 9999999999999999.99)]
        public IEnumerable<Image> Images { get; set; }
        public decimal EmployeePayPerHour { private get; set; }
        public decimal Price {
            get
            {
                decimal toReturn = Details.HoursWorked * EmployeePayPerHour;
                foreach(OrderPart_Detail OrderPart in OrderParts)
                {
                    toReturn += OrderPart.Price * OrderPart.Amount;
                }
                return toReturn;
            }
        }
        public Order_FullDetails(ICustomerData customerData, IEmployeeData employeeData, IImageData imageData, IOrderData orderData, IPartData partData, IOrderPartData OrderPartData, IStatusData statusData, int orderId)
        {
            Order order = orderData.Get(orderId);
            if (order == null)
            {
                throw new NotFoundInDatabaseException();
            }
            Employee employee = employeeData.Get(order.EmployeeId);

            Details = new Order_Detail(employee, customerData,statusData,order);
            this.OrderParts = new List<OrderPart_Detail>();
            EmployeePayPerHour = employee.PayPerHour;

            IEnumerable<OrderPart> OrderParts = OrderPartData.Get(orderId);
            foreach (OrderPart OrderPart in OrderParts)
            {
                OrderPart_Detail newDetail = new OrderPart_Detail(partData, OrderPart);
                this.OrderParts = this.OrderParts.Concat(new[] { newDetail });
            }

            Images = imageData.GetOrderImages(orderId);
        }
    }
}