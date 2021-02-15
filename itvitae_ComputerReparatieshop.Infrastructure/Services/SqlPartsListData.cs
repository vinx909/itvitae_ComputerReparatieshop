using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;
using System.Collections.Generic;
using System.Linq;

namespace ComputerReparatieshop.Infrastructure.Services
{
    public class SqlPartsListData : IPartsListData
    {
        private readonly ComputerReparatieshopDbContext db;

        public SqlPartsListData(ComputerReparatieshopDbContext db)
        {
            this.db = db;
        }

        public void Create(PartsList partsList)
        {
            db.PartsLists.Add(partsList);
            db.SaveChanges();
        }

        public void Delete(PartsList partsList)
        {
            db.PartsLists.Remove(partsList);
            db.SaveChanges();
        }

        public void Edit(PartsList partsList)
        {
            var entry = db.Entry(partsList);
            entry.State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<PartsList> Get(int orderId)
        {
            return db.PartsLists.Where(p => p.OrderId == orderId);
        }

        public PartsList Get(int orderId, int partId)
        {
            return db.PartsLists.Find(orderId, partId); ;
        }

        public IEnumerable<PartsList> GetAll()
        {
            return db.PartsLists;
        }
    }
}
