using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1_MileStone__1.Models
{
    public class Cart
    {
        public List<Product> Products { get; set; }

        public Cart()
        {
            Products = new List<Product>();
        }

        public decimal GrandTotal
        {
            get { return Products.Sum(p => p.Subtotal); }
        }

        public void AddProduct(Product product)
        {
            var existingProduct = Products.FirstOrDefault(p => p.Name == product.Name);
            if (existingProduct != null)
            {
                existingProduct.Quantity += product.Quantity;
            }
            else
            {
                Products.Add(product);
            }
        }

        public void RemoveProduct(string productName)
        {
            var product = Products.FirstOrDefault(p => p.Name == productName);
            if (product != null)
            {
                Products.Remove(product);
            }
        }
    }
}