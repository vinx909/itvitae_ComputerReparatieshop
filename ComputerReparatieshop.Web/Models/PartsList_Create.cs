using ComputerReparatieshop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerReparatieshop.Web.Models
{
    public class PartsList_Create
    {
        public int OrderId { get; set; }
        public IEnumerable<Part> Parts { get; set; }
        public PartsList WorkingOn { get; set; }
    }
}