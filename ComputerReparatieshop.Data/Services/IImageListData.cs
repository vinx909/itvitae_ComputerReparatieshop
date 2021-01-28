using System.Collections.Generic;
using ComputerReparatieshop.Data.Models;

namespace ComputerReparatieshop.Data.Services
{
    public interface IImageListData
    {
        IEnumerable<ImageList> GetAll();
        IEnumerable<ImageList> Get(int id);
    }
}
