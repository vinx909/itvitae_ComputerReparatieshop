﻿using System.ComponentModel.DataAnnotations;

namespace ComputerReparatieshop.Data.Models
{
    public class Status
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string StatusDescription { get; set; }
        [Required]
        [MaxLength(7)]
        public string StatusColour { get; set; }
    }
}
