using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;
using ComputerReparatieshop.Web.Exceptions;

namespace ComputerReparatieshop.Web.Models
{
    public class Order_Detail_Parts
    {

        public Order_Detail Details { get; set; }
        public IEnumerable<PartsList_Detail> PartsLists { get; set; }
        [RegularExpression(@"^[0-9]{1,16}([.,][0-9]{1,3})?$")]
        [Range(0, 9999999999999999.99)]
        public decimal EmployeePayPerHour { private get; set; }
        public decimal Price {
            get
            {
                decimal toReturn = Details.HoursWorked * EmployeePayPerHour;
                foreach(PartsList_Detail partsList in PartsLists)
                {
                    toReturn += partsList.Price * partsList.Amount;
                }
                return toReturn;
            }
        }
        public Order_Detail_Parts(ICustomerData customerData, IEmployeeData employeeData, IOrderData orderData, IPartData partData, IPartsListData partsListData, IStatusData statusData, int orderId)
        {
            Order order = orderData.Get(orderId);
            if (order == null)
            {
                throw new NotFoundInDatabaseException();
            }
            Employee employee = employeeData.Get(order.EmployeeId);

            Details = new Order_Detail(employee, customerData,statusData,order);
            PartsLists = new List<PartsList_Detail>();
            EmployeePayPerHour = employee.PayPerHour;

            IEnumerable<PartsList> partsLists = partsListData.Get(orderId);
            foreach (PartsList partsList in partsLists)
            {
                PartsList_Detail newDetail = new PartsList_Detail(partData, partsList);
                PartsLists = PartsLists.Concat(new[] { newDetail });
            }
        }
    }
}