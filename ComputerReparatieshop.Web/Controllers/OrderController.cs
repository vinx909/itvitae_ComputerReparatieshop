using System.Collections.Generic;
using System.Web.Mvc;
using ComputerReparatieshop.Data.Models;
using ComputerReparatieshop.Data.Services;
using ComputerReparatieshop.Web.Models;

namespace ComputerReparatieshop.Web.Controllers
{
    public class OrderController : Controller
    {
        private ICustomerData customerDb;
        private IEmployeeData employeeDb;
        private IImageListData imageListDb;
        private IOrderData orderDb;
        private IPartData partDb;
        private IPartsListData partsListDb;
        private IStatusData statusDb;

        public OrderController(ICustomerData customerDb, IEmployeeData employeeDb, IImageListData imageListDb, IOrderData orderDb, IPartData partDb, IPartsListData partsListDb, IStatusData statusDb)
        {
            this.customerDb = customerDb;
            this.employeeDb = employeeDb;
            this.imageListDb = imageListDb;
            this.orderDb = orderDb;
            this.partDb = partDb;
            this.partsListDb = partsListDb;
            this.statusDb = statusDb;
        }

        // GET: Order
        public ActionResult Index()
        {
            IEnumerable<Order> orders = orderDb.GetAllToDo();
            List<Order_Detail> model = new List<Order_Detail>();

            foreach(Order order in orders)
            {
                model.Add(GetOrderDetail(order));
            }

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
                
                orderDb.Edit(order);
                return RedirectToAction("Index");
            }
            catch
            {
                Order_Edit model = GetOrderEdit(order);
                return View(model);
            }
        }


        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            Order_Detail model = GetOrderDetail(orderDb.Get(id));
            return View(model);
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Order order)
        {
            try
            {
                orderDb.Delete(order);
                return RedirectToAction("Index");
            }
            catch
            {
                Order_Detail model = GetOrderDetail(order);
                return View(model);
            }
        }

        private Order_Detail GetOrderDetail(Order order)
        {
            return new Order_Detail { Id = order.Id, EmployeeName = employeeDb.Get(order.EmployeeId).Name, CustomerName = customerDb.Get(order.CustomerId).Name, StartDate = order.StartDate, EndDate = order.EndDate, Discription = order.Discription, Status = statusDb.Get(order.StatusId).StatusDescription, ToDo=order.ToDo};
        }

        private Order_Edit GetOrderEdit(Order order)
        {
            return new Order_Edit { Order = order, Customers = customerDb.GetAll(), Employees = employeeDb.GetAll(), Statuses = statusDb.GetAll() };
        }
    }
}
