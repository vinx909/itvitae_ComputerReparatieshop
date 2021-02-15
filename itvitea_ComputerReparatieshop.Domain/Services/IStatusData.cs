using ComputerReparatieshop.Domain.Models;
using System.Collections.Generic;

namespace ComputerReparatieshop.Domain.Services
{
    public interface IStatusData
    {
        IEnumerable<Status> GetAll();
        Status Get(int id);
    }
}
