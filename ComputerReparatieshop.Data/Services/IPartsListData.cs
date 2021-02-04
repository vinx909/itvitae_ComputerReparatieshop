using System.Collections.Generic;
using ComputerReparatieshop.Data.Models;

namespace ComputerReparatieshop.Data.Services
{
    public interface IPartsListData
    {
        IEnumerable<PartsList> GetAll();
        IEnumerable<PartsList> Get(int id);
    }
}
