using System;
using System.Collections.Generic;
using System.Linq;
using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;

namespace ComputerReparatieshop.Infrastructure.InMemory.Services
{
    public class InMemoryPartData : IPartData
    {
        private readonly List<Part> parts;

        public InMemoryPartData()
        {
            parts = new List<Part>()
            {
                new Part { Id = 0, Name = "Mouse", Price = 24.00M },
                new Part { Id = 1, Name = "Keyboard", Price = 28.00M },
                new Part { Id = 2, Name = "Screen", Price = 99.00M },
                new Part { Id = 3, Name = "CPU", Price = 134.00M },
                new Part { Id = 4, Name = "GPU", Price = 1080.00M }
            };
        }

        public void Create(Part part)
        {
            part.Id = parts.Max(o => o.Id) + 1;
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
