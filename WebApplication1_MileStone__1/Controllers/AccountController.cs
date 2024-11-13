using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication1_MileStone__1.Models;

namespace WebApplication1_MileStone__1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public AccountController()
        {
            _context = new ApplicationDbContext();
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
        }

        // Registration action method (GET)
        [HttpGet]
        public ActionResult Register()
        {
            return View(); // Return the Register view
        }

        // Registration action method (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Create the user object (without email)
                var user = new ApplicationUser { UserName = model.UserName };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Assign roles based on username
                    if (model.UserName == "SadeAdmin") // Check for the Admin username
                    {
                        await _userManager.AddToRoleAsync(user.Id, "Admin");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user.Id, "Customer"); // All other users are assigned "Customer"
                    }

                    // Redirect based on the role
                    if (model.UserName == "SadeAdmin")
                    {
                        return RedirectToAction("AdminDashboard");
                    }
                    else
                    {
                        return RedirectToAction("UserDashboard");
                    }
                }

                // If the registration fails, display the errors
                AddErrors(result);
            }

            // Return to the Register view if there are validation errors
            return View(model);
        }

        // Login action method (GET)
        [HttpGet]
        public ActionResult Login()
        {
            return View(); // Return the Login view
        }

        // Login action method (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindAsync(model.UserName, model.Password);
                if (user != null)
                {
                    // Check if the user is an Admin
                    if (await _userManager.IsInRoleAsync(user.Id, "Admin"))
                    {
                        return RedirectToAction("AdminDashboard");
                    }
                    else
                    {
                        return RedirectToAction("UserDashboard");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }
            return View(model); // Return the view if login fails
        }

        // Action methods for AdminDashboard and UserDashboard
        public ActionResult AdminDashboard()
        {
            return View();  // Your admin dashboard view
        }

        public ActionResult UserDashboard()
        {
            return View();  // Your user dashboard view
        }

        // Helper method to add errors from the identity result
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}
