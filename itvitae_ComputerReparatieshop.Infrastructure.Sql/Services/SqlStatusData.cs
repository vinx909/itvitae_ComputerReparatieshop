using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;
using System.Collections.Generic;

namespace ComputerReparatieshop.Infrastructure.Sql.Services
{
    public class SqlStatusData : IStatusData
    {
        private readonly ComputerReparatieshopDbContext db;

        public SqlStatusData(ComputerReparatieshopDbContext db)
        {
            this.db = db;
        }
        public Status Get(int id)
        {
            return db.Status.Find(id);
        }

        public IEnumerable<Status> GetAll()
        {
            return db.Status;
        }
    }
}
