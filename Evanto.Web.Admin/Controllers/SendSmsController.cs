using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evanto.BL;
using Evanto.BL.Operations.RoleOperations;
using Evanto.BL.Operations.SmsOperations;

namespace Evanto.Web.Admin.Controllers
{
  [Authorize]
  public class SendSmsController : Controller
  {
    // GET: SendSMS
    public ActionResult Index()
    {
      GetSmsQueueOperation op = new GetSmsQueueOperation();
      OperationResult<GetSmsQueueOutput> opResult = op.Execute(new GetSmsQueueInput());
      var data = opResult.Output.SmsQueues.OrderByDescending(x => x.CreatedDate).ToList();
      
      return View(data);
    }
  }
}