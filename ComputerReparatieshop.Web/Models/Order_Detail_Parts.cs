using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerReparatieshop.Web.Models
{
    public class Order_Detail_Parts
    {
        public Order_Detail Details { get; set; }
        public IEnumerable<PartsList_Detail> partsLists { get; set; }
        public decimal EmployeePayPerHour { private get; set; }
        public decimal Price {
            get
            {
                decimal toReturn = Details.HoursWorked * EmployeePayPerHour;
                foreach(PartsList_Detail partsList in partsLists)
                {
                    toReturn += partsList.Price * partsList.Amount;
                }
                return toReturn;
            }
        }
    }
}