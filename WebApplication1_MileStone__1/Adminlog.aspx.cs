using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1_MileStone__1
{
    public partial class Adminlog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        // Event handler for Manage Products button click
        protected void btnManageProducts_Click(object sender, EventArgs e)
        {
            // Redirect to ManageProducts.aspx
            Response.Redirect("ManageProducts.aspx");
        }

        // Event handler for Manage Users button click
        protected void btnManageUsers_Click(object sender, EventArgs e)
        {
            // Redirect to ManageUsers.aspx
            Response.Redirect("ManageUsers.aspx");
        }
    }
}