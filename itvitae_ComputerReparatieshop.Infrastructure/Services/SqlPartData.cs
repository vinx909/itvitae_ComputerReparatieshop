﻿using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;
using System.Collections.Generic;

namespace ComputerReparatieshop.Infrastructure.Services
{
    public class SqlPartData : IPartData
    {
        private readonly ComputerReparatieshopDbContext db;

        public SqlPartData(ComputerReparatieshopDbContext db)
        {
            this.db = db;
        }

        public void Create(Part part)
        {
            db.Parts.Add(part);
            db.SaveChanges();
        }

        public void Delete(Part part)
        {
            db.Parts.Remove(part);
            db.SaveChanges();
        }

        public void Edit(Part part)
        {
            var entry = db.Entry(part);
            entry.State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public Part Get(int id)
        {
            return db.Parts.Find(id);
        }

        public IEnumerable<Part> GetAll()
        {
            return db.Parts;
        }
    }
}
