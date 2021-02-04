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
