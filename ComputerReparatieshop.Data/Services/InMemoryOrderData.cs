using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerReparatieshop.Data.Models;

namespace ComputerReparatieshop.Data.Services
{
    public class InMemoryOrderData : IOrderData
    {
        private readonly List<Order> orders;

        public InMemoryOrderData()
        {
            orders = new List<Order>()
            {
                new Order { Id = 0, CustomerId = 0, EmployeeId = 1, StatusId = 0, Discription = "It won't turn on.", StartDate = DateTime.Now }
            };

        }

        public void Edit(Order order)
        {
            throw new NotImplementedException();
        }

        public Order Get(int id)
        {
            return orders.SingleOrDefault(o => o.Id==id);
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            return orders.OrderBy(o => o.StartDate);
        }
    }
}
