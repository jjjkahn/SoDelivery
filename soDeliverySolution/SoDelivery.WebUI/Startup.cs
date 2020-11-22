using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SoDelivery.WebUI.Startup))]
namespace SoDelivery.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
