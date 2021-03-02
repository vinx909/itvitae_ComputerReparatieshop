using System.Collections.Generic;
using ComputerReparatieshop.Domain.Models;

namespace ComputerReparatieshop.Domain.Services
{
    public interface IOrderPartData
    {
        IEnumerable<OrderPart> GetAll();
        IEnumerable<OrderPart> Get(int orderId);
        OrderPart Get(int orderId, int partId);
        void Edit(OrderPart partsList);
        void Create(OrderPart partsList);
        void Delete(OrderPart partsList);
    }
}
