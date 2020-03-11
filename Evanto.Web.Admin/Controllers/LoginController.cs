using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Evanto.BL.Operations.UserOperations;
using Evanto.Utils;
using Evanto.Web.Admin.Models;
using Microsoft.Owin.Security;

namespace Evanto.Web.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index(string id)
        {
            if (id?.ToLower()==ConfigHelper.GetAppSetting("AdminLoginParameter").ToLower())
            {
                return View();
            }
            return Redirect(ConfigHelper.GetAppSetting("EvantoUserLink"));
        }


        [HttpPost]
        public ActionResult Index(UserLoginModel parameters, string returnUrl)
        {
            var op = new UserValidationOperation();
            var opResult = op.Execute(new UserValidationInput()
            {
                Username = parameters.UserName,
                Password = parameters.Password
            });
            if (!opResult.IsSuccess)
            {
                TempData["Notification"] = new Notification() { Message = "Username or Password Is incorrect", Status = "danger", Position = "top-right" };
                return View();
            }

            if (opResult.Output.User == null)
            {
                TempData["Notification"] = new Notification() { Message = "Username or Password Is incorrect", Status = "danger", Position = "top-right" };
               return View();
            }

            if (opResult.Output.User.Role.Name.ToLower() != "admin")
            {
                TempData["Notification"] = new Notification() { Message = "You don't have a permission for Admin Panel", Status = "danger", Position = "top-right" };
                return View();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, opResult.Output.User.Username),
                new Claim("userId", opResult.Output.User.Id.ToString()),
                new Claim(ClaimTypes.Role, opResult.Output.User.Role.Name)
            };
            var identity = new ClaimsIdentity(claims, "ApplicationCookie");

            var authManager = Request.GetOwinContext().Authentication;
            authManager.SignOut();

            authManager.SignIn(new AuthenticationProperties
            { IsPersistent = parameters.RememberMe }, identity);
            
            return RedirectToAction("Index", "FeedBack");
        }

        public ActionResult LogOut()
        {
            var authManager = Request.GetOwinContext().Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Index","Login",new {id=ConfigHelper.GetAppSetting("AdminLoginParameter") });
        }
    }
}