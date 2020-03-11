using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evanto.BL;
using Evanto.BL.Operations.Client;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Owin;
using Evanto.Service.Providers;

namespace Evanto.Service.Configurations
{
    public static class OAuthConfiguration
    {
        /// <summary>
        /// Configures OAuth.
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigureOAuth(this IAppBuilder app)
        {
            var issuer = Utils.ConfigHelper.GetAppSetting("Issuer");

            GetClientsOperation op = new GetClientsOperation();
            OperationResult<GetClientsOutput> opResult = op.Execute(new GetClientsInput());

            if (!opResult.IsSuccess)
            {
                throw new InvalidOperationException();
            }

            var iIssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[opResult.Output.Clients.Count];
            for (int i = 0; i < opResult.Output.Clients.Count; i++)
            {
                iIssuerSecurityTokenProviders[i] = new SymmetricKeyIssuerSecurityTokenProvider(issuer, 
                    TextEncodings.Base64Url.Decode(opResult.Output.Clients[i].OAuthClientSecret));
            }

            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = opResult.Output.Clients.Select(c => c.OAuthClientID).ToArray<string>(),
                    IssuerSecurityTokenProviders = iIssuerSecurityTokenProviders
                    //Provider = new QueryStringOAuthBearerProvider()
                });
        }
    }
}
