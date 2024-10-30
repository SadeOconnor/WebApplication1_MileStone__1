using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1_MileStone__1.Models;

namespace WebApplication1_MileStone__1
{
    public partial class Products : Page
    {
        string connectionString = @"Data Source=DESKTOP-SLFAM2F\SQLEXPRESS;Initial Catalog=UserRegDB;Integrated Security=True;Encrypt=False";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts();
            }
        }

        private void LoadProducts()
        {
            // Clear existing controls to prevent duplication
            productListContainer.Controls.Clear();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM ProductTable", con);
                con.Open();

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Panel productPanel = new Panel();
                        productPanel.CssClass = "product-item";

                        Image productImage = new Image();
                        productImage.ImageUrl = rdr["ImagePath"].ToString();
                        productImage.CssClass = "product-image";

                        Panel detailsPanel = new Panel();

                        Literal productDetails = new Literal();
                        productDetails.Text = $@"
                    <h3 class='product-title'>{rdr["Name"]}</h3>
                    <p class='product-info'><strong>ID:</strong> {rdr["ProductID"]}</p>
                    <p class='product-info'><strong>Description:</strong> {rdr["Description"]}</p>
                    <p class='product-info'><strong>Category:</strong> {rdr["Category"]}</p>
                    <p class='price-tag'><strong>Price:</strong> ${rdr["Price"]}</p>";

                        TextBox quantityBox = new TextBox();
                        quantityBox.ID = $"quantity_{rdr["ProductID"]}";
                        quantityBox.TextMode = TextBoxMode.Number;
                        quantityBox.Text = "1";
                        quantityBox.Attributes["min"] = "1";
                        quantityBox.Style["width"] = "50px";

                        Button addToCartButton = new Button();
                        addToCartButton.Text = "Add to Cart";
                        addToCartButton.CommandName = "AddToCart";
                        addToCartButton.CommandArgument = $"{rdr["Name"]},{rdr["Price"]},{rdr["ProductID"]}";
                        addToCartButton.Click += AddToCartButton_Click;

                        productPanel.Controls.Add(productImage);
                        detailsPanel.Controls.Add(productDetails);
                        detailsPanel.Controls.Add(new LiteralControl("<br />"));
                        detailsPanel.Controls.Add(new LiteralControl("<label>Quantity: </label>"));
                        detailsPanel.Controls.Add(quantityBox);
                        detailsPanel.Controls.Add(new LiteralControl("<br />"));
                        detailsPanel.Controls.Add(addToCartButton);
                        productPanel.Controls.Add(detailsPanel);

                        productListContainer.Controls.Add(productPanel);
                    }
                }
            }
        }

        protected void AddToCartButton_Click(object sender, EventArgs e)
        {
            // Check if the user is logged in
            if (Session["UserID"] == null)
            {
                // User is not logged in, redirect to the login page
                Response.Redirect("~/Login.aspx");
                return; // Exit the method
            }

            Button btn = (Button)sender;
            string[] args = btn.CommandArgument.Split(',');
            string productName = args[0];
            decimal price = decimal.Parse(args[1]);
            int productId = int.Parse(args[2]);

            // Find the quantity textbox
            TextBox quantityBox = (TextBox)btn.Parent.FindControl($"quantity_{productId}");
            int quantity = int.Parse(quantityBox.Text);

            // Create a new product
            Product product = new Product(productName, price, "Description", "Category", quantity, "defaultImagePath.jpg");

            // Get the user from session
            User user = Session["User"] as User;
            if (user == null)
            {
                user = new User("Guest");
                Session["User"] = user;
            }

            // Add the product to the cart
            user.ShoppingCart.AddProduct(product);

            // Update session
            Session["User"] = user;

            // Show confirmation using ScriptManager
            ScriptManager.RegisterStartupScript(this, GetType(), "alert",
                "alert('Product added to cart');", true);
        }
    }
}