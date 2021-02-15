using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;
using System;
using System.Collections.Generic;

namespace ComputerReparatieshop.Infrastructure.Services
{
    public class InMemoryPartsListData : IPartsListData
    {
        public void Create(PartsList partsList)
        {
            throw new NotImplementedException();
        }

        public void Delete(PartsList partsList)
        {
            throw new NotImplementedException();
        }

        public void Edit(PartsList partsList)
        {
            throw new NotImplementedException();
        }

        public PartsList Get(int orderId, int partId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PartsList> GetAll()
        {
            throw new NotImplementedException();
        }

        IEnumerable<PartsList> IPartsListData.Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
