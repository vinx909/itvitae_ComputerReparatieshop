using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerReparatieshop.Data.Models
{
    public class PartsList
    {
        [Required]
        [Key]
        [Column(Order = 1)]
        public int OrderId { get; set; }
        [Required]
        [Key]
        [Column(Order = 2)]
        public int PartId { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}
