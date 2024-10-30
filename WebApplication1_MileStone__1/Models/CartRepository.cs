using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebApplication1_MileStone__1.Models; 

public class CartRepository
{
    private string connectionString = @"Data Source=DESKTOP-SLFAM2F\SQLEXPRESS;Initial Catalog=UserRegDB;Integrated Security=True";
    public void SaveCartToDatabase(string userId, ShoppingCart cart)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            foreach (var product in cart.Products)
            {
                var command = new SqlCommand("INSERT INTO CartItems (UserID, ProductName, Quantity, Subtotal, DateAdded) VALUES (@UserID, @ProductName, @Quantity, @Subtotal, @DateAdded)", connection);
                command.Parameters.AddWithValue("@UserID", userId);
                command.Parameters.AddWithValue("@ProductName", product.Name);
                command.Parameters.AddWithValue("@Quantity", product.Quantity);
                command.Parameters.AddWithValue("@Subtotal", product.Quantity * product.Price); // Assuming Price property exists
                command.Parameters.AddWithValue("@DateAdded", DateTime.Now);
                command.ExecuteNonQuery();
            }
        }
    }
}