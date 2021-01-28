using System.Collections.Generic;
using ComputerReparatieshop.Data.Models;

namespace ComputerReparatieshop.Data.Services
{
    public interface IStatusData
    {
        IEnumerable<Status> GetAll();
        Status Get(int id);
    }
}
