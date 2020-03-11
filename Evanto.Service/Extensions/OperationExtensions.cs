using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Evanto.BL;
using Newtonsoft.Json;

namespace Evanto.Service.Extensions
{
    public static class OperationExtensions
    {
        /// <summary>
        /// Sets current authenticated user id to the operation input parameter.
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static TInput Authorized<TInput>(this TInput parameters) where TInput : OperationParameters
        {
            var owinContext = HttpContext.Current.GetOwinContext();

            var input = parameters ?? new OperationParameters();

            if (owinContext.Authentication.User.Identity.IsAuthenticated)
            {
                input.CurrentUserId = owinContext.Authentication.User.GetUserId();
            }

            var parent = JsonConvert.SerializeObject(input);
            TInput child  = JsonConvert.DeserializeObject<TInput>(parent);

            return child;
        }
    }
}
