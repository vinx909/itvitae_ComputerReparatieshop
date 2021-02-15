using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;
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

            foreach (Status status in statuses)
            {
                modelStatus.Add(new Order_Index_Status { Id = status.Id, Status = status.StatusDescription, StatusColour = status.StatusColour, Amount = 0 });
            }

            foreach (Order order in orders)
            {
                Order_Detail newOrderDetail = getOrderDetail(order);
                for (int i = 0; i < modelStatus.Count; i++)
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
            Order order = orderDb.Get(id);
            Employee employee = employeeDb.Get(order.EmployeeId);
            Order_Detail detail = getOrderDetail(order, employee.Name);
            IEnumerable<PartsList_Detail> partsListDetails = getPartListsDetails(id);

            Order_Detail_Parts model = new Order_Detail_Parts { Details = detail, partsLists = partsListDetails, EmployeePayPerHour =  employee.PayPerHour};

            return View(model);
        }


        // GET: Order/Create
        public ActionResult Create()
        {
            Order_Edit model = getOrderEdit(new Order());

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
                Order_Edit model = getOrderEdit(order);

                return View(model);
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            Order order = orderDb.Get(id);
            Order_Edit model = getOrderEdit(order);
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
                Order_Edit model = getOrderEdit(order);
                return View(model);
            }
        }


        // GET: Order/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Order_Detail model = getOrderDetail(orderDb.Get(id));
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


        public ActionResult DetailsPartList(int id, int partId)
        {
            PartsList partsList = partsListDb.Get(id, partId);
            PartsList_Detail model = getPartListDetail(partsList);
            return View(model);
        }

        [HttpGet]
        public ActionResult EditPartList(int id, int partId)
        {
            PartsList model = partsListDb.Get(id, partId);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditPartList(int id, PartsList partsList)
        {
            try
            {
                partsListDb.Edit(partsList);
                return RedirectToAction("Details/" + id);
            }
            catch
            {
                return View(partsList);
            }
        }

        [HttpGet]
        public ActionResult CreatePart(int id)
        {
            IEnumerable<Part> parts = partDb.GetAll();
            PartsList_Create model = new PartsList_Create { OrderId = id, Parts = parts, WorkingOn = new PartsList { PartId = parts.FirstOrDefault().Id } };
            return View(model);
        }
        [HttpPost]
        public ActionResult CreatePart(int id, PartsList_Create partsList)
        {
            try
            {
                partsList.WorkingOn.OrderId = id;
                partsListDb.Create(partsList.WorkingOn);
                return RedirectToAction("Details/" + id);
            }
            catch
            {
                partsList.Parts = partDb.GetAll();
                return View(partsList);
            }
        }

        [HttpGet]
        public ActionResult DeletePartList(int id, int partId){
            PartsList partsList = partsListDb.Get(id, partId);
            PartsList_Detail model = getPartListDetail(partsList);
            return View(model);
        }
        //[HttpPost]
        public ActionResult DeletePartList(int id, int partId, PartsList partsList)
        {
            try
            {
                partsListDb.Delete(partsListDb.Get(id, partId));
                return RedirectToAction("Details/" + id);
            }
            catch
            {
                return DeletePartList(id, partId);
            }
        }

        private Order_Detail getOrderDetail(Order order)
        {
            string employeeName = employeeDb.Get(order.EmployeeId).Name;
            return getOrderDetail(order, employeeName);
        }
        private Order_Detail getOrderDetail(Order order, string employeeName)
        {
            Status status = statusDb.Get(order.StatusId);
            string customerName = customerDb.Get(order.CustomerId).Name;
            return new Order_Detail { Id = order.Id, EmployeeName = employeeName, CustomerName = customerName, StartDate = order.StartDate, EndDate = order.EndDate.GetValueOrDefault(), Description = order.Description, Status = status.StatusDescription, StatusColour = status.StatusColour, HoursWorked = order.HoursWorked };
        }

        private List<PartsList_Detail> getPartListsDetails(int id)
        {
            IEnumerable<PartsList> partsLists = partsListDb.Get(id);
            List<PartsList_Detail> partsListDetails = new List<PartsList_Detail>();
            foreach (PartsList partsList in partsLists)
            {
                PartsList_Detail newDetail = getPartListDetail(partsList);
                partsListDetails.Add(newDetail);
            }
            return partsListDetails;
        }

        private PartsList_Detail getPartListDetail(PartsList partsList)
        {
            Part part = partDb.Get(partsList.PartId);
            PartsList_Detail newDetail = new PartsList_Detail { OrderId = partsList.OrderId, PartId = partsList.PartId, Name = part.Name, Amount = partsList.Amount, Price = part.Price };
            return newDetail;
        }

        private Order_Edit getOrderEdit(Order order)
        {
            return new Order_Edit { Order = order, Customers = customerDb.GetAll(), Employees = employeeDb.GetAll(), Statuses = statusDb.GetAll() };
        }
    }
}
