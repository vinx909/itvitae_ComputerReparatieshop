using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;

namespace ComputerReparatieshop.Web.Models
{
    public class Order_Index
    {
        private const string starDateChangedColour = "#FF0000";

        public IEnumerable<Order_Index_Status> AmountPerStatuses { get; set; }
        public IEnumerable<Order_Detail> Orders { get; set; }

        public Order_Index(IEmployeeData employeeData, ICustomerData customerData, IOrderData orderData, IStatusData statusData, int? id)
        {
            AmountPerStatuses = new List<Order_Index_Status>();
            Orders = new List<Order_Detail>();

            IEnumerable<Order> orders = orderData.GetAllToDo();
            IEnumerable<Status> statuses = statusData.GetAll();

            foreach (Status status in statuses)
            {
                AmountPerStatuses = AmountPerStatuses.Concat(new[] { new Order_Index_Status { Id = status.Id, Status = status.StatusDescription, StatusColour = status.StatusColour, Amount = 0 } }) ;
            }

            foreach (Order order in orders)
            {
                Order_Detail newOrderDetail = new Order_Detail(employeeData, customerData, statuses, order);
                foreach (Order_Index_Status status in AmountPerStatuses)
                {
                    if (order.StatusId == status.Id)
                    {
                        status.Amount++;
                        break;
                    }
                }
                if (newOrderDetail.OrderId == id)
                {
                    newOrderDetail.StatusColour = starDateChangedColour;
                }
                Orders = Orders.Concat(new[] { newOrderDetail });
            }
        }
    }
}