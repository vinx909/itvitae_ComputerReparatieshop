using System;
using System.Collections.Generic;
using System.Linq;
using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;

namespace ComputerReparatieshop.Infrastructure.Services
{
    public class InMemoryOrderData : IOrderData
    {
        private readonly List<Order> orders;

        public InMemoryOrderData()
        {
            orders = new List<Order>()
            {
                new Order { Id = 0, CustomerId = 0, EmployeeId = 1, StatusId = 0, Description = "It won't turn on.", StartDate = DateTime.Now, ToDo=true }
            };

        }

        public void Create(Order order)
        {
            order.Id = orders.Max(o => o.Id) + 1;
            orders.Add(order);
        }

        public void Delete(Order order)
        {
            orders.Remove(orders.Find(o => o.Id == order.Id));
        }

        public void Edit(Order order)
        {
            Order toEdit = orders.Find(o => o.Id == order.Id);
            toEdit.CustomerId = order.CustomerId;
            toEdit.Description = order.Description;
            toEdit.EmployeeId = order.EmployeeId;
            toEdit.EndDate = order.EndDate;
            toEdit.StartDate = order.StartDate;
            toEdit.StatusId = order.StatusId;
            toEdit.ToDo = order.ToDo;
        }

        public Order Get(int id)
        {
            return orders.SingleOrDefault(o => o.Id==id);
        }

        public IEnumerable<Order> GetAll()
        {
            return orders.OrderBy(o => o.StartDate);
        }

        public IEnumerable<Order> GetAllToDo()
        {
            return GetAll().Where(o => o.ToDo == true);
        }
    }
}
