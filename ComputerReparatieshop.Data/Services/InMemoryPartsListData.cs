﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerReparatieshop.Data.Models;

namespace ComputerReparatieshop.Data.Services
{
    public class InMemoryPartsListData : IPartsListData
    {
        public PartsList Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PartsList> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}