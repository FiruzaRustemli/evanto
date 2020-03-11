using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;
using Evanto.BL;
using Evanto.BL.Helpers;
using Evanto.Service.Helpers;
using Evanto.Utils;
using Evanto.Utils.Enums;

namespace Evanto.Service.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var a = HttpContext.Current.Request.UserHostAddress;
            if (actionContext.ModelState.IsValid) return;

            var errors = actionContext.ModelState.Select(keyValuePair => new Error
            {
                Code = keyValuePair.Key,
                Text = string.Join(Environment.NewLine, keyValuePair.Value.Errors.Select(e => e.ErrorMessage)),
                Type = OperationResultCode.Validation
            }).ToList();

            var result = new OperationResult<ValidationResultOutput>()
            {
                ErrorList = errors
            };

            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, result);
        }
    }
}