using System.Collections.Generic;
using System.Linq;

namespace WebApplication1_MileStone__1.Models
{
    public class ShoppingCart
    {
        public List<Product> Products { get; set; } = new List<Product>();

        // Other existing properties and methods...

        // Property to calculate the total quantity of items in the cart
        public int TotalQuantity
        {
            get
            {
                return Products.Sum(p => p.Quantity); // Sum the quantities of all products
            }
        }

        // Method to calculate total price
        public decimal CalculateTotal()
        {
            return Products.Sum(p => p.Subtotal); // Assuming you have Subtotal calculated for each product
        }

        public void AddProduct(Product product)
        {
            // Logic to add a product to the cart
            Products.Add(product);
        }

        public void Clear()
        {
            Products.Clear(); // Method to clear the cart
        }
    }
}