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
        private const string ViewNameNotFound = "notFound";
        private readonly IPartData db;

        public PartController(IPartData db)
        {
            this.db = db;
        }

        // GET: Part
        public ActionResult Index()
        {
            Part_Index model = new Part_Index(db);
            return View(model);
        }

        // GET: Part/Details/5
        public ActionResult Details(int id)
        {
            Part model = db.Get(id);
            if (model == null)
            {
                return View(ViewNameNotFound);
            }
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
                part.CreatePart(ref toCreate);
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
            if (model == null)
            {
                return View(ViewNameNotFound);
            }
            return View(model);
        }

        // POST: Part/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Part_Returner part)
        {
            Part toEdit = null;
            try
            {
                part.CreatePart(ref toEdit);
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
            if (model == null)
            {
                return View(ViewNameNotFound);
            }
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
