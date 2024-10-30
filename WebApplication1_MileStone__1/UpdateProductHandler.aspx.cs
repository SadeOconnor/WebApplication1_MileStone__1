using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration; // ConfigurationManager
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1_MileStone__1
{
    public partial class UpdateProductHandler : Page  // Ensure it inherits Page here
    {
        string connectionString = @"Data Source=DESKTOP-SLFAM2F\SQLEXPRESS;Initial Catalog=UserRegDB;Integrated Security=True;Encrypt=False";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Only execute if the page is posted back
            if (IsPostBack)
            {
                // Ensure all necessary fields are retrieved from the Request.Form
                string oldName = Request.Form["oldName"]; 
                string name = Request.Form["name"];
                string description = Request.Form["description"];
                decimal price;

                // Validate price input
                if (!decimal.TryParse(Request.Form["price"], out price))
                {
                    lblMessage.Text = "Invalid price format. Please enter a valid number.";
                    return;
                }

                string category = Request.Form["category"];

                // Call the update method with all necessary parameters
                UpdateProductDetails(oldName, name, description, price, category); // Ensure all parameters are passed
            }
        }

        protected void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            string productName = txtOldProductName.Text; // Get the product name from the textbox

            // Call the delete method with the product name
            DeleteProduct(productName);
        }

        private void DeleteProduct(string productName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM ProductTable WHERE Name = @Name"; // SQL DELETE command
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Name", productName); // Pass the product name parameter

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    lblDeleteMessage.Text = "Product deleted successfully!";
                }
                else
                {
                    lblDeleteMessage.Text = "Product not found.";
                }
            }
        }

        protected void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            // Ensure old name is obtained correctly
            string oldName = txtOldProductName.Text;  // Get the old product name from the textbox
            string name = txtProductName.Text;
            string description = txtDescription.Text;
            decimal price;

            // Validate the price input
            if (!decimal.TryParse(txtPrice.Text, out price))
            {
                lblMessage.Text = "Invalid price format. Please enter a valid number.";
                return;
            }

            string category = txtCategory.Text;

            // Call the update method with all necessary parameters
            UpdateProductDetails(oldName, name, description, price, category); // Ensure all parameters are passed
            lblMessage.Text = "Product updated successfully!";
        }

        private void UpdateProductDetails(string oldName, string name, string description, decimal price, string category)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE ProductTable SET Name = @Name, Description = @Description, Price = @Price, Category = @Category WHERE Name = @OldName";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@OldName", oldName);  // Old product name to find which row to update
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@Price", price);
                command.Parameters.AddWithValue("@Category", category);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}