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
        private const int createdOrderStatusId = 1;
        private const bool createdOrderToDO = true;
        private const string ViewNameNotFound = "notFound";
        private const string ViewNamePartNotFound = "partNotFound";
        private const string ViewNameImageNotFound = "imageNotFound";
        private const string ActionNameIndex = "Index";
        private const string ActionNameIndexWithId = "Index/";
        private const string ActionNameDetails = "Details/";
        private readonly ICustomerData customerDb;
        private readonly IEmployeeData employeeDb;
        private readonly IImageData imageListDb;
        private readonly IOrderData orderDb;
        private readonly IPartData partDb;
        private readonly IOrderPartData OrderPartDb;
        private readonly IStatusData statusDb;

        public OrderController(ICustomerData customerDb, IEmployeeData employeeDb, IImageData imageListDb, IOrderData orderDb, IPartData partDb, IOrderPartData OrderPartDb, IStatusData statusDb)
        {
            this.customerDb = customerDb;
            this.employeeDb = employeeDb;
            this.imageListDb = imageListDb;
            this.orderDb = orderDb;
            this.partDb = partDb;
            this.OrderPartDb = OrderPartDb;
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
                Order_FullDetails model = new Order_FullDetails(customerDb, employeeDb, imageListDb, orderDb, partDb, OrderPartDb, statusDb, id);
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


        public ActionResult DetailsOrderPart(int id, int partId)
        {
            try
            {
                OrderPart_Detail model = new OrderPart_Detail(OrderPartDb, partDb, id, partId);
                return View(model);
            }
            catch(NotFoundInDatabaseException)
            {
                return View(ViewNamePartNotFound, id);
            }
        }

        [HttpGet]
        public ActionResult EditOrderPart(int id, int partId)
        {
            OrderPart model = OrderPartDb.Get(id, partId);
            if (model == null)
            {
                return View(ViewNamePartNotFound, id);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult EditOrderPart(int id, OrderPart OrderPart)
        {
            try
            {
                OrderPartDb.Edit(OrderPart);
                return RedirectToAction(ActionNameDetails + id);
            }
            catch
            {
                return View(OrderPart);
            }
        }

        [HttpGet]
        public ActionResult CreatePart(int id)
        {
            OrderPart_Create model = new OrderPart_Create(id, partDb);
            return View(model);
        }
        [HttpPost]
        public ActionResult CreatePart(int id, OrderPart_Create OrderPart)
        {
            try
            {
                OrderPart.WorkingOn.OrderId = id;
                OrderPartDb.Create(OrderPart.WorkingOn);
                return RedirectToAction(ActionNameDetails + id);
            }
            catch
            {
                OrderPart.Parts = partDb.GetAll();
                return View(OrderPart);
            }
        }

        [HttpGet]
        public ActionResult DeleteOrderPart(int id, int partId){
            try
            {
                OrderPart_Detail model = new OrderPart_Detail(partDb, OrderPartDb, id, partId);
                return View(model);
            }
            catch(NotFoundInDatabaseException)
            {
                return View(ViewNamePartNotFound, id);
            }
        }
        [HttpPost]
        public ActionResult DeleteOrderPart(int id, int partId, OrderPart OrderPart)
        {
            try
            {
                OrderPartDb.Delete(OrderPartDb.Get(id, partId));
                return RedirectToAction(ActionNameDetails + id);
            }
            catch
            {
                return DeleteOrderPart(id, partId);
            }
        }
        [HttpGet]
        public ActionResult CreateImage(int id)
        {
            if (orderDb.IdExists(id)==false)
            {
                return RedirectToAction(ViewNameNotFound);
            }
            Image model = new Image() { OrderId = id };
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateImage(int id, Image image)
        {
            try
            {
                imageListDb.Create(image);
                return RedirectToAction(ActionNameDetails + id);
            }
            catch
            {
                return View(image);
            }
        }
        [HttpGet]
        public ActionResult DetailImage(int id)
        {
            Image model = imageListDb.Get(id);
            if (model == null)
            {
                return View(ViewNameImageNotFound);
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult DeleteImage(int id)
        {
            Image model = imageListDb.Get(id);
            if (model == null)
            {
                return View(ViewNameImageNotFound);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult DeleteImage(Image OrderPart)
        {
            Image model = imageListDb.Get(OrderPart.Id);
            if (model == null)
            {
                return View(ViewNameImageNotFound);
            }
            try
            {
                imageListDb.Delete(model);
                return RedirectToAction(ActionNameDetails + model.OrderId);
            }
            catch
            {
                return View(model);
            }
        }
    }
}
