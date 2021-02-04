using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ComputerReparatieshop.Data.Models;
using ComputerReparatieshop.Data.Services;
using ComputerReparatieshop.Web.Models;

namespace ComputerReparatieshop.Web.Controllers
{

    public class OrderController : Controller
    {
        private const string starDateChangedColour = "#FF0000";
        private const int createdOrderStatusId = 1;
        private const bool createdOrderToDO = true;

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

        public ActionResult Index(int? Id)
        {
            IEnumerable<Order> orders = orderDb.GetAllToDo();
            IEnumerable<Status> statuses = statusDb.GetAll();
            List<Order_Index_Status> modelStatus = new List<Order_Index_Status>();
            List<Order_Detail> modelOrders = new List<Order_Detail>();

            foreach(Status status in statuses)
            {
                modelStatus.Add(new Order_Index_Status { Id = status.Id, Status = status.StatusDescription, StatusColour = status.StatusColour, Amount = 0 });
            }

            foreach (Order order in orders)
            {
                Order_Detail newOrderDetail = GetOrderDetail(order);
                for(int i = 0; i < modelStatus.Count; i++)
                {
                    if (order.StatusId == modelStatus[i].Id)
                    {
                        modelStatus[i].Amount++;
                        break;
                    }
                }
                if (newOrderDetail.Id == Id)
                {
                    newOrderDetail.StatusColour = starDateChangedColour;
                }
                modelOrders.Add(newOrderDetail);
            }

            Order_Index model = new Order_Index { AmountPerStatuses = modelStatus, Orders = modelOrders };
            return View(model);
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            Order_Detail model = GetOrderDetail(orderDb.Get(id));
            return View(model);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            Order_Edit model = GetOrderEdit(new Order());

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

                order.ToDo = true;

                return RedirectToAction("Index");
            }
            catch
            {
                Order_Edit model = GetOrderEdit(order);

                return View(model);
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            Order order = orderDb.Get(id);
            Order_Edit model = GetOrderEdit(order);
            if (model.Order == null)
            {
                return View("notFound");
            }
            return View(model);
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
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index/" + id);
                }
            }
            catch
            {
                Order_Edit model = GetOrderEdit(order);
                return View(model);
            }
        }


        // GET: Order/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Order_Detail model = GetOrderDetail(orderDb.Get(id));
            return View(model);
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Order irrelavent)
        {
            try
            {
                Order order = orderDb.Get(id);
                orderDb.Delete(order);
                return RedirectToAction("Index");
            }
            catch
            {
                return Delete(id);
            }
        }

        /*
        private Order_Detail GetOrderDetail(Order order)
        {
            var status = statusDb.Get(order.StatusId);
            return GetOrderDetail(order, status);
        }

        private Order_Detail GetOrderDetail(Order order, IEnumerable<Status> statuses)
        {
            Status status = statuses.FirstOrDefault(s => s.Id == order.StatusId);
            return GetOrderDetail(order, status);
        }
        */

        private Order_Detail GetOrderDetail(Order order)
        {
            Status status = statusDb.Get(order.StatusId);
            string employeeName = employeeDb.Get(order.EmployeeId).Name;
            string customerName = customerDb.Get(order.CustomerId).Name;
            return new Order_Detail { Id = order.Id, EmployeeName = employeeName, CustomerName = customerName, StartDate = order.StartDate, EndDate = order.EndDate.GetValueOrDefault(), Description = order.Description, Status = status.StatusDescription, StatusColour = status.StatusColour, ToDo = order.ToDo };
        }

        private Order_Edit GetOrderEdit(Order order)
        {
            return new Order_Edit { Order = order, Customers = customerDb.GetAll(), Employees = employeeDb.GetAll(), Statuses = statusDb.GetAll() };
        }
    }
}
