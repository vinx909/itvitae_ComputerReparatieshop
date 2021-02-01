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
        public int EmployeeId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        public int StatusId { get; set; }
        public string Discription { get; set; }
        [Required]
        public bool ToDo { get; set; }
    }
}
