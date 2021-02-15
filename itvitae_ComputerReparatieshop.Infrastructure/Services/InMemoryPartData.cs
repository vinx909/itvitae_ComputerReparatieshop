using System;
using System.Collections.Generic;
using System.Linq;
using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;

namespace ComputerReparatieshop.Infrastructure.Services
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
            parts.Add(part);
        }

        public void Delete(Part part)
        {
            parts.Remove(part);
        }

        public void Edit(Part part)
        {
            foreach(Part toEdit in parts)
            {
                if (toEdit.Id == part.Id)
                {
                    toEdit.Name = part.Name;
                    toEdit.Price = part.Price;
                    break;
                }
            }
        }

        public Part Get(int id)
        {
            return parts.Find(p => p.Id == id);
        }

        public IEnumerable<Part> GetAll()
        {
            return parts.OrderBy(p => p.Name);
        }
    }
}
