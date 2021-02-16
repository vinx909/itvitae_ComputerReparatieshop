using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerReparatieshop.Infrastructure.InMemory.Services
{
    public class InMemoryPartsListData : IPartsListData
    {
        private readonly List<PartsList> partsLists;

        public InMemoryPartsListData()
        {
            partsLists = new List<PartsList>();
        }

        public void Create(PartsList partsList)
        {
            partsLists.Add(partsList);
        }

        public void Delete(PartsList partsList)
        {
            partsLists.Remove(partsList);
        }

        public void Edit(PartsList partsList)
        {
            foreach(PartsList toEdit in partsLists)
            {
                if (toEdit.OrderId == partsList.OrderId && toEdit.PartId == partsList.PartId)
                {
                    toEdit.Amount = partsList.Amount;
                    break;
                }
            }
        }

        public PartsList Get(int orderId, int partId)
        {
            return partsLists.SingleOrDefault(p => p.OrderId == orderId && p.PartId == partId);
        }

        public IEnumerable<PartsList> GetAll()
        {
            return partsLists;
        }

        IEnumerable<PartsList> IPartsListData.Get(int id)
        {
            return partsLists.Where(p => p.OrderId==id);
        }
    }
}
