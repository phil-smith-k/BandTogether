using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BandTogether.MVC.Startup))]
namespace BandTogether.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
