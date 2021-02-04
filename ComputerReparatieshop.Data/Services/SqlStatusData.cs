using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerReparatieshop.Data.Models;

namespace ComputerReparatieshop.Data.Services
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
            return db.Statuses.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Status> GetAll()
        {
            return db.Statuses;
        }
    }
}
