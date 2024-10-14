using System;
using System.Web.UI;

namespace WebApplication1_MileStone__1
{
    public partial class Products : Page  // Ensure this class extends Page
    {
        protected void AddToCart(string productName, decimal price, int quantity)
        {
            // Create a new product
            Product product = new Product(productName, price, "Description", "Category", quantity);

            // Get the user from session
            User user = (User)Session["User"];
            if (user == null)
            {
                // If user is not yet initialized, create a new one
                user = new User("Guest");
                Session["User"] = user;
            }

            // Add the product to the cart
            user.ShoppingCart.AddProduct(product);

            // Update session
            Session["User"] = user;

            // Optionally, show a confirmation
            Response.Write("<script>alert('Product added to cart');</script>");
        }
    }
}