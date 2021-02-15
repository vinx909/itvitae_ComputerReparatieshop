using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerReparatieshop.Data.Models;

namespace ComputerReparatieshop.Data.Services
{
    public class InMemoryPartData : IPartData
    {
        List<Part> parts;

        public InMemoryPartData()
        {
            parts = new List<Part>()
            {
                new Part { Id = 0, Name = "Mouse", Price = 2400 },
                new Part { Id = 1, Name = "Keyboard", Price = 2800 },
                new Part { Id = 2, Name = "Screen", Price = 9900 },
                new Part { Id = 3, Name = "CPU", Price = 13400 },
                new Part { Id = 4, Name = "GPU", Price = 108000 }
            };
        }

        public void Create(Part part)
        {
            throw new NotImplementedException();
        }

        public void Delete(Part part)
        {
            throw new NotImplementedException();
        }

        public void Edit(Part toEdit)
        {
            throw new NotImplementedException();
        }

        public Part Get(int id)
        {
            return parts.Find(p => p.Id == id);
        }

        public IEnumerable<Models.Part> GetAll()
        {
            return parts.OrderBy(p => p.Name);
        }
    }
}
