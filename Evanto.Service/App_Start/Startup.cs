using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;
using Evanto.Service;
using Evanto.Service.Configurations;
using Evanto.Service.Filters;
using Evanto.Service.Handlers;
using Evanto.Service.Services;
using log4net.Config;
using Microsoft.Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using Microsoft.Owin.Cors;
using Microsoft.AspNet.SignalR;
using Evanto.Service.Providers;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Evanto.BL.Operations.Client;
using System;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Evanto.BL;
using System.Linq;
using Swashbuckle.Application;

[assembly: OwinStartup(typeof(Startup))]
[assembly: XmlConfigurator(Watch = true)]
namespace Evanto.Service
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new EvantoServiceHttpConfiguration();


            #region Owin Middleware configurations

            app.ConfigureOAuth();

            #region SignalR
            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                //map.UseOAuthBearerAuthentication(new Microsoft.Owin.Security.OAuth.OAuthBearerAuthenticationOptions()
                //{
                //    Provider = new QueryStringOAuthBearerProvider()
                //});
                var hubConfiguration = new HubConfiguration
                {
                    Resolver = GlobalHost.DependencyResolver
                };

                map.RunSignalR(hubConfiguration);
            });

            config.EnableSwagger(x => x.SingleApiVersion("v1", "Evanto")).EnableSwaggerUi();

            #endregion
            app.UseWebApi(config);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            #endregion


            #region Log4net configurations

            XmlConfigurator.Configure();

            #endregion
        }
    }
}
