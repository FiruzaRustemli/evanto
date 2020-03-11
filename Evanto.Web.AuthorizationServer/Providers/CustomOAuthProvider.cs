using Evanto.BL;
using Evanto.BL.Operations.Client;
using Evanto.BL.Operations.UserOperations;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Evanto.Web.AuthorizationServer.Providers
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            string clientSecret;
            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            // Validates client
            ClientValidationOperation op = new ClientValidationOperation();
            OperationResult<ClientValidationOutput> opResult = op.Execute(new ClientValidationInput()
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            });

            if(!opResult.IsSuccess)
            {
                return Task.FromResult<object>(null);
            }

            if(!opResult.Output.IsValid)
            {
                return Task.FromResult<object>(null);
            }

            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            // Validates user
            var op = new UserValidationOperation();
            var opResult = op.Execute(new UserValidationInput()
            {
                Username = context.UserName,
                Password = context.Password
            });

            if (!opResult.IsSuccess)
            {
                context.SetError(JsonConvert.SerializeObject(opResult.ErrorList));
                return Task.FromResult<object>(null);
            }

            if (opResult.Output.User == null)
            {
                return Task.FromResult<object>(null);
            }
            
            var identity = new ClaimsIdentity("JWT");

            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim("userId", opResult.Output.User.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Role, opResult.Output.User.Role.Name));

            var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                         "client", context.ClientId ?? string.Empty
                    }
                });

            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);
            return Task.FromResult<object>(null);
        }
    }
}