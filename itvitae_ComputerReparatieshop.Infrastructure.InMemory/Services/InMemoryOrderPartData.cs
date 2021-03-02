using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerReparatieshop.Infrastructure.InMemory.Services
{
    public class InMemoryOrderPartData : IOrderPartData
    {
        private readonly List<OrderPart> OrderParts;

        public InMemoryOrderPartData()
        {
            OrderParts = new List<OrderPart>();
        }

        public void Create(OrderPart OrderPart)
        {
            OrderParts.Add(OrderPart);
        }

        public void Delete(OrderPart OrderPart)
        {
            OrderParts.Remove(OrderPart);
        }

        public void Edit(OrderPart OrderPart)
        {
            foreach(OrderPart toEdit in OrderParts)
            {
                if (toEdit.OrderId == OrderPart.OrderId && toEdit.PartId == OrderPart.PartId)
                {
                    toEdit.Amount = OrderPart.Amount;
                    break;
                }
            }
        }

        public OrderPart Get(int orderId, int partId)
        {
            return OrderParts.SingleOrDefault(p => p.OrderId == orderId && p.PartId == partId);
        }

        public IEnumerable<OrderPart> GetAll()
        {
            return OrderParts;
        }

        IEnumerable<OrderPart> IOrderPartData.Get(int id)
        {
            return OrderParts.Where(p => p.OrderId==id);
        }
    }
}
