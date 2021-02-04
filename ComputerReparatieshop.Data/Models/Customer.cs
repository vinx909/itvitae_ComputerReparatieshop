using System.ComponentModel.DataAnnotations;

namespace ComputerReparatieshop.Data.Models
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Auth { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
