using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Evanto.Web.Vendor.Startup))]
namespace Evanto.Web.Vendor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}