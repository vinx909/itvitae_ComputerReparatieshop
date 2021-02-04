using System.ComponentModel.DataAnnotations;

namespace ComputerReparatieshop.Data.Models
{
    public class Part
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
