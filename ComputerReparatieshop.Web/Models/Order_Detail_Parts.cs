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
    public class Order_Detail_Parts
    {

        public Order_Detail Details { get; set; }
        public IEnumerable<OrderPart_Detail> PartsLists { get; set; }
        [RegularExpression(@"^[0-9]{1,16}([.,][0-9]{1,3})?$")]
        [Range(0, 9999999999999999.99)]
        public decimal EmployeePayPerHour { private get; set; }
        public decimal Price {
            get
            {
                decimal toReturn = Details.HoursWorked * EmployeePayPerHour;
                foreach(OrderPart_Detail partsList in PartsLists)
                {
                    toReturn += partsList.Price * partsList.Amount;
                }
                return toReturn;
            }
        }
        public Order_Detail_Parts(ICustomerData customerData, IEmployeeData employeeData, IOrderData orderData, IPartData partData, IOrderPartData partsListData, IStatusData statusData, int orderId)
        {
            Order order = orderData.Get(orderId);
            if (order == null)
            {
                throw new NotFoundInDatabaseException();
            }
            Employee employee = employeeData.Get(order.EmployeeId);

            Details = new Order_Detail(employee, customerData,statusData,order);
            PartsLists = new List<OrderPart_Detail>();
            EmployeePayPerHour = employee.PayPerHour;

            IEnumerable<OrderPart> partsLists = partsListData.Get(orderId);
            foreach (OrderPart partsList in partsLists)
            {
                OrderPart_Detail newDetail = new OrderPart_Detail(partData, partsList);
                PartsLists = PartsLists.Concat(new[] { newDetail });
            }
        }
    }
}