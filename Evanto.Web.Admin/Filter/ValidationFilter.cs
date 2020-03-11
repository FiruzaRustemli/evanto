using System.Linq;
using System.Web.Mvc;
using log4net;

namespace Evanto.Web.Admin.Filter
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var viewData = filterContext.Controller.ViewData;

            if (!viewData.ModelState.IsValid)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    var message = string.Join(" | ", viewData.ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));

                    var jsonResult = new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = (new { Result = "ERROR", Message = message })
                    };
                    filterContext.Result = jsonResult;

                }
                else
                {
                    filterContext.Result = new ViewResult()
                    {
                        ViewData = viewData,
                        TempData = filterContext.Controller.TempData
                    };
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}