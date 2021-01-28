using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerReparatieshop.Data.Models;

namespace ComputerReparatieshop.Data.Services
{
    public interface IOrderData
    {
        IEnumerable<Order> GetAll();
        Order Get(int id);
        void Edit(Order order);
    }
}
