﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Evanto.Web.User
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.MapMvcAttributeRoutes();

      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    }
  }
}
