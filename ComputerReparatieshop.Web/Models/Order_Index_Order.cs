using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerReparatieshop.Web.Models
{
    public class Order_Index_Order
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string CustomerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StatusId { get; set; }
        public string Discription { get; set; }
    }
}