using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Evanto.BL;
using Evanto.BL.Operations.RatingOperations;
using Evanto.BL.Operations.UserOperations;
using Evanto.BL.Operations.VendorServiceOperations;
using Evanto.Web.Admin.Models;
using log4net;
using GetVendorServiceInput = Evanto.BL.Operations.PublicOperations.GetVendorServiceInput;
using GetVendorServiceOutput = Evanto.BL.Operations.PublicOperations.GetVendorServiceOutput;

namespace Evanto.Web.Admin.Controllers
{

    [Authorize(Roles = "Admin")]
    public class RatingController : Controller
    {
        #region Properties

        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion


        public ActionResult Index()
        {
            ViewBag.Title = "Rating";
            return View();
        }

        [HttpGet]
        public JsonResult RatingList(int jtStartIndex = 0, int jtPageSize = 0)
        {
            try
            {
                GetRatingOperationByAdmin op = new GetRatingOperationByAdmin();
                OperationResult<GetRatingOutputByAdmin> opResult = op.Execute(new GetRatingInputByAdmin());
                var query = opResult.Output.Ratings.OrderBy(x => x.CreatedDate);
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
        public JsonResult DeleteRating(DeleteRatingInput parameters)
        {
            try
            {
                DeleteRatingOperation op = new DeleteRatingOperation();
                OperationResult<DeleteRatingOutput> opResult = op.Execute(parameters);
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

        //[HttpPost]
        //public JsonResult GetUserOptions()
        //{
        //    try
        //    {
        //        GetUsersOperationsByAdmin op = new GetUsersOperationsByAdmin();
        //        OperationResult<GetUsersOutputByAdmin> opResult = op.Execute(new GetUsersInputByAdmin());
        //        var data = opResult.Output.Users.Select(c => new { DisplayText = c.Username, Value = c.Id }).ToList();
        //        var totalCount = data.Count();
        //        //Return result to jTable
        //        return Json(new { Result = "OK", Options = data, TotalRecordCount = totalCount }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        while (ex.InnerException != null)
        //            ex = ex.InnerException;

        //        Log.Error("Error occured: ", ex);

        //        return Json(new { Result = "ERROR", Message = ex.Message });
        //    }
        //}

        //[HttpPost]
        //public JsonResult GetVendorServiceOptions()
        //{
        //    try
        //    {
        //        GetVendorServiceByAdminOperation op = new GetVendorServiceByAdminOperation();
        //        OperationResult<GetVendorServiceByAdminOutput> opResult = op.Execute(new GetVendorServiceByAdminInput());
        //        var data = opResult.Output.VendorServices.Select(c => new { DisplayText = c.Name, Value = c.Id }).ToList();
        //        var totalCount = data.Count();
        //        return Json(new { Result = "OK", Options = data, TotalRecordCount = totalCount }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        while (ex.InnerException != null)
        //            ex = ex.InnerException;

        //        Log.Error("Error occured: ", ex);
        //        return Json(new { Result = "ERROR", Message = ex.Message });
        //    }
        //}


    }
}