using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerReparatieshop.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StatusId { get; set; }
        public string Discription { get; set; }
    }
}
