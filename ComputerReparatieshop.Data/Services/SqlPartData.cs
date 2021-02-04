using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerReparatieshop.Data.Models;

namespace ComputerReparatieshop.Data.Services
{
    public class SqlPartData : IPartData
    {
        private readonly ComputerReparatieshopDbContext db;

        public SqlPartData(ComputerReparatieshopDbContext db)
        {
            this.db = db;
        }
        public Part Get(int id)
        {
            return db.Parts.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Part> GetAll()
        {
            return db.Parts;
        }
    }
}
