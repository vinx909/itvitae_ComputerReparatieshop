using ComputerReparatieshop.Domain.Models;

namespace ComputerReparatieshop.Web.Models
{
    public class Order_Delete
    {
        public Order Order { get; set; }
        public Order_Detail Detail { get; set; }
    }
}