﻿using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;
using System.Collections.Generic;
using System.Linq;

namespace ComputerReparatieshop.Infrastructure.Sql.Services
{
    public class SqlOrderPartData : IOrderPartData
    {
        private readonly ComputerReparatieshopDbContext db;

        public SqlOrderPartData(ComputerReparatieshopDbContext db)
        {
            this.db = db;
        }

        public void Create(OrderPart OrderPart)
        {
            db.OrderParts.Add(OrderPart);
            db.SaveChanges();
        }

        public void Delete(OrderPart OrderPart)
        {
            db.OrderParts.Remove(OrderPart);
            db.SaveChanges();
        }

        public void Edit(OrderPart OrderPart)
        {
            var entry = db.Entry(OrderPart);
            entry.State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<OrderPart> Get(int orderId)
        {
            return db.OrderParts.Where(p => p.OrderId == orderId);
        }

        public OrderPart Get(int orderId, int partId)
        {
            return db.OrderParts.Find(orderId, partId); ;
        }

        public IEnumerable<OrderPart> GetAll()
        {
            return db.OrderParts;
        }
    }
}
