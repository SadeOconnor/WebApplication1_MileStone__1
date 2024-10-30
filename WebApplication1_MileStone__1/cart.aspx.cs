using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using WebApplication1_MileStone__1.Models;
using System.Web;
using System.Linq;

using System.Data.SqlClient;

namespace WebApplication1_MileStone__1
{
    public partial class cart : System.Web.UI.Page
    {
        string connectionString = @"Data Source=DESKTOP-SLFAM2F\SQLEXPRESS;Initial Catalog=UserRegDB;Integrated Security=True;Encrypt=False";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayCart();
            }
        }

        private void DisplayCart()
        {
            User user = Session["User"] as User;
            if (user != null && user.ShoppingCart != null && user.ShoppingCart.Products.Count > 0)
            {
                decimal grandTotal = 0;
                cartContainer.Controls.Clear(); // Clear previous content

                foreach (var product in user.ShoppingCart.Products)
                {
                    // Create a new panel for each product
                    Panel productPanel = new Panel();
                    productPanel.CssClass = "cart-item"; // Apply your custom CSS class

                    // Calculate subtotal dynamically using the calculated property
                    decimal subtotal = product.Subtotal;

                    // Add product details
                    Label productInfo = new Label();
                    productInfo.Text = $"Product: {HttpUtility.HtmlEncode(product.Name)} | Quantity: {product.Quantity} | Subtotal: ${subtotal:F2}";
                    productPanel.Controls.Add(productInfo);

                    // Create the Remove button
                    Button removeButton = new Button();
                    removeButton.Text = "Remove";
                    removeButton.CommandArgument = product.Name; // Pass product name
                    removeButton.CssClass = "remove-btn"; // Custom CSS class
                    removeButton.Click += new EventHandler(RemoveProduct_Click); // Wire the event
                    productPanel.Controls.Add(removeButton);

                    // Create the Update button
                    Button updateButton = new Button();
                    updateButton.Text = "Update";
                    updateButton.CssClass = "update-btn"; // Custom CSS class
                    updateButton.Attributes.Add("onclick", $"showUpdateModal('{HttpUtility.JavaScriptStringEncode(product.Name)}', {product.Quantity}); return false;"); // Show modal
                    productPanel.Controls.Add(updateButton);

                    // Add the product panel to the cart container
                    cartContainer.Controls.Add(productPanel);

                    // Update grand total
                    grandTotal += subtotal;
                }

                // Display grand total
                Label grandTotalLabel = new Label();
                grandTotalLabel.Text = $"Grand Total: ${grandTotal:F2}";
                grandTotalLabel.CssClass = "grand-total";
                cartContainer.Controls.Add(grandTotalLabel);
            }
            else
            {
                Literal emptyCartLiteral = new Literal();
                emptyCartLiteral.Text = "<p class='empty-cart'>Your cart is empty</p>";
                cartContainer.Controls.Add(emptyCartLiteral);
            }
        }

        protected void RemoveProduct_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string productName = btn.CommandArgument;

            User user = Session["User"] as User;
            if (user != null && user.ShoppingCart != null)
            {
                var productToRemove = user.ShoppingCart.Products.FirstOrDefault(p => p.Name == productName);
                if (productToRemove != null)
                {
                    user.ShoppingCart.Products.Remove(productToRemove);
                    Session["User"] = user; // Update the session after modification
                    DisplayCart(); // Re-display the updated cart
                }
            }
        }

        protected void btnSubmitProductUpdate_Click(object sender, EventArgs e)
        {
            // Retrieve the product name from the hidden field and the new quantity from the input
            string productName = hiddenProductName.Value;
            int newQuantity;

            if (!int.TryParse(txtNewQuantity.Text, out newQuantity) || newQuantity < 1)
            {
                lblUpdateMessage.Text = "Please enter a valid quantity.";
                return;
            }

            // Retrieve the cart from session
            User user = Session["User"] as User;
            if (user != null && user.ShoppingCart != null)
            {
                // Find the product in the shopping cart
                var productToUpdate = user.ShoppingCart.Products.FirstOrDefault(p => p.Name == productName);
                if (productToUpdate != null)
                {
                    // Update quantity
                    productToUpdate.Quantity = newQuantity;

                    // Save updated cart back to session and refresh cart display
                    Session["User"] = user;
                    DisplayCart();

                    // Display success message and close the modal
                    lblUpdateMessage.Text = "Product updated successfully.";
                    ScriptManager.RegisterStartupScript(this, GetType(), "CloseModal", "document.getElementById('updateModal').style.display='none';", true);
                }
                else
                {
                    lblUpdateMessage.Text = "Product not found in the cart.";
                }
            }
        }

        protected void PlaceOrder_Click(object sender, EventArgs e)
        {
            User user = Session["User"] as User;
            if (user == null)
            {
                lblErrorMessage.Text = "Please log in to place an order.";
                return;
            }

            ShoppingCart cart = user.ShoppingCart;
            if (cart == null || cart.Products == null || cart.Products.Count == 0)
            {
                lblErrorMessage.Text = "Your cart is empty. Please add items before placing an order.";
                return;
            }

            // Validate required fields
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtAddress.Text) ||
                string.IsNullOrEmpty(ddlPaymentMethod.SelectedValue))
            {
                lblErrorMessage.Text = "Please fill in all required fields (Name, Address, and Payment Method).";
                return;
            }

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();

                    // Start a transaction
                    using (SqlTransaction transaction = sqlCon.BeginTransaction())
                    {
                        try
                        {
                            // Insert the order
                            SqlCommand cmd = new SqlCommand(
                                @"INSERT INTO Orders (Username, Quantity, Subtotal, DateTime) 
                          VALUES (@Username, @Quantity, @Subtotal, @DateTime); 
                          SELECT SCOPE_IDENTITY();", sqlCon, transaction);

                            decimal orderTotal = cart.CalculateTotal(); // Method to returns the correct total
                            cmd.Parameters.AddWithValue("@Username", user.Username);
                            cmd.Parameters.AddWithValue("@Quantity", cart.TotalQuantity); // Method to get total quantity
                            cmd.Parameters.AddWithValue("@Subtotal", orderTotal);
                            cmd.Parameters.AddWithValue("@DateTime", DateTime.Now);

                            // Get the new order ID
                            int orderId = Convert.ToInt32(cmd.ExecuteScalar());

                            // Insert order items
                            foreach (var item in cart.Products)
                            {
                                SqlCommand itemCmd = new SqlCommand(
                                    @"INSERT INTO OrderItems (OrderID, ProductID, Quantity, Subtotal) 
                              VALUES (@OrderID, @ProductID, @Quantity, @Subtotal)", sqlCon, transaction);

                                itemCmd.Parameters.AddWithValue("@OrderID", orderId);
                                itemCmd.Parameters.AddWithValue("@ProductID", item.ProductID); 
                                itemCmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                                itemCmd.Parameters.AddWithValue("@Subtotal", item.Subtotal);
                                itemCmd.ExecuteNonQuery();
                            }

                            // Commit the transaction
                            transaction.Commit();

                            // Clear the cart from the database and session
                            ClearShoppingCart(user.UserID);
                            cart.Clear();
                            Session["User"] = user;

                            // Redirect to confirmation page
                            Response.Redirect("OrderConfirmation.aspx");
                        }
                        catch (Exception ex)
                        {
                            // Roll back the transaction if something failed
                            transaction.Rollback();
                            LogError(ex, "Transaction error during order placement");
                            lblErrorMessage.Text = "There was an error processing your transaction. Please try again.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex, "Database connection error during order placement");
                lblErrorMessage.Text = "Unable to connect to the order system. Please try again later.";
            }
        }

        private void LogError(Exception ex, string message)
        {
            // Log to system debug output
            System.Diagnostics.Debug.WriteLine($"Error: {message}");
            System.Diagnostics.Debug.WriteLine($"Exception: {ex.Message}");
            System.Diagnostics.Debug.WriteLine($"Stack Trace: {ex.StackTrace}");

            // Log to a file
            string logPath = Server.MapPath("~/App_Data/ErrorLog.txt");
            string logMessage = $"{DateTime.Now}: {message}\r\nException: {ex.Message}\r\nStack Trace: {ex.StackTrace}\r\n\r\n";

            try
            {
                System.IO.File.AppendAllText(logPath, logMessage);
            }
            catch
            {
                // debug output
            }
        }

        private void ClearShoppingCart(int userId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM ShoppingCart WHERE UserID = @UserID", con);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.ExecuteNonQuery();
            }
        }

        protected void ContinueShopping_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Products.aspx"); // Redirect to the desired page
        }

        protected void btnSubmitUpdate_Click(object sender, EventArgs e)
        {
            string productName = hiddenProductName.Value; // Retrieve product name from the hidden field
            int newQuantity;

            if (!int.TryParse(txtNewQuantity.Text, out newQuantity) || newQuantity < 1)
            {
                lblErrorMessage.Text = "Invalid quantity. Please enter a valid quantity.";
                return;
            }

            User user = Session["User"] as User;
            if (user != null && user.ShoppingCart != null)
            {
                var productToUpdate = user.ShoppingCart.Products.FirstOrDefault(p => p.Name == productName);
                if (productToUpdate != null)
                {
                    productToUpdate.Quantity = newQuantity; // Update the quantity
                                                            // Calculated dynamically
                    Session["User"] = user; // Update session
                    DisplayCart(); // Re-display the updated cart
                }
                else
                {
                    lblUpdateMessage.Text = "Product not found in the cart.";
                }
            }
        }

       
        protected void RedirectToUpdateProductPage(object sender, EventArgs e)
        {
            string productId = "1"; 
            Response.Redirect($"UpdateProductHandler.aspx?productId={productId}");
        }

        protected void btnAddNewProduct_Click(object sender, EventArgs e)
        {
            // Redirect to the AddProduct.aspx page
            Response.Redirect("AddProduct.aspx");
        }

        protected void btnGoToAddProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProduct.aspx");
        }

        protected void AddToCart(Product product)
        {
            User user = Session["User"] as User;
            if (user != null)
            {
                user.ShoppingCart.AddProduct(product);
                Session["User"] = user; // Update the session
            }
        }
    }
}