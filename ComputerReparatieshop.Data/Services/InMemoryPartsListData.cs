using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerReparatieshop.Data.Models;

namespace ComputerReparatieshop.Data.Services
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
