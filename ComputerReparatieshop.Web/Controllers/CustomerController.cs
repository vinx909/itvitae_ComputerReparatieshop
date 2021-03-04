using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;
using ComputerReparatieshop.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ComputerReparatieshop.Web.Controllers
{
    public class CustomerController : Controller
    {
        private const string ViewNameNotFound = "notFound";

        private readonly ICustomerData db;

        public CustomerController(ICustomerData db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult Index()
        {
            Customer_Index model = new Customer_Index(db);
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Customer model = db.Get(id);
            if(model == null)
            {
                return View(ViewNameNotFound);
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Customer());
        }
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Customer model = db.Get(id);
            if (model == null)
            {
                return View(ViewNameNotFound);
            }
            return View(model);
        }
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

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Customer model = db.Get(id);
            if (model == null)
            {
                return View(ViewNameNotFound);
            }
            return View(model);
        }
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
