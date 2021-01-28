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
            IEnumerable<Order> orders = orderDb.GetAll();
            List<Order_Index_Order> model = new List<Order_Index_Order>();

            foreach(Order order in orders)
            {
                model.Add(new Order_Index_Order { Id = order.Id, EmployeeName = employeeDb.Get(order.EmployeeId).Name, CustomerName = customerDb.Get(order.CustomerId).Name, StartDate = order.StartDate, EndDate = order.EndDate, Discription = order.Discription, StatusId = statusDb.Get(order.StatusId).StatusDescription});
            }

            return View(model);
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            Order_Edit model = new Order_Edit { Order = orderDb.Get(id), Customers = customerDb.GetAll(), Employees = employeeDb.GetAll(), Statuses = statusDb.GetAll() };
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
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
