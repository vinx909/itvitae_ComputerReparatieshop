using System.Collections.Generic;
using ComputerReparatieshop.Domain.Models;

namespace ComputerReparatieshop.Domain.Services
{
    public interface IOrderPartData
    {
        IEnumerable<OrderPart> GetAll();
        IEnumerable<OrderPart> Get(int orderId);
        OrderPart Get(int orderId, int partId);
        void Edit(OrderPart OrderPart);
        void Create(OrderPart OrderPart);
        void Delete(OrderPart OrderPart);
    }
}
