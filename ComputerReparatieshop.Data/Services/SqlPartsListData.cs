using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerReparatieshop.Data.Models;

namespace ComputerReparatieshop.Data.Services
{
    public class SqlPartsListData : IPartsListData
    {
        private readonly ComputerReparatieshopDbContext db;

        public SqlPartsListData(ComputerReparatieshopDbContext db)
        {
            this.db = db;
        }
        public PartsList Get(int id)
        {
            return db.PartsLists.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<PartsList> GetAll()
        {
            return db.PartsLists;
        }
    }
}
