using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication1_MileStone__1.Models
{
    public class RoleInitializer
    {
        // This method will check and create roles if they don't exist
        public static void InitializeRoles(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // Create "Admin" role if it does not exist
            if (!roleManager.RoleExists("Admin"))
            {
                var adminRole = new IdentityRole("Admin");
                roleManager.Create(adminRole);
            }

            // Create "Customer" role if it does not exist
            if (!roleManager.RoleExists("Customer"))
            {
                var customerRole = new IdentityRole("Customer");
                roleManager.Create(customerRole);
            }
        }
    }
}