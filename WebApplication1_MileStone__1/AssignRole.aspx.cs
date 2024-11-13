using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI;

namespace WebApplication1_MileStone__1
{
    public partial class AssignRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Only run the role assignment on the first page load to avoid multiple assignments on refresh
            if (!IsPostBack)
            {
                AssignRoleToUser("sadeoconnor", "Admin"); // Replace with the target user's username
            }
        }

        protected void btnAssignRole_Click(object sender, EventArgs e)
        {
            AssignRoleToUser("sadeoconnor", "Admin"); // Replace with the user's username
        }

        protected void btnSetPassword_Click(object sender, EventArgs e)
        {
            // Call the method with a specific username and the new password
            SetPasswordForUser("sadeoconnor126", "Password123#");
        }

        private void AssignRoleToUser(string username, string roleName)
        {
            using (var context = new ApplicationDbContext()) // Ensure you have this context or create it
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var user = userManager.FindByName(username); // Look up the user by username

                if (user != null)
                {
                    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                    // Check if the role exists, if not, create it
                    if (!roleManager.RoleExists(roleName))
                    {
                        var role = new IdentityRole(roleName);
                        roleManager.Create(role); // Create the role if it doesn't exist
                    }

                    var roleToAssign = roleManager.FindByName(roleName); // Get the role to assign

                    if (roleToAssign != null)
                    {
                        if (!userManager.IsInRole(user.Id, roleToAssign.Name)) // Check if the user is already in the role
                        {
                            userManager.AddToRole(user.Id, roleToAssign.Name); // Assign role to user
                            Response.Write($"User '{username}' has been successfully assigned to the '{roleName}' role.");
                        }
                        else
                        {
                            Response.Write($"User '{username}' is already in the '{roleName}' role.");
                        }
                    }
                    else
                    {
                        Response.Write($"Role '{roleName}' does not exist.");
                    }
                }
                else
                {
                    Response.Write($"User with username '{username}' was not found.");
                }
            }
        }
        private void SetPasswordForUser(string username, string newPassword)
        {
            using (var context = new ApplicationDbContext())
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var user = userManager.FindByName(username); // Find the user by username

                if (user != null)
                {
                    // Set the new password (the user must be found)
                    var token = userManager.GeneratePasswordResetToken(user.Id); // Generate a reset token
                    var result = userManager.ResetPassword(user.Id, token, newPassword); // Reset the password

                    if (result.Succeeded)
                    {
                        Response.Write($"Password for user '{username}' has been successfully set.");
                    }
                    else
                    {
                        // Output error if password reset fails
                        Response.Write($"Error setting password for user '{username}': {string.Join(", ", result.Errors)}");
                    }
                }
                else
                {
                    Response.Write($"User '{username}' was not found.");
                }
            }
        }
    }


}