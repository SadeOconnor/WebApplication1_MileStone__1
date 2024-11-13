using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApplication1_MileStone__1.Models;

namespace WebApplication1_MileStone__1
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Ensure roles are created
            using (var context = new ApplicationDbContext())
            {
                RoleInitializer.InitializeRoles(context); // Initialize roles
            }

            // Other application startup tasks (e.g., routing, filters, etc.)
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
