using System;
using System.Web.Http;
using Evanto.Web.AuthorizationServer;
using Evanto.Web.AuthorizationServer.Configurations;
using Evanto.Web.AuthorizationServer.Formats;
using Evanto.Web.AuthorizationServer.Providers;
using log4net.Config;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
[assembly: XmlConfigurator(Watch = true)]
namespace Evanto.Web.AuthorizationServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new EvantoServiceHttpConfiguration();

            #region Owin Middleware configurations
            app.ConfigureOAuth();

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            app.UseWebApi(config);


            #endregion

            #region Log4net configurations

            XmlConfigurator.Configure();

            #endregion
        }
    }
}