using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Evanto.BL;
using Evanto.BL.DTOs.Admin;
using Evanto.BL.Operations.BookingOperations;
using Evanto.BL.Operations.UserOperations;
using Evanto.BL.Operations.UserVerificationOperations;
using Evanto.BL.Operations.VendorOperations;
using Evanto.BL.Operations.VendorServiceOperations;
using Evanto.Web.Admin.Models;

namespace Evanto.Web.Admin.Controllers
{

  [Authorize(Roles = "Admin")]
  public class VendorController : Controller
  {
    // GET: Role
    public ActionResult Index()
    {
      ViewBag.Title = "Vendor";
      GetVendorOperation op = new GetVendorOperation();
      OperationResult<GetVendorOutput> opResult = op.Execute(new GetVendorInput());
      var data = opResult.Output.Vendors.OrderBy(x => x.User.CreatedDate).ToList();
      return View(data);
    }

    public ActionResult Update(int id)
    {
      GetUserByAdminOperation op = new GetUserByAdminOperation();
      OperationResult<GetUserOutputByAdmin> opResult = op.Execute(new GetUserInputByAdmin { Id = id });
      return View(opResult.Output?.User);
    }

    [HttpPost]
    public ActionResult Update(UpdateByAdminUserInput parameters)
    {
      try
      {
        UpdateByAdminUserOperation op = new UpdateByAdminUserOperation();
        if (parameters.Avatar != null)
        {
          var binaryData = new byte[parameters.Avatar.InputStream.Length];
          parameters.FileExtension = Path.GetExtension(parameters.Avatar.FileName);
          long bytesRead = parameters.Avatar.InputStream.Read(binaryData, 0, (int)parameters.Avatar.InputStream.Length);
          parameters.Container = Convert.ToBase64String(binaryData, 0, binaryData.Length);
          parameters.Avatar.InputStream.Close();
          parameters.MediaType = parameters.Avatar.ContentType;
        }
        parameters.Avatar = null;
        OperationResult<UpdateByAdminUserOutput> opResult = op.Execute(parameters);
        if (!opResult.IsSuccess)
        {
          TempData["Notification"] = new Notification() { Message = "Failed, something was wrong", Status = "danger", Position = "top-center" };
          return RedirectToAction("Update", new { id = parameters.Id });

        }
        TempData["Notification"] = new Notification() { Message = "User updated Successfuly", Status = "success", Position = "top-right" };
        return RedirectToAction("Update", new { id = parameters.Id });


      }
      catch (Exception ex)
      {
        TempData["Notification"] = new Notification() { Message = "Failed, something was wrong", Status = "danger", Position = "top-right" };
        return RedirectToAction("Update", new { id = parameters.Id });

      }
    }

    [HttpPost]
    public ActionResult ResetPassword(ResetPasswordbyAdminUserInput parameters)
    {
      if (parameters.NewPassword == parameters.ConfirmPassword && parameters.NewPassword != null)
      {
        ResetPasswordbyAdminUserOperation op = new ResetPasswordbyAdminUserOperation();
        OperationResult<ResetPasswordbyAdminUserOutput> opResult = op.Execute(parameters);
        if (opResult.IsSuccess)
        {
          TempData["Notification"] = new Notification() { Message = "Password updated", Status = "success", Position = "top-right" };
          return RedirectToAction("Update", new { id = parameters.Id });
        }
        TempData["Notification"] = new Notification() { Message = "Failed, some thing was wrong", Status = "danger", Position = "top-right" };
        return RedirectToAction("Update", new { id = parameters.Id });
      }
      else
      {
        TempData["Notification"] = new Notification() { Message = "Failed, passwords must be the same", Status = "danger", Position = "top-right" };
        return RedirectToAction("Update", new { id = parameters.Id });
      }


    }
    public ActionResult Detail(int id)
    {
      GetUserByAdminOperation op = new GetUserByAdminOperation();
      OperationResult<GetUserOutputByAdmin> opResult = op.Execute(new GetUserInputByAdmin { Id = id });
      return View(opResult.Output.User);
    }

    public JsonResult GetBooking(int id)
    {
      GetBookingByAdminOperation op = new GetBookingByAdminOperation();
      GetBookingByAdminInput parameters = new GetBookingByAdminInput
      {
        VendorId = id,
        StatusId = 0
      };
      OperationResult<GetBookingByAdminOutput> opResult = op.Execute(parameters);

      var data = new List<object>();
      if (opResult.IsSuccess)
      {
        foreach (var output in opResult.Output.Bookings)
        {
          if (output.User != null)
          {
            data.Add(new
            {
              title = output.User.FirstName + "" + "" + output.BookDate.Hour.ToString(),
              start = output.BookDate.ToString("yyyy-MM-dd HH:mm"),
              deadline = output.Deadline.ToString("yyyy-MM-dd HH:mm"),
              service = output.VendorServiceId
              //url = "https://www.youtube.com/watch?v=98hQhTtEq-Q"
            });
          }

          else
          {
            data.Add(new
            {
              title = output.Description + "" + output.BookDate.Hour.ToString(),
              start = output.BookDate.ToString("yyyy-MM-dd HH:mm"),
              deadline = output.Deadline.ToString("yyyy-MM-dd HH:mm"),
              service = output.VendorServiceId
              //url = "https://www.youtube.com/watch?v=98hQhTtEq-Q"
            });
          }
        }
      }


      return Json(data, JsonRequestBehavior.AllowGet);
    }

    [HttpPost]
    public ActionResult AddBooking(CreateBookingByAdminInput parameters)
    {

      var time = TimeSpan.Parse(parameters.BookTime);
      parameters.BookDate = parameters.BookDate + time;
            CreateBookingByAdminOperation op = new CreateBookingByAdminOperation();
      OperationResult<CreateBookingByAdminOutput> opResult = op.Execute(parameters);
      TempData["Tab"] = "event";
      if (opResult.IsSuccess)
      {
        TempData["Notification"] = new Notification() { Message = "Booking Added to: " + parameters.BookDate.ToString("dd-MM-yyyy HH:mm") + " Successfuly", Status = "success", Position = "top-right" };
        return RedirectToAction("Update", new { id = parameters.VendorId });
      }

      TempData["Notification"] = new Notification() { Message = "Failed, something was wrong", Status = "danger", Position = "top-right" };
      return RedirectToAction("Update", new { id = parameters.VendorId });
    }

    [HttpGet]
    public JsonResult ChangeServiceStatus(ChangeStatusVendorServiceByAdminInput parameters)
    {
      ChangeStatusVendorServiceByAdminOperation op = new ChangeStatusVendorServiceByAdminOperation();
      TempData["Tab"] = "service";
      OperationResult<ChangeStatusVendorServiceByAdminOutput> opResult = op.Execute(parameters);
      if (opResult.IsSuccess)
      {
        return Json(new { opResult.Output.Status }, JsonRequestBehavior.AllowGet);
      }
      Response.StatusCode = 400;
      return Json(new { opResult.Output.Status }, JsonRequestBehavior.AllowGet);

    }

    public JsonResult ChangeVerificationStatus(int id, bool isVerified)
    {
      UpdateUserVerificationOperation op = new UpdateUserVerificationOperation();
      OperationResult<UpdateUserVerificationOutput> opResult = op.Execute(new UpdateUserVerificationInput { Id = id, IsVerified = isVerified });
      if (opResult.IsSuccess)
      {
        return Json(new { opResult.Output.UserVerification.IsVerified }, JsonRequestBehavior.AllowGet);
      }
      Response.StatusCode = 400;
      return Json(new { opResult.Output.UserVerification.IsVerified }, JsonRequestBehavior.AllowGet);
    }

    public ActionResult VerifyEmail(int userId, bool status)
    {
      var op = new VerifyEmailOperation();
      var opResult = op.Execute(new VerifyEmailInput { UserId = userId, Status = status });
      if (opResult.IsSuccess)
      {
        TempData["Notification"] = new Notification() { Message = "Email Verify is changed", Status = "success", Position = "top-right" };
        return RedirectToAction("Update", "Vendor", new { id = userId });
      }
      TempData["Notification"] = new Notification() { Message = opResult.ErrorList.FirstOrDefault()?.Text, Status = "danger", Position = "top-right" };
      return RedirectToAction("Update", "Vendor", new { id = userId });
    }

    public ActionResult VerifyPhone(int userId, bool status)
    {
      var op = new VerifyPhoneOperation();
      var opResult = op.Execute(new VerifyPhoneInput { UserId = userId, Status = status });
      if (opResult.IsSuccess)
      {
        TempData["Notification"] = new Notification() { Message = "Phone Verify is changed", Status = "success", Position = "top-right" };
        return RedirectToAction("Update", "Vendor", new { id = userId });
      }
      TempData["Notification"] = new Notification() { Message = opResult.ErrorList.FirstOrDefault()?.Text, Status = "danger", Position = "top-right" };
      return RedirectToAction("Update", "Vendor", new { id = userId });
    }


  }
}