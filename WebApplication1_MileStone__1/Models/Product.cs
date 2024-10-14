using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1_MileStone__1.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; } // Quantity of the product in the cart
        public decimal Subtotal
        {
            get { return Price * Quantity; }
        }

        public Product(string name, decimal price, string description, string category, int quantity)
        {
            Name = name;
            Price = price;
            Description = description;
            Category = category;
            Quantity = quantity;
        }
    }
}