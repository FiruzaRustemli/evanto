using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Evanto.Web.User.Controllers
{
  public class ConnectionController : Controller
  {
    [Route("~/connection/check")]
    [HttpGet]
    public bool Check()
    {
      return true;
    }
  }
}