using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Linq;
using WebApplication1_MileStone__1.Models;

namespace WebApplication1_MileStone__1
{
    public partial class checkout : Page
    {
        string connectionString = @"Data Source=DESKTOP-SLFAM2F\SQLEXPRESS;Initial Catalog=UserRegDB;Integrated Security=True;Encrypt=False";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                User user = (User)Session["User"];
                if (user == null || user.ShoppingCart == null || user.ShoppingCart.Products.Count == 0)
                {
                    orderSummary.InnerHtml = "<p>Your cart is empty. Please add items before proceeding to checkout.</p>";
                    btnPlaceOrder.Enabled = false; // Disable the button if cart is empty
                }
                else
                {
                    DisplayOrderSummary();
                }
            }
        }

        private void DisplayOrderSummary()
        {
            User user = (User)Session["User"];
            ShoppingCart cart = user?.ShoppingCart;

            if (cart != null)
            {
                // Debugging output to check the cart state
                System.Diagnostics.Debug.WriteLine($"Cart Products Count: {cart.Products.Count}");
                foreach (var item in cart.Products)
                {
                    System.Diagnostics.Debug.WriteLine($"Product: {item.Name}, Quantity: {item.Quantity}, Subtotal: {item.Subtotal}");
                }
            }

            if (cart != null && cart.Products.Count > 0)
            {
                decimal grandTotal = cart.Products.Sum(item => item.Subtotal);
                orderSummary.InnerHtml = $"<p>Grand Total: ${grandTotal:F2}</p>";
            }
            else
            {
                orderSummary.InnerHtml = "<p>Your cart is empty.</p>";
                btnPlaceOrder.Enabled = false; // Disable order button if the cart is empty
            }
        }

     
    }
}