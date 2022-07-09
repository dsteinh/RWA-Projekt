using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RWA_Projekt_MVC.Startup))]
namespace RWA_Projekt_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
