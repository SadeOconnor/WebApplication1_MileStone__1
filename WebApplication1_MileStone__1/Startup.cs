using System;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApplication1_MileStone__1.Models;

[assembly: OwinStartup(typeof(WebApplication1_MileStone__1.Startup))]  // This should match the class name

namespace WebApplication1_MileStone__1
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Enable Cross-Origin Request Sharing (CORS) if needed
            app.UseCors(CorsOptions.AllowAll);

            // Configure the cookie authentication middleware
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")  // Redirect to login page if not logged in
            });

            // Configure OWIN to create instances of ApplicationDbContext and ApplicationUserManager
            app.CreatePerOwinContext<ApplicationDbContext>(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
        }
    }
}