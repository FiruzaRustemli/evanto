using System;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;
using Evanto.BL;
using Evanto.BL.Operations.FeedbackOperations;
using Evanto.BL.Operations.FeedbackStatusOperations;
using Evanto.BL.Operations.FeedbackTypeOperations;
using Evanto.Web.Admin.Models;
using log4net;

namespace Evanto.Web.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FeedBackController : Controller
    {
        #region Properties

        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion


        public ActionResult Index()
        {
            ViewBag.Title = "Feedback";
            return View();
        }

        [HttpGet]
        public JsonResult FeedbackList(int jtStartIndex = 0, int jtPageSize = 0)
        {
            try
            {
                GetFeedbackOperation op = new GetFeedbackOperation();
                OperationResult<GetFeedbackOutput> opResult = op.Execute(new GetFeedbackInput());
                var query = opResult.Output.Feedbacks.OrderBy(x => x.CreatedDate);
                var totalCount = query.Count();
                var data = query.Skip(jtStartIndex).Take(jtPageSize).ToList();
                //Return result to jTable
                return Json(new { Result = "OK", Records = data, TotalRecordCount = totalCount }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                while (ex.InnerException!=null)
                ex=ex.InnerException;

                Log.Error("Error occured: ", ex);

                return Json(new { Result = "ERROR", Message = ex.Message });
                
            }
        }

        [HttpPost]
        public JsonResult CreateFeedback(CreateFeedbackInput parameters)
        {
            CreateFeedbackOperation op = new CreateFeedbackOperation();
            OperationResult<CreateFeedbackOutput> opResult = op.Execute(parameters);
            if (opResult.IsSuccess) return Json(new { Result = "OK", Record = parameters });
            return Json(new { Result = "ERROR", Message = "Failed" });
        }

        [HttpPost]
        public JsonResult UpdateFeedback(UpdateFeedbackInput parameters)
        {
            try
            {
                UpdateFeedbackOperation op = new UpdateFeedbackOperation();
                OperationResult<UpdateFeedbackOutput> opResult = op.Execute(parameters);
                parameters.Email = opResult.Output.Email;
                if (opResult.IsSuccess) return Json(new {Result = "OK", Record = parameters});
               return Json(new { Result = "ERROR", Message = "Failed" });
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                Log.Error("Error occured: ", ex);
                return Json(new { Result = "ERROR", Message = ex.Message });

            }
        }

        [HttpPost]
        public JsonResult GetStatusOptions()
        {
            try
            {
                GetFeedbackStatusOperation op = new GetFeedbackStatusOperation();
                OperationResult<GetFeedbackStatusOutput> opResult = op.Execute(new GetFeedbackStatusInput());
                var data = opResult.Output.FeedbackStatuses.Select(c => new { DisplayText = c.Name, Value = c.Id }).ToList();
                var totalCount = data.Count();
                //Return result to jTable
                return Json(new { Result = "OK", Options = data, TotalRecordCount = totalCount }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                Log.Error("Error occured: ", ex);

                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult GetTypeOptions()
        {
            try
            {
                GetFeedbackTypeOperation op = new GetFeedbackTypeOperation();
                OperationResult<GetFeedbackTypeOutput> opResult = op.Execute(new GetFeedbackTypeInput());
                var data = opResult.Output.FeedbackTypes.Select(c => new { DisplayText = c.Name, Value = c.Id }).ToList();
                var totalCount = data.Count();
                return Json(new { Result = "OK", Options = data, TotalRecordCount = totalCount }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                Log.Error("Error occured: ", ex);
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }


        [HttpPost]
        public async Task<ActionResult> SendEmail( EmailSender email, string userEmail)
        {
            try
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress(email.UserEmail));
                message.From = new MailAddress("o.rzazade@gmail.com");
                message.Subject = email.Subject;
                message.Body = string.Format(body, "Evanto", "o.rzazade@gmail.com", email.Content);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);

                    TempData["Notification"] = new Notification() { Message = "Email Sent Successfuly", Status = "success", Position = "top-right" };
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                Log.Error("Error occured: ", ex);
                TempData["Notification"] = new Notification() { Message = "Failed, something was wrong", Status = "danger", Position = "top-center" };
                return RedirectToAction("Index");
            }
        }
    }
}