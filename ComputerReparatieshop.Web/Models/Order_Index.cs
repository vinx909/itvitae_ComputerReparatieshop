using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerReparatieshop.Web.Models
{
    public class Order_Index
    {
        public IEnumerable<Order_Index_Status> AmountPerStatuses { get; set; }
        public IEnumerable<Order_Detail> orders { get; set; }
    }
}