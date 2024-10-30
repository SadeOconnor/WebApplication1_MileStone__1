using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1_MileStone__1
{
    public partial class AddProduct : System.Web.UI.Page
    {
        string connectionString = @"Data Source=DESKTOP-SLFAM2F\SQLEXPRESS;Initial Catalog=UserRegDB;Integrated Security=True;Encrypt=False";


        protected void AddNewProduct_Click(object sender, EventArgs e)
        {
            string productName = txtProductName.Text.Trim();
            string productDescription = txtDescription.Text.Trim();
            string productCategory = txtCategory.Text.Trim();
            decimal productPrice;
           
            string productImage = txtImageUrl.Text.Trim();

            // Validate the input for price and quantity
            if (!decimal.TryParse(txtPrice.Text.Trim(), out productPrice) || productPrice <= 0)
            {
                lblMessage.Text = "Please enter a valid price.";
                return;
            }

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand(
                        @"INSERT INTO ProductTable (Name, Description, Category, Price, ImagePath) 
                  VALUES (@Name, @Description, @Category, @Price, @ImagePath)", sqlCon);

                    cmd.Parameters.AddWithValue("@Name", productName);
                    cmd.Parameters.AddWithValue("@Description", productDescription);
                    cmd.Parameters.AddWithValue("@Category", productCategory);
                    cmd.Parameters.AddWithValue("@Price", productPrice);
                   
                    cmd.Parameters.AddWithValue("@ImagePath", productImage);

                    cmd.ExecuteNonQuery();
                    lblMessage.Text = "Product added successfully.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "An error occurred while adding the product. Please try again.";
               
            }
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            string productName = txtProductName.Text;
            string productDescription = txtDescription.Text;
            decimal productPrice;

            // Parse the price from the textbox
            if (!decimal.TryParse(txtPrice.Text, out productPrice))
            {
                lblMessage.Text = "Invalid price.";
                return;
            }

            // Get the image URL
            string imageUrl = txtImageUrl.Text;

            // connection string
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    // Insert the product into the database
                    string query = @"INSERT INTO ProductTable (Name, Description, Price, ImagePath) 
                                     VALUES (@Name, @Description, @Price, @ImagePath)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", productName);
                        cmd.Parameters.AddWithValue("@Description", productDescription);
                        cmd.Parameters.AddWithValue("@Price", productPrice);
                        cmd.Parameters.AddWithValue("@ImagePath", imageUrl); // Use the image URL
                        cmd.ExecuteNonQuery();
                    }

                    lblMessage.Text = "Product added successfully!";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error adding product: " + ex.Message;
                }
            }
        }
    }
}

