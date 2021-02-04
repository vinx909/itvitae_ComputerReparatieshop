using System.ComponentModel.DataAnnotations;

namespace ComputerReparatieshop.Data.Models
{
    public class PartsList
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int PartId { get; set; }
    }
}
