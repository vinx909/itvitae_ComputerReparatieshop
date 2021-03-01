using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;
using ComputerReparatieshop.Web.Exceptions;
using ComputerReparatieshop.Web.Models;

namespace ComputerReparatieshop.Web.Controllers
{

    public class OrderController : Controller
    {
        private const string starDateChangedColour = "#FF0000";
        private const int createdOrderStatusId = 1;
        private const bool createdOrderToDO = true;
        private const string ViewNameNotFound = "notFound";
        private const string ViewNamePartNotFound = "partNotFound";
        private const string ActionNameIndex = "Index";
        private const string ActionNameIndexWithId = "Index/";
        private const string ActionNameDetails = "Details/";

        private readonly ICustomerData customerDb;
        private readonly IEmployeeData employeeDb;
        private readonly IImageData imageListDb;
        private readonly IOrderData orderDb;
        private readonly IPartData partDb;
        private readonly IPartsListData partsListDb;
        private readonly IStatusData statusDb;

        public OrderController(ICustomerData customerDb, IEmployeeData employeeDb, IImageData imageListDb, IOrderData orderDb, IPartData partDb, IPartsListData partsListDb, IStatusData statusDb)
        {
            this.customerDb = customerDb;
            this.employeeDb = employeeDb;
            this.imageListDb = imageListDb;
            this.orderDb = orderDb;
            this.partDb = partDb;
            this.partsListDb = partsListDb;
            this.statusDb = statusDb;
        }

        public ActionResult Index(int? id)
        {
            Order_Index model = new Order_Index(employeeDb, customerDb, orderDb, statusDb, id);
            return View(model);
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Order_Detail_Parts model = new Order_Detail_Parts(customerDb, employeeDb, orderDb, partDb, partsListDb, statusDb, id);
                return View(model);
            }
            catch (NotFoundInDatabaseException)
            {
                return View(ViewNameNotFound);
            }
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            Order_Edit model = new Order_Edit(customerDb, employeeDb, statusDb, new Order());

            return View(model);
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(Order order)
        {
            try
            {
                order.StatusId = createdOrderStatusId;
                order.ToDo = createdOrderToDO;

                orderDb.Create(order);

                return RedirectToAction(ActionNameIndex);
            }
            catch
            {
                Order_Edit model = new Order_Edit(customerDb, employeeDb, statusDb, order);

                return View(model);
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Order_Edit model = new Order_Edit(customerDb, employeeDb, statusDb, orderDb, id);
                return View(model);
            }
            catch(NotFoundInDatabaseException)
            {
                return View(ViewNameNotFound);
            }
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Order order)
        {
            try
            {
                // TODO: Add update logic here
                DateTime oldStartDate = orderDb.Get(id).StartDate;
                orderDb.Edit(order);
                if (order.StartDate == oldStartDate)
                {
                    return RedirectToAction(ActionNameIndex);
                }
                else
                {
                    return RedirectToAction(ActionNameIndexWithId + id);
                }
            }
            catch
            {
                try
                {
                    Order_Edit model = new Order_Edit(customerDb, employeeDb, statusDb, order); ;
                    return View(model);
                }
                catch (NotFoundInDatabaseException)
                {
                    return View(ViewNameNotFound);
                }
            }
        }


        // GET: Order/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                Order_Detail model = new Order_Detail(employeeDb, customerDb, statusDb, orderDb, id);
                return View(model);
            }
            catch (NotFoundInDatabaseException)
            {
                return View(ViewNameNotFound);
            }
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Order irrelavent)
        {
            try
            {
                Order order = orderDb.Get(id);
                orderDb.Delete(order);
                return RedirectToAction(ActionNameIndex);
            }
            catch
            {
                return Delete(id);
            }
        }


        public ActionResult DetailsPartList(int id, int partId)
        {
            try
            {
                PartsList_Detail model = new PartsList_Detail(partsListDb, partDb, id, partId);
                return View(model);
            }
            catch(NotFoundInDatabaseException)
            {
                return View(ViewNamePartNotFound, id);
            }
        }

        [HttpGet]
        public ActionResult EditPartList(int id, int partId)
        {
            PartsList model = partsListDb.Get(id, partId);
            if (model == null)
            {
                return View(ViewNamePartNotFound, id);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult EditPartList(int id, PartsList partsList)
        {
            try
            {
                partsListDb.Edit(partsList);
                return RedirectToAction(ActionNameDetails + id);
            }
            catch
            {
                return View(partsList);
            }
        }

        [HttpGet]
        public ActionResult CreatePart(int id)
        {
            PartsList_Create model = new PartsList_Create(id, partDb);
            return View(model);
        }
        [HttpPost]
        public ActionResult CreatePart(int id, PartsList_Create partsList)
        {
            try
            {
                partsList.WorkingOn.OrderId = id;
                partsListDb.Create(partsList.WorkingOn);
                return RedirectToAction(ActionNameDetails + id);
            }
            catch
            {
                partsList.Parts = partDb.GetAll();
                return View(partsList);
            }
        }

        [HttpGet]
        public ActionResult DeletePartList(int id, int partId){
            try
            {
                PartsList_Detail model = new PartsList_Detail(partDb, partsListDb, id, partId);
                return View(model);
            }
            catch(NotFoundInDatabaseException)
            {
                return View(ViewNamePartNotFound, id);
            }
        }
        //[HttpPost]
        public ActionResult DeletePartList(int id, int partId, PartsList partsList)
        {
            try
            {
                partsListDb.Delete(partsListDb.Get(id, partId));
                return RedirectToAction(ActionNameDetails + id);
            }
            catch
            {
                return DeletePartList(id, partId);
            }
        }
    }
}
