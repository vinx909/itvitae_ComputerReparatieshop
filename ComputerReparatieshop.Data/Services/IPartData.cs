using System.Collections.Generic;
using ComputerReparatieshop.Data.Models;

namespace ComputerReparatieshop.Data.Services
{
    public interface IPartData
    {
        IEnumerable<Part> GetAll();
        Part Get(int id);
    }
}
