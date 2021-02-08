using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerReparatieshop.Data.Models;

namespace ComputerReparatieshop.Data.Services
{
    public class SqlEmployeeData : IEmployeeData
    {
        private readonly ComputerReparatieshopDbContext db;

        public SqlEmployeeData(ComputerReparatieshopDbContext db)
        {
            this.db = db;
        }

        public void Create(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
        }

        public void Delete(Employee employee)
        {
            db.Employees.Remove(employee);
            db.SaveChanges();
        }

        public void Edit(Employee employee)
        {
            var entry = db.Entry(employee);
            entry.State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public Employee Get(int id)
        {
            return db.Employees.Find(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return db.Employees;
        }
    }
}
