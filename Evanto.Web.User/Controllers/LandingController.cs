using System.Web;
using System.Web.Mvc;

namespace Evanto.Web.User.Controllers
{
  public class LandingController : Controller
  {
    [Route("~/landing")]
    [HttpGet]
    public ActionResult Index()
    {
      System.Web.HttpContext.Current.Session["IsAuthorized"] = true;
      return View("Index");
    }

    [Route("~/landing/ChangeLanguage")]
    [HttpGet]
    public JsonResult ChangeLanguage(string lang)
    {
      HttpCookie cookie = new HttpCookie("Language");

      System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(lang);
      System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);

      cookie.Value = lang;
      System.Web.HttpContext.Current.Response.Cookies.Remove("Language");
      System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
      return Json(new { lang=lang }, JsonRequestBehavior.AllowGet);
    }
  }
}
