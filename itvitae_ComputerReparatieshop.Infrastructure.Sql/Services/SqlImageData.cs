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

        public void Create(Image image)
        {
            db.Images.Add(image);
            db.SaveChanges();
        }

        public void Delete(Image image)
        {
            db.Images.Remove(image);
            db.SaveChanges();
        }

        public IEnumerable<Image> GetOrderImages(int id)
        {
            return db.Images.Where(i => i.OrderId == id);
        }

        public IEnumerable<Image> GetAll()
        {
            return (IEnumerable<Image>)db.Images;
        }

        public Image Get(int id)
        {
            return db.Images.Find(id);
        }
    }
}
