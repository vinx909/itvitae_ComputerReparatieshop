using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerReparatieshop.Data.Models;

namespace ComputerReparatieshop.Data.Services
{
    public class SqlOrderData : IOrderData
    {
        private readonly ComputerReparatieshopDbContext db;

        public SqlOrderData(ComputerReparatieshopDbContext db)
        {
            this.db = db;
        }

        public void Create(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }

        public void Delete(Order order)
        {
            order.ToDo = false;
            Edit(order);
            //db.Orders.Remove(order);
        }

        public void Edit(Order order)
        {
            var entry = db.Entry(order);
            entry.State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders;
        }

        public IEnumerable<Order> GetAllToDo()
        {
            return db.Orders.Where(o => o.ToDo == true);
        }
    }
}
