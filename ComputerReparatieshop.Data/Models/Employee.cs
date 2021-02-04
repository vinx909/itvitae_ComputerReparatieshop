using System.ComponentModel.DataAnnotations;

namespace ComputerReparatieshop.Data.Models
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        public double PayPerHour { get; set; }
    }
}
