using System.ComponentModel.DataAnnotations;

namespace ComputerReparatieshop.Web.Models
{
    public class PartsList_Detail
    {
        public int OrderId { get; set; }
        public int PartId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public int Amount { get; set; }
        [RegularExpression(@"^[0-9]{1,16}([,][0-9]{1,3})?$")]
        [Range(0, 9999999999999999.99)]
        public decimal Price { get; set; }
    }
}