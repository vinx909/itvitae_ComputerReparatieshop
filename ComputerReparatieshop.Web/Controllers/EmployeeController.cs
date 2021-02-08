using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerReparatieshop.Data.Models;
using ComputerReparatieshop.Data.Services;
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
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee_Create_Returner employee)
        {
            try
            {
                // TODO: Add insert logic here
                Employee toCreate = new Employee { Name = employee.Name, PayPerHour = Decimal.Parse(employee.PayPerHour) };
                db.Create(toCreate);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            Employee model = db.Get(id);
            return View(model);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                // TODO: Add update logic here
                db.Edit(employee);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(employee);
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
    }
}
