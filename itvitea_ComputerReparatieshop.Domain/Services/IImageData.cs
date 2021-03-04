using System.Collections.Generic;
using ComputerReparatieshop.Domain.Models;

namespace ComputerReparatieshop.Domain.Services
{
    public interface IImageData
    {
        IEnumerable<Image> GetAll();
        IEnumerable<Image> GetOrderImages(int id);
        void Create(Image image);
        void Delete(Image image);
        Image Get(int id);
    }
}
