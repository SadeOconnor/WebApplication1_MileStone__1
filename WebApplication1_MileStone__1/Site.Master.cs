using System;
using System.Collections.Generic;
using System.Data.SqlClient; // Add this using directive for SQL operations
using System.Web;
using System.Web.UI;
using WebApplication1_MileStone__1.Models;


namespace WebApplication1_MileStone__1
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private ShoppingCart GetShoppingCartForUser(string userId)
        {
            // You can implement logic to fetch the user's cart from session or create a new cart
            // Example: Fetch from session if stored, else return a new ShoppingCart

            // Here we'll assume the cart is stored in session
            return Session["ShoppingCart"] as ShoppingCart ?? new ShoppingCart();
        }

        // method to handle logout
        protected void Logout_Click(object sender, EventArgs e)
        {
            string userId = Session["UserID"]?.ToString(); // Assuming UserID is stored in session

            if (!string.IsNullOrEmpty(userId))
            {
                var cartRepository = new CartRepository();
                var cart = GetShoppingCartForUser(userId); // Implement this method
                cartRepository.SaveCartToDatabase(userId, cart);
            }

            // Clear the user session
            Session.Clear();

            // Redirect to login page
            Response.Redirect("~/Login.aspx");
        }


        // Method to save cart details
        private void SaveCartToDatabase(User user)
        {
            if (user != null && user.ShoppingCart != null && user.ShoppingCart.Products.Count > 0)
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    foreach (var product in user.ShoppingCart.Products)
                    {
                        string query = "INSERT INTO CartItems (UserID, ProductName, Quantity, Subtotal, DateAdded) VALUES (@UserID, @ProductName, @Quantity, @Subtotal, @DateAdded)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@UserID", user.UserID); // UserID property from User class
                            command.Parameters.AddWithValue("@ProductName", product.Name); // Assuming Product has a Name property
                            command.Parameters.AddWithValue("@Quantity", product.Quantity);
                            command.Parameters.AddWithValue("@Subtotal", product.Subtotal); // Assuming you have Subtotal property in Product
                            command.Parameters.AddWithValue("@DateAdded", DateTime.Now);

                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}
    

      