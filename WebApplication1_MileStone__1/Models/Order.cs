using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1_MileStone__1.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string Username { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
        public DateTime DateTime { get; set; }
    }
}