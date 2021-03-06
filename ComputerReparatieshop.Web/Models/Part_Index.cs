﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;

namespace ComputerReparatieshop.Web.Models
{
    public class Part_Index : AmountPerStatusModel
    {
        public IEnumerable<Part> Parts { get; set; }

        public Part_Index(IPartData partData) : base()
        {
            Parts = partData.GetAll();
        }
    }
}