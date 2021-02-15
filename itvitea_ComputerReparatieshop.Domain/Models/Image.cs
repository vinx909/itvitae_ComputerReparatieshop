﻿using System.ComponentModel.DataAnnotations;

namespace ComputerReparatieshop.Domain.Models
{
    public class Image
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public byte[] ImagePath { get; set; }
        [Required]
        public int OrderId { get; set; }
    }
}
