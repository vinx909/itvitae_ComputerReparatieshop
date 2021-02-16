using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComputerReparatieshop.Web.Models
{
    public class Employee_Returner
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [RegularExpression(@"^[0-9]{1,16}([.,][0-9]{1,3})?$")]
        [Range(0, 9999999999999999.99)]
        public string PayPerHour { get; set; }
    }
}