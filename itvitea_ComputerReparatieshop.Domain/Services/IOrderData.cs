using System.Collections.Generic;
using ComputerReparatieshop.Domain.Models;

namespace ComputerReparatieshop.Domain.Services
{
    public interface IOrderData
    {
        IEnumerable<Order> GetAll();
        IEnumerable<Order> GetAllToDo();
        Order Get(int id);
        void Edit(Order order);
        void Create(Order order);
        void Delete(Order order);
    }
}
