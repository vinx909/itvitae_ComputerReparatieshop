using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerReparatieshop.Data.Models;
using ComputerReparatieshop.Data.Services;

namespace ComputerReparatieshop.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerData db;

        public CustomerController(ICustomerData db)
        {
            this.db = db;
        }

        // GET: Customer
        public ActionResult Index()
        {
            IEnumerable<Customer> model = db.GetAll();
            return View(model);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            Customer model = db.Get(id);
            return View(model);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here

                db.Create(customer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            Customer model = db.Get(id);
            return View(model);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                db.Edit(customer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(customer);
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            Customer model = db.Get(id);
            return View(model);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                // TODO: Add delete logic here
                db.Delete(db.Get(id));
                return RedirectToAction("Index");
            }
            catch
            {
                return Delete(id);
            }
        }
    }
}
