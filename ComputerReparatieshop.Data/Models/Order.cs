using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerReparatieshop.Data.Models
{
    public class Order
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        [Required]
        public int StatusId { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{1,16}([.,][0-9]{1,3})?$")]
        [Range(0, 9999999999999999.99)]
        public Decimal HoursWorked { get; set; }
        [Required]
        public bool ToDo { get; set; }
    }
}
