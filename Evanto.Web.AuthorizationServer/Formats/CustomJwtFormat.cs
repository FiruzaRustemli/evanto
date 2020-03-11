using Evanto.BL;
using Evanto.BL.DTOs.Core;
using Evanto.BL.Operations.Client;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Web;
using Thinktecture.IdentityModel.Tokens;

namespace Evanto.Web.AuthorizationServer.Formats
{
    public class CustomJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private readonly string _issuer;

        public CustomJwtFormat(string issuer)
        {
            _issuer = issuer;
        }

        public string Protect(AuthenticationTicket data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            string clientid = data.Properties.Dictionary.ContainsKey("client") ? data.Properties.Dictionary["client"] : null;

            if (string.IsNullOrWhiteSpace(clientid))
            {
                throw new InvalidOperationException();
            }

            GetClientByClientIdOperation op = new GetClientByClientIdOperation();
            OperationResult<GetClientByClientIdOutput> opResult = op.Execute(new GetClientByClientIdInput()
            {
                ClientId = clientid
            });

            if (!opResult.IsSuccess)
            {
                throw new InvalidOperationException();
            }

            if (opResult.Output.Client == null)
            {
                throw new InvalidOperationException();
            }

            ClientDto client = opResult.Output.Client;

            string symmetricKeyAsBase64 = client.OAuthClientSecret;

            var keyByteArray = TextEncodings.Base64Url.Decode(symmetricKeyAsBase64);

            var signingKey = new HmacSigningCredentials(keyByteArray);

            var issued = data.Properties.IssuedUtc;
            var expires = data.Properties.ExpiresUtc;

            if (expires == null || issued == null)
            {
                return null;
            }

            var token = new JwtSecurityToken(_issuer, clientid, data.Identity.Claims, issued.Value.UtcDateTime, expires.Value.UtcDateTime, signingKey);

            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.WriteToken(token);

            return jwt;
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}