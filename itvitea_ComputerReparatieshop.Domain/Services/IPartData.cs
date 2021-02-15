using System.Collections.Generic;
using ComputerReparatieshop.Domain.Models;

namespace ComputerReparatieshop.Domain.Services
{
    public interface IPartData
    {
        IEnumerable<Part> GetAll();
        Part Get(int id);
        void Create(Part part);
        void Edit(Part part);
        void Delete(Part part);
    }
}
