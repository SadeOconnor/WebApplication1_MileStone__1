using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using WebApplication1_MileStone__1.Models;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext()
        : base(@"Server=(localdb)\mssqllocaldb;Database=UserRegDB;Trusted_Connection=True;")
    {
    }

    public static ApplicationDbContext Create()
    {
        return new ApplicationDbContext();
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

    public void SeedRoles()
    {
        var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this));
        var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this));

        // Define only Admin and Customer roles
        string[] roleNames = { "Admin", "Customer" };

        // Create roles if they don't exist
        foreach (var roleName in roleNames)
        {
            if (!roleManager.RoleExists(roleName))
            {
                var role = new IdentityRole(roleName);
                roleManager.Create(role);
            }
        }

        // Set admin username
        var adminUsername = "SadeAdmin"; // Updated to new admin username
        var adminUser = userManager.FindByName(adminUsername);

        if (adminUser == null)
        {
            // Create admin user if it doesn't exist
            var user = new ApplicationUser { UserName = adminUsername, FirstName = "Sade", LastName = "Admin" };

            // Create admin user with hashed password
            var result = userManager.Create(user, "Password123#");

            if (result.Succeeded)
            {
                // Assign the "Admin" role to the admin user
                userManager.AddToRole(user.Id, "Admin");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine("Error: " + error);
                }
            }
        }

        // Ensure that other users are assigned the "Customer" role
        // (Example logic for handling a customer user would be done elsewhere in the registration process)
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}