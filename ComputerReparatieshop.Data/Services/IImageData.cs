using System.Collections.Generic;
using ComputerReparatieshop.Data.Models;

namespace ComputerReparatieshop.Data.Services
{
    public interface IImageData
    {
        IEnumerable<Image> GetAll();
        IEnumerable<Image> Get(int id);
    }
}
