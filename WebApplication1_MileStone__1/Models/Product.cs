using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1_MileStone__1.Models
{
    public class Product
    {
        public int ProductID { get; set; }  // Unique identifier for the product
        public string Name { get; set; }     // Name of the product
        public decimal Price { get; set; }   // Price of the product
        public string Description { get; set; } // Description of the product
        public string Category { get; set; } // Category of the product
        public int Quantity { get; set; }     // Quantity of the product in the cart
        public string ImagePath { get; set; }

        /// <summary>
        /// Calculates the subtotal for the product based on the price and quantity.
        /// </summary>
        public decimal Subtotal
        {
            get { return Price * Quantity; }
        }

        /// <summary>
        /// Constructor to initialize a new instance of the Product class.
        /// </summary>
        /// <param name="name">The name of the product.</param>
        /// <param name="price">The price of the product.</param>
        /// <param name="description">The description of the product.</param>
        /// <param name="category">The category of the product.</param>
        /// <param name="quantity">The quantity of the product.</param>
        /// <param name="ImagePath">The quantity of the product.</param>
        public Product(string name, decimal price, string description, string category, int quantity, string imagePath)
        {
            Name = name;
            Price = price;
            Description = description;
            Category = category;
            Quantity = quantity;
            ImagePath = imagePath;
        }
    }
}