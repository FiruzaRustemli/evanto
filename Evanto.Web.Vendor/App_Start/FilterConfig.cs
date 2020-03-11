using System.Web;
using System.Web.Mvc;

namespace Evanto.Web.Vendor
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
