using System.Collections.Generic;
using ComputerReparatieshop.Domain.Models;

namespace ComputerReparatieshop.Domain.Services
{
    public interface IImageData
    {
        IEnumerable<Image> GetAll();
        IEnumerable<Image> Get(int id);
    }
}
