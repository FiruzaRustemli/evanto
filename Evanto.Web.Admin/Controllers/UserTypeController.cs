using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evanto.BL;
using Evanto.BL.Operations.UserTypeOperations;
using Evanto.Web.Admin.Extensions;
using log4net;

namespace Evanto.Web.Admin.Controllers
{

    [Authorize(Roles = "Admin")]
    public class UserTypeController : Controller
    {

        #region Properties

        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion
         
        public ActionResult Index()
        {

            ViewBag.Title = "UserType";
            return View();
        }

        #region UserType Index

        [HttpGet]
        public JsonResult UserTypeList(int jtStartIndex = 0, int jtPageSize = 0)
        {
            try
            {
                //Get data from database
                GetUserTypeOperation op = new GetUserTypeOperation();
                OperationResult<GetUserTypeOutput> opResult = op.Execute(new GetUserTypeInput());
                var query = opResult.Output.UserTypes.OrderBy(x => x.CreatedDate);
                var totalCount = query.Count();
                var data = query.Skip(jtStartIndex).Take(jtPageSize).ToList();
                //Return result to jTable
                return Json(new { Result = "OK", Records = data, TotalRecordCount = totalCount }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                Log.Error("Error occured: ", ex);

                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        #endregion

        #region UserType Create

        [HttpPost]
        public JsonResult CreateUserType(CreateUserTypeInput parameters)
        {
            try
            {
                CreateUserTypeOperation op = new CreateUserTypeOperation();
                OperationResult<CreateUserTypeOutput> opResult = op.Execute(parameters);
                if (opResult.IsSuccess) return Json(new { Result = "OK", Record = parameters });
                return Json(new { Result = "ERROR", Message = opResult.ErrorList.FirstOrDefault()?.Text });
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                Log.Error("Error occured: ", ex);
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        #endregion

        #region UserType Edit

        [HttpPost]
        public JsonResult UpdateUserType(UpdateUserTypeInput parameters)
        {
            try
            {
                UpdateUserTypeOperation op = new UpdateUserTypeOperation();
                OperationResult<UpdateUserTypeOutput> opResult = op.Execute(parameters);
                if (!opResult.IsSuccess)
                {
                    return Json(new { Result = "ERROR", Message = "Failed" });

                }
                return Json(new { Result = "OK", Record = parameters });


            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                Log.Error("Error occured: ", ex);
                return Json(new { Result = "ERROR", Message = ex.Message });

            }
        }

        #endregion

        #region UserType Delete

        [HttpPost]
        public JsonResult DeleteUserType(int id)
        {
            try
            {
                //UpdateUserTypeOperations op = new UpdateUserTypeOperations();
                //OperationResult<UpdateUserTypeOutput> opResult = op.Execute(parameters);
                //if (!opResult.IsSuccess)
                //{
                //    return Json(new { Result = "ERROR", Message = "Failed" });

                //}
                return Json(new { Result = "OK", Record = "Saka lan saka silemezsin bunu" });


            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                Log.Error("Error occured: ", ex);
                return Json(new { Result = "ERROR", Message = ex.Message });

            }
        }


        #endregion
    }
}