using System.Collections.Generic;
using ComputerReparatieshop.Domain.Models;

namespace ComputerReparatieshop.Domain.Services
{
    public interface IPartsListData
    {
        IEnumerable<PartsList> GetAll();
        IEnumerable<PartsList> Get(int orderId);
        PartsList Get(int orderId, int partId);
        void Edit(PartsList partsList);
        void Create(PartsList partsList);
        void Delete(PartsList partsList);
    }
}
