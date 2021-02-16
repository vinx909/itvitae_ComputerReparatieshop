using System.ComponentModel.DataAnnotations;

namespace ComputerReparatieshop.Web.Models
{
    public class Order_Index_Status
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Status { get; set; }
        public int Amount { get; set; }
        [MaxLength(7)]
        public string StatusColour { get; set; }
    }
}