using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Evanto.Service.Routing
{
    /// <summary>
    /// Configures api versioning for version 1.
    /// </summary>
    public class ApiVersion1RoutePrefixAttribute : RoutePrefixAttribute
    {
        private const string RouteBase = "api/v1";
        private const string PrefixRouteBase = RouteBase + "/";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="routePrefix"></param>
        public ApiVersion1RoutePrefixAttribute(string routePrefix)
            : base(string.IsNullOrWhiteSpace(routePrefix) ? RouteBase : PrefixRouteBase + routePrefix)
        {
        }
    }
}
