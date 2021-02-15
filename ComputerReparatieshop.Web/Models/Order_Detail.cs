using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerReparatieshop.Web.Models
{
    public class Order_Detail
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string CustomerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string StatusColour { get; set; }
        public string Description { get; set; }
        public decimal HoursWorked { get; set; }
        //public bool ToDo { get; set; }
    }
}