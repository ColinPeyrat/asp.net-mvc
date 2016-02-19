using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Security.Claims;
using System.Web.Helpers;

[assembly: OwinStartupAttribute(typeof(SondageSoiree.Startup))]
namespace SondageSoiree
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Compte/Login"),
                LogoutPath = new PathString("/Compte/Logout")
            });


            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;

        }


        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
