using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;

namespace ComputerReparatieshop.Web.Models
{
    public class AmountPerStatusModel
    {
        public IEnumerable<Order_Index_Status> AmountPerStatuses { get; set; }

        public AmountPerStatusModel()
        {
            IStatusData statusData = DependencyResolver.Current.GetService<IStatusData>();
            IOrderData orderData = DependencyResolver.Current.GetService<IOrderData>();

            AmountPerStatuses = new List<Order_Index_Status>();

            IEnumerable<Status> statuses = statusData.GetAll();
            IEnumerable<Order> orders = orderData.GetAllToDo();

            foreach (Status status in statuses)
            {
                AmountPerStatuses = AmountPerStatuses.Concat(new[] { new Order_Index_Status { Id = status.Id, Status = status.StatusDescription, StatusColour = status.StatusColour, Amount = 0 } });
            }
            foreach (Order order in orders)
            {
                foreach (Order_Index_Status status in AmountPerStatuses)
                {
                    if (order.StatusId == status.Id)
                    {
                        status.Amount++;
                        break;
                    }
                }
            }
        }
    }
}