using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SondageSoiree.Startup))]
namespace SondageSoiree
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
