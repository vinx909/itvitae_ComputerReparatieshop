using System;
using System.ComponentModel.DataAnnotations;

namespace ComputerReparatieshop.Domain.Models
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{1,16}([,][0-9]{1,3})?$")]
        [Range(0, 9999999999999999.99)]
        public Decimal PayPerHour { get; set; }
    }
}
