using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1_MileStone__1
{
    public partial class ViewOrderHistory : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //authentication check, customize based on your auth setup
            if (Session["UserID"] == null)
            {
                // Redirect to login if user is not logged in
                Response.Redirect("Login.aspx");
            }
        }
    }

}