using System.ComponentModel.DataAnnotations;

namespace ComputerReparatieshop.Domain.Models
{
    public class Image
    {
        [Required]
        public int Id { get; set; }
        //byte[]
        [Required]
        public string ImagePath { get; set; }
        [Required]
        public int OrderId { get; set; }
    }
}
