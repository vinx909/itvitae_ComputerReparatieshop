using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;
using ComputerReparatieshop.Web.Exceptions;
using ComputerReparatieshop.Web.Models;

namespace ComputerReparatieshop.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private const string ViewNameNotFound = "notFound";

        private readonly IEmployeeData db;

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
            if (model == null)
            {
                return View(ViewNameNotFound);
            }
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
        public ActionResult Create(Employee_Returner returnedEmployee)
        {
            Employee toCreate = null;
            try
            {
                // TODO: Add insert logic here
                returnedEmployee.CreateEmployee(ref toCreate);
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
            try
            {
                Employee_Returner model = new Employee_Returner(db, id);
                return View(model);
            }
            catch (NotFoundInDatabaseException)
            {
                return View(ViewNameNotFound);
            }
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee_Returner returnedEmployee)
        {
            Employee toEdit = null;
            try
            {
                // TODO: Add update logic here
                returnedEmployee.CreateEmployee(id, ref toEdit);
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
            if (model == null)
            {
                return View(ViewNameNotFound);
            }
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
