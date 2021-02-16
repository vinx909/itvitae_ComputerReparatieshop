using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;
using ComputerReparatieshop.Web.Models;

namespace ComputerReparatieshop.Web.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeData db;

        public EmployeeController(IEmployeeData db)
        {
            this.db = db;
        }

        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<Employee> model = db.GetAll();
            return View(model); ;
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            Employee model = db.Get(id);
            return View(model);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            Employee model = new Employee();
            return View(model);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee_Returner employee)
        {
            Employee toCreate = null;
            try
            {
                // TODO: Add insert logic here
                toCreate = new Employee { Name = employee.Name };
                toCreate.PayPerHour = Decimal.Parse(employee.PayPerHour.Replace(".", ","));
                db.Create(toCreate);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(toCreate);
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            Employee employee = db.Get(id);
            Employee_Returner model = getEmployeeReturner(employee);
            return View(model);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee_Returner employee)
        {
            Employee toEdit = null;
            try
            {
                // TODO: Add update logic here
                toEdit = new Employee { Id = id, Name = employee.Name };
                toEdit.PayPerHour = Decimal.Parse(employee.PayPerHour.Replace(".",","));
                db.Edit(toEdit);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(toEdit);
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            Employee model = db.Get(id);
            return View(model);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Employee employee = db.Get(id);
                db.Delete(employee);
                return RedirectToAction("Index");
            }
            catch
            {
                return Delete(id);
            }
        }

        private Employee_Returner getEmployeeReturner(Employee employee)
        {
            return new Employee_Returner { Name = employee.Name, PayPerHour = (""+employee.PayPerHour).Replace(",",".") };
        }
    }
}
