using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.Web.Admin.Extensions
{
    public static class IdentityExtensions
    {
        /// <summary>
        /// Returns authenticated user id.
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static int GetUserId(this IPrincipal principal)
        {
            var claimsPrincipal = principal as ClaimsPrincipal;
            return claimsPrincipal != null && claimsPrincipal.HasClaim(s => s.Type.Equals("userId"))
                ? int.Parse(claimsPrincipal.Claims.First(c => c.Type.Equals("userId")).Value)
                : 0;
        }
    }
}
