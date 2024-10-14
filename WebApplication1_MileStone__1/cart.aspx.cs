using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1_MileStone__1.Models;

namespace WebApplication1_MileStone__1
{
    public partial class cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayCart();
            }
        }

        private void DisplayCart()
        {
            // Get the user from session
            User user = (User)Session["User"];

            if (user != null && user.ShoppingCart.Products.Count > 0)
            {
                cartItems.InnerHtml = ""; // Clear previous cart items
                decimal grandTotal = 0;

                foreach (var product in user.ShoppingCart.Products)
                {
                    cartItems.InnerHtml += $@"
                <li>
                    <span>{product.Name}</span> |
                    <span>Quantity: {product.Quantity}</span> |
                    <span>Subtotal: ${product.Subtotal.ToString("F2")}</span>
                    <button onclick='removeProduct(\"{ product.Name}\")'>Remove</button>
                        </ li > ";


            grandTotal += product.Subtotal;
                }

                grandTotalLabel.InnerText = $"Grand Total: ${grandTotal.ToString("F2")}";
            }
            else
            {
                cartItems.InnerHtml = "<p>Your cart is empty.</p>";
                grandTotalLabel.InnerText = "";
            }
        }

        protected void RemoveProduct(string productName)
        {
            User user = (User)Session["User"];
            if (user != null)
            {
                user.ShoppingCart.RemoveProduct(productName);
                Session["User"] = user; // Update session
                DisplayCart(); // Refresh the cart display
            }
        }
    }
}