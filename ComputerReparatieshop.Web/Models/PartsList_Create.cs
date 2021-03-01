using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;
using System.Collections.Generic;
using System.Linq;

namespace ComputerReparatieshop.Web.Models
{
    public class PartsList_Create
    {
        public int OrderId { get; set; }
        public IEnumerable<Part> Parts { get; set; }
        public PartsList WorkingOn { get; set; }

        public PartsList_Create()
        {
            //required for views even with no visible references
        }
        public PartsList_Create(int orderId, IPartData partDb)
        {
            OrderId = orderId;
            Parts = partDb.GetAll();
            WorkingOn = new PartsList() { PartId = Parts.FirstOrDefault().Id };
        }
    }
}