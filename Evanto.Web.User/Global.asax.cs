using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using log4net;

namespace Evanto.Web.User
{
  public class MvcApplication : System.Web.HttpApplication
  {

    private static readonly ILog log = LogManager.GetLogger(typeof(MvcApplication));

    void Application_Error(Object sender, EventArgs e)
    {
      Exception ex = Server.GetLastError().GetBaseException();

      log.Error("Error", ex);
    }


    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();
      RouteConfig.RegisterRoutes(RouteTable.Routes);
    }

    protected void Application_BeginRequest(Object sender, EventArgs e)
    {
      //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
      if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
      {
        HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache");
        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
        HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
        HttpContext.Current.Response.End();
      }

      //Check Language       
      HttpCookie cookie = HttpContext.Current.Request.Cookies["Language"];
      if (cookie?.Value != null)
      {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cookie.Value);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cookie.Value);
      }
      else
      {

        cookie = new HttpCookie("Language") {Value = "Az"};
        HttpContext.Current.Response.Cookies.Add(cookie);
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("Az");
        System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("Az");
      }
    }
  }
}
