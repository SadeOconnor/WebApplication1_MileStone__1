using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace WebApplication1_MileStone__1.Models
{
    public class RoleManagerHelper
    {
        public static void AssignRoleToUser(string username, string roleName, ApplicationDbContext context)
        {
            // Initialize UserManager with the given context
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // Find the user by username
            var user = userManager.FindByName(username);

            if (user != null)
            {
                // Check if the user is already in the specified role
                if (!userManager.IsInRole(user.Id, roleName))
                {
                    // If not, add the user to the role
                    var result = userManager.AddToRole(user.Id, roleName);
                    if (result.Succeeded)
                    {
                        Console.WriteLine($"User {username} has been assigned the {roleName} role.");
                    }
                    else
                    {
                        // Log any errors if the role assignment fails
                        Console.WriteLine($"Failed to assign {roleName} role to user {username}. Error: {string.Join(", ", result.Errors)}");
                    }
                }
                else
                {
                    Console.WriteLine($"User {username} is already in the {roleName} role.");
                }
            }
            else
            {
                // If the user is not found, log an error
                Console.WriteLine($"User {username} not found.");
            }
        }
    }
}