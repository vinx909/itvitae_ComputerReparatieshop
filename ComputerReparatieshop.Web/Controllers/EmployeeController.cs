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

        [HttpGet]
        public ActionResult Index()
        {
            Employee_Index model = new Employee_Index(db);
            return View(model); ;
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Employee model = db.Get(id);
            if (model == null)
            {
                return View(ViewNameNotFound);
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Employee model = new Employee();
            return View(model);
        }
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                Employee model = db.Get(id);
                if (model == null)
                {
                    return View(ViewNameNotFound);
                }
                return View(model);
            }
            catch (NotFoundInDatabaseException)
            {
                return View(ViewNameNotFound);
            }
        }
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

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Employee model = db.Get(id);
            if (model == null)
            {
                return View(ViewNameNotFound);
            }
            return View(model);
        }
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
