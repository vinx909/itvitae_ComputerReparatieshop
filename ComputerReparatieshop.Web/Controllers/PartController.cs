using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;
using ComputerReparatieshop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerReparatieshop.Web.Controllers
{
    public class PartController : Controller
    {
        private readonly IPartData db;

        public PartController(IPartData db)
        {
            this.db = db;
        }

        // GET: Part
        public ActionResult Index()
        {
            IEnumerable<Part> model = db.GetAll();
            return View(model);
        }

        // GET: Part/Details/5
        public ActionResult Details(int id)
        {
            Part model = db.Get(id);
            return View(model);
        }

        // GET: Part/Create
        public ActionResult Create()
        {
            Part model = new Part();
            return View(model);
        }

        // POST: Part/Create
        [HttpPost]
        public ActionResult Create(Part_Returner part)
        {
            Part toCreate = null;
            try
            {
                // TODO: Add insert logic here
                toCreate = new Part { Id = part.Id, Name = part.Name };
                toCreate.Price = Decimal.Parse(part.Price.Replace(".", ","));
                db.Create(toCreate);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(toCreate);
            }
        }

        // GET: Part/Edit/5
        public ActionResult Edit(int id)
        {
            Part model = db.Get(id);
            return View(model);
        }

        // POST: Part/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Part_Returner part)
        {
            Part toEdit = null;
            try
            {
                toEdit = new Part { Id = part.Id, Name = part.Name };
                toEdit.Price = Decimal.Parse(part.Price.Replace(".", ","));
                db.Edit(toEdit);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(toEdit);
            }
        }

        // GET: Part/Delete/5
        public ActionResult Delete(int id)
        {
            Part model = db.Get(id);
            return View(model);
        }

        // POST: Part/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Part part = db.Get(id);
                db.Delete(part);
                return RedirectToAction("Index");
            }
            catch
            {
                return Delete(id);
            }
        }
    }
}
