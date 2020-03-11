using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Evanto.BL;
using Evanto.BL.Operations.BookingOperations;
using Evanto.BL.Operations.FileOperations;
using Evanto.BL.Operations.UserActivationOperations;
using Evanto.BL.Operations.UserOperations;
using Evanto.BL.Operations.UserVerificationOperations;
using Evanto.Utils.Enums;
using Evanto.Web.Admin.Models;

namespace Evanto.Web.Admin.Controllers
{

  [Authorize(Roles = "Admin")]
  public class UserController : Controller
  {
    // GET: Role
    public ActionResult Index()
    {
      ViewBag.Title = "User";
      GetUsersOperationsByAdmin op = new GetUsersOperationsByAdmin();
      OperationResult<GetUsersOutputByAdmin> opResult = op.Execute(new GetUsersInputByAdmin { Type = (int)UserTypeValue.User });
      var data = opResult.Output.Users.OrderBy(x => x.CreatedDate).ToList();
      return View(data);
    }

    [HttpGet]
    public JsonResult UserList(int jtStartIndex = 0, int jtPageSize = 0)
    {
      try
      {
        //Get data from database
        GetUsersOperationsByAdmin op = new GetUsersOperationsByAdmin();
        OperationResult<GetUsersOutputByAdmin> opResult = op.Execute(new GetUsersInputByAdmin { Type = (int)UserTypeValue.User });
        var query = opResult.Output.Users.OrderBy(x => x.FirstName);
        var totalCount = query.Count();
        var data = query.Skip(jtStartIndex).Take(jtPageSize).ToList();
        //Return result to jTable
        return Json(new { Result = "OK", Records = data, TotalRecordCount = totalCount }, JsonRequestBehavior.AllowGet);
      }
      catch (Exception ex)
      {
        return Json(new { Result = "ERROR", Message = ex.Message });
      }
    }

    public ActionResult Update(int id)
    {
      GetUserByAdminOperation op = new GetUserByAdminOperation();
      OperationResult<GetUserOutputByAdmin> opResult = op.Execute(new GetUserInputByAdmin { Id = id });
      return View(opResult.Output.User);
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
          parameters.Container = System.Convert.ToBase64String(binaryData, 0, binaryData.Length);
          parameters.Avatar.InputStream.Close();
          parameters.MediaType = parameters.Avatar.ContentType;
        }
        parameters.Avatar = null;
        OperationResult<UpdateByAdminUserOutput> opResult = op.Execute(parameters);
        if (!opResult.IsSuccess)
        {
          TempData["Notification"] = new Notification() { Message = opResult.ErrorList.FirstOrDefault()?.Text, Status = "danger", Position = "top-center" };
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
              start = output.BookDate.ToString("yyyy-MM-dd"),
              url = "https://www.youtube.com/watch?v=98hQhTtEq-Q"
            });
          }

          else
          {
            data.Add(new
            {
              title = output.Description + "" + output.BookDate.Hour.ToString(),
              start = output.BookDate.ToString("yyyy-MM-dd"),
              url = "https://www.youtube.com/watch?v=98hQhTtEq-Q"
            });
          }
        }
      }


      return Json(data, JsonRequestBehavior.AllowGet);
    }

    [HttpPost]
    public ActionResult AddBooking(CreateBookingByAdminInput parameters)
    {
      CreateBookingByAdminOperation op = new CreateBookingByAdminOperation();
      OperationResult<CreateBookingByAdminOutput> opResult = op.Execute(parameters);
      ViewBag.ActiveTab = "tabBooking";
      if (opResult.IsSuccess)
      {
        TempData["Notification"] = new Notification() { Message = "Booking Added to: " + parameters.BookDate.ToString("dd-MM-yyyy") + " Successfuly", Status = "success", Position = "top-right" };
        return RedirectToAction("Update", new { id = parameters.VendorId });
      }

      TempData["Notification"] = new Notification() { Message = "Failed, something was wrong", Status = "danger", Position = "top-right" };
      return RedirectToAction("Update", new { id = parameters.VendorId });
    }

    public JsonResult ChangeVerificationStatus(int id, bool isVerified)
    {
      UpdateUserVerificationOperation op = new UpdateUserVerificationOperation();
      OperationResult<UpdateUserVerificationOutput> opResult = op.Execute(new UpdateUserVerificationInput {Id = id, IsVerified = isVerified });
      if (opResult.IsSuccess)
      {
        return Json(new { opResult.Output.UserVerification.IsVerified }, JsonRequestBehavior.AllowGet);
      }
      Response.StatusCode = 400;
      return Json(new { opResult.Output.UserVerification.IsVerified }, JsonRequestBehavior.AllowGet); 
    }

    public ActionResult VerifyEmail(int userId, bool status)
    {
      var op=new VerifyEmailOperation();
      var opResult = op.Execute(new VerifyEmailInput {UserId = userId,Status = status});
      if (opResult.IsSuccess)
      {
        TempData["Notification"] = new Notification() { Message = "Email Verify is changed", Status = "success", Position = "top-right" };
        return RedirectToAction("Update", "User", new { id = userId });
      }
      TempData["Notification"] = new Notification() { Message = opResult.ErrorList.FirstOrDefault()?.Text, Status = "danger", Position = "top-right" };
      return RedirectToAction("Update", "User", new { id = userId });
    }

    public ActionResult VerifyPhone(int userId, bool status)
    {
      var op = new VerifyPhoneOperation();
      var opResult = op.Execute(new VerifyPhoneInput { UserId = userId,Status = status});
      if (opResult.IsSuccess)
      {
        TempData["Notification"] = new Notification() { Message = "Phone Verify is changed", Status = "success", Position = "top-right" };
        return RedirectToAction("Update", "User", new { id = userId });
      }
      TempData["Notification"] = new Notification() { Message = opResult.ErrorList.FirstOrDefault()?.Text, Status = "danger", Position = "top-right" };
      return RedirectToAction("Update", "User", new { id = userId });
    }
  }
}