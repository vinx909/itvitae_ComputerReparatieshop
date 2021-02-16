using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;
using System.Collections.Generic;
using System.Linq;

namespace ComputerReparatieshop.Infrastructure.Sql.Services
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
            return (IEnumerable<Image>)db.Images;
        }
    }
}
