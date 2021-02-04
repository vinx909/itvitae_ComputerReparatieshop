using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerReparatieshop.Data.Models;

namespace ComputerReparatieshop.Data.Services
{
    public class SqlImageData : IImageData
    {
        private readonly ComputerReparatieshopDbContext db;

        public SqlImageData(ComputerReparatieshopDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Image> Get(int id)
        {
            return db.Images.Where(i => i.Id == id);
        }

        public IEnumerable<Image> GetAll()
        {
            return db.Images;
        }
    }
}
