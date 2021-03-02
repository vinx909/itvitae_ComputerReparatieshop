using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;

namespace ComputerReparatieshop.Web.Models
{
    public class Customer_Index:AmountPerStatusModel
    {
        public IEnumerable<Customer> Customers { get; set; }

        public Customer_Index(ICustomerData customerData):base()
        {
            Customers = customerData.GetAll();
        }
    }
}