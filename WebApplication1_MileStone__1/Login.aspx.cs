using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using WebApplication1_MileStone__1.Models;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication1_MileStone__1
{
    public partial class Login : Page
    {
        string connectionString = @"Data Source=DESKTOP-SLFAM2F\SQLEXPRESS;Initial Catalog=UserRegDB;Integrated Security=True;Encrypt=False";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Clear();
            }
        }

        // Method to hash passwords
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                // Convert the input string to a byte array and compute the hash
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert the byte array to a string
                var builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2")); // Convert each byte to hex format
                }
                return builder.ToString();
            }
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            string hashOfInput = HashPassword(password);
            return hashOfInput.Equals(storedHash, StringComparison.OrdinalIgnoreCase);
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Check if we are logging in or registering
            if (IsLoginAttempt())
            {
                LoginUser();
            }
            else
            {
                RegisterUser();
            }
        }

        private void LoginUser()
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SELECT UserID, Password FROM Users WHERE Username=@Username", sqlCon);
                sqlCmd.Parameters.AddWithValue("@Username", username);

                SqlDataReader reader = sqlCmd.ExecuteReader();
                if (reader.Read())
                {
                    string storedHashedPassword = reader["Password"].ToString();

                    // Verify the password
                    if (VerifyPassword(password, storedHashedPassword))
                    {
                        int userId = Convert.ToInt32(reader["UserID"]);
                        Session["User"] = new User { Username = username, UserID = userId, ShoppingCart = new ShoppingCart() };
                        Response.Redirect("Products.aspx");
                    }
                    else
                    {
                        lblErrorMessage.Text = "Invalid username or password.";
                    }
                }
                else
                {
                    lblErrorMessage.Text = "Invalid username or password.";
                }
            }
        }

        private bool IsUsernameAvailable(string username, SqlConnection sqlCon)
        {
            SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username = @Username", sqlCon);
            checkCmd.Parameters.AddWithValue("@Username", username);
            int count = (int)checkCmd.ExecuteScalar();
            return count == 0;
        }

        private void RegisterUser()
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                lblErrorMessage.Text = "Please Fill Mandatory Fields";
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                lblErrorMessage.Text = "Passwords do not match";
                return;
            }

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                // Check if username is available
                if (!IsUsernameAvailable(txtUsername.Text.Trim(), sqlCon))
                {
                    lblErrorMessage.Text = "Username already exists. Please choose a different username.";
                    return;
                }

                try
                {
                    SqlCommand sqlCmd = new SqlCommand("UserAddOrEdit", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(hfUserID.Value == "" ? "0" : hfUserID.Value));
                    sqlCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Contact", txtContact.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
                    sqlCmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Password", HashPassword(txtPassword.Text.Trim()));
                    sqlCmd.ExecuteNonQuery();

                    // Get the newly created UserID
                    SqlCommand getUserIdCmd = new SqlCommand("SELECT UserID FROM Users WHERE Username = @Username", sqlCon);
                    getUserIdCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    int userId = Convert.ToInt32(getUserIdCmd.ExecuteScalar());

                    // Store user in session
                    Session["User"] = new User
                    {
                        Username = txtUsername.Text,
                        UserID = userId,
                        ShoppingCart = new ShoppingCart()
                    };

                    Clear();
                    lblSuccessMessage.Text = "Registration Successful!";
                    Response.Redirect("Products.aspx");
                }
                catch
                {
                    lblErrorMessage.Text = "An error occurred during registration. Please try again.";
                    // You might want to log the exception details somewhere
                }
            }
        }
      

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }

        protected void Logout()
        {
            // Get the user from the session
            User user = (User)Session["User"];

            if (user != null)
            {
                // Save the cart details in the database
                SaveCartToDatabase(user.ShoppingCart);
            }

            // Clear the session
            Session.Clear();
            Response.Redirect("Login.aspx"); // Redirect to the login page
        }

        private void SaveCartToDatabase(ShoppingCart cart)
        {
            // Make sure to save the cart only if the user is logged in
            User user = (User)Session["User"];
            if (user == null || cart == null || cart.Products.Count == 0)
            {
                return; // No user or no items to save
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                foreach (var item in cart.Products)
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO ShoppingCart (UserID, ProductID, Quantity) VALUES (@UserID, @ProductID, @Quantity)", con);
                        cmd.Parameters.AddWithValue("@UserID", user.UserID); // Assuming UserID is a property of the User class
                        cmd.Parameters.AddWithValue("@ProductID", item.ProductID);
                        cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Log the error or handle it appropriately
                        Response.Write("<script>alert('Error saving cart: " + ex.Message + "');</script>");
                    }
                }
            }
        }

        void Clear()
        {
            txtFirstName.Text = txtLastName.Text = txtContact.Text = txtAddress.Text = txtUsername.Text = txtPassword.Text = txtConfirmPassword.Text = "";
            hfUserID.Value = "";
            lblSuccessMessage.Text = lblErrorMessage.Text = "";
        }

        private bool IsLoginAttempt()
        {
            // Consider it a registration if any registration-specific fields are filled
            bool hasRegistrationFields = !string.IsNullOrEmpty(txtFirstName.Text) ||
                                       !string.IsNullOrEmpty(txtLastName.Text) ||
                                       !string.IsNullOrEmpty(txtContact.Text) ||
                                       !string.IsNullOrEmpty(txtAddress.Text) ||
                                       !string.IsNullOrEmpty(txtConfirmPassword.Text);

            return !hasRegistrationFields;
        }
    }
}