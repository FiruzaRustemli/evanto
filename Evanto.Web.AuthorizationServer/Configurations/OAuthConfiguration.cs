using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evanto.Web.AuthorizationServer.Formats;
using Evanto.Web.AuthorizationServer.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace Evanto.Web.AuthorizationServer.Configurations
{
    public static  class OAuthConfiguration
    {
        /// <summary>
        /// Configures OAuth options.
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigureOAuth(this IAppBuilder app)
        {
            OAuthAuthorizationServerOptions oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth2/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(5),
                Provider = new CustomOAuthProvider(),
                AccessTokenFormat = new CustomJwtFormat(Utils.ConfigHelper.GetAppSetting("Issuer"))
                
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
        }
    }
}
