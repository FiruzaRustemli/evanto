using System;
using System.Linq;
using System.Web.Mvc;
using Evanto.BL;
using Evanto.BL.Operations.UserStatusOperations;
using log4net;

namespace Evanto.Web.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserStatusController : Controller
    {
        #region Properties

        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region UserStatus Index

        public ActionResult Index()
        {
            ViewBag.Title = "UserStatus";
            return View();
        }

        [HttpGet]
        public JsonResult UserStatusList(int jtStartIndex = 0, int jtPageSize = 0)
        {
            try
            {
                //Get data from database
                GetUserstatusOperation op = new GetUserstatusOperation();
                OperationResult<GetUserStatusOutput> opResult = op.Execute(new GetUserStatusInput());
                var query = opResult.Output.UserStatuses.OrderBy(x => x.CreatedDate);
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
        #endregion
        
        #region UserStatus Create

        [HttpPost]
        public JsonResult CreateUserStatus(CreateUserStatusInput parameters)
        {
            try
            {
                CreateUserStatusOperation op = new CreateUserStatusOperation();
                OperationResult<CreateUserStatusOutput> opResult = op.Execute(parameters);
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

        #region UserStatus Edit

        [HttpPost]
        public JsonResult UpdateUserStatus(UpdateUserStatusInput parameters)
        {
            try
            {
                UpdateUserStatusOperation op = new UpdateUserStatusOperation();
                OperationResult<UpdateUserStatusOutput> opResult = op.Execute(parameters);
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

        #region UserStatus Delete

        [HttpPost]
        public JsonResult DeleteUserStatus(int id)
        {
            try
            {
                //UpdateUserStatusOperations op = new UpdateUserStatusOperations();
                //OperationResult<UpdateUserStatusOutput> opResult = op.Execute(parameters);
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