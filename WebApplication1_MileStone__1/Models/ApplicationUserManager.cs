using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using WebApplication1_MileStone__1.Models; // Ensure you have this namespace

public class ApplicationUserManager : UserManager<ApplicationUser>
{
    public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
    {
    }

    // Create the ApplicationUserManager instance with custom logic
    public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
    {
        var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));

        // Additional configuration, such as password policies
        manager.UserValidator = new UserValidator<ApplicationUser>(manager)
        {
            AllowOnlyAlphanumericUserNames = false, // Allows non-alphanumeric characters in usernames
            RequireUniqueEmail = true  // Require unique email addresses
        };

        manager.PasswordValidator = new PasswordValidator
        {
            RequiredLength = 6, // Password length requirement
            RequireDigit = true, // Require at least one digit
            RequireLowercase = true, // Require at least one lowercase letter
            RequireUppercase = true, // Require at least one uppercase letter
            RequireNonLetterOrDigit = true // Require at least one non-alphabetic character
        };

        return manager;
    }
}