using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerReparatieshop.Infrastructure.InMemory.Services
{
    public class InMemoryOrderPartData : IOrderPartData
    {
        private readonly List<OrderPart> partsLists;

        public InMemoryOrderPartData()
        {
            partsLists = new List<OrderPart>();
        }

        public void Create(OrderPart partsList)
        {
            partsLists.Add(partsList);
        }

        public void Delete(OrderPart partsList)
        {
            partsLists.Remove(partsList);
        }

        public void Edit(OrderPart partsList)
        {
            foreach(OrderPart toEdit in partsLists)
            {
                if (toEdit.OrderId == partsList.OrderId && toEdit.PartId == partsList.PartId)
                {
                    toEdit.Amount = partsList.Amount;
                    break;
                }
            }
        }

        public OrderPart Get(int orderId, int partId)
        {
            return partsLists.SingleOrDefault(p => p.OrderId == orderId && p.PartId == partId);
        }

        public IEnumerable<OrderPart> GetAll()
        {
            return partsLists;
        }

        IEnumerable<OrderPart> IOrderPartData.Get(int id)
        {
            return partsLists.Where(p => p.OrderId==id);
        }
    }
}
