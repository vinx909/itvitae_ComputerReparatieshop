using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;
using System.Collections.Generic;
using System.Linq;

namespace ComputerReparatieshop.Web.Models
{
    public class OrderPart_Create
    {
        public int OrderId { get; set; }
        public IEnumerable<Part> Parts { get; set; }
        public OrderPart WorkingOn { get; set; }

        public OrderPart_Create()
        {
            //required for views even with no visible references
        }
        public OrderPart_Create(int orderId, IPartData partDb)
        {
            OrderId = orderId;
            Parts = partDb.GetAll();
            WorkingOn = new OrderPart() { PartId = Parts.FirstOrDefault().Id };
        }
    }
}