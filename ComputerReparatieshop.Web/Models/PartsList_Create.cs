using ComputerReparatieshop.Domain.Models;
using System.Collections.Generic;

namespace ComputerReparatieshop.Web.Models
{
    public class PartsList_Create
    {
        public int OrderId { get; set; }
        public IEnumerable<Part> Parts { get; set; }
        public PartsList WorkingOn { get; set; }
    }
}