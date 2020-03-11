using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evanto.BL;
using Evanto.BL.Operations.RoleOperations;
using Evanto.Web.Admin.Filter;
using log4net;

namespace Evanto.Web.Admin.Controllers
{

    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {

        #region Properties

        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        public ActionResult Index()
        {
            ViewBag.Title = "Role";
            return View();
        }
        

        [HttpGet]
        public JsonResult RoleList(int jtStartIndex = 0, int jtPageSize = 0)
        {
            try
            {
                //Get data from database
                GetRoleOperation op = new GetRoleOperation();
                OperationResult<GetRoleOutput> opResult = op.Execute(new GetRoleInput());
                var query = opResult.Output.Roles.OrderBy(x => x.CreatedDate);
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

        [HttpPost]
        public JsonResult CreateRole(CreateRoleInput parameters)
        {
            try
            {
                CreateRoleOperation op = new CreateRoleOperation();
                OperationResult<CreateRoleOutput> opResult = op.Execute(parameters);
                if (opResult.IsSuccess) return Json(new {Result = "OK", Record = parameters});
                return Json(new {Result = "ERROR", Message = opResult.ErrorList.FirstOrDefault()?.Text});
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                Log.Error("Error occured: ", ex);
                return Json(new {Result = "ERROR", Message = ex.Message});
            }
        }

        [HttpPost]
        public JsonResult UpdateRole(UpdateRoleInput parameters)
        {
            try
            {
                UpdateRoleOperation op= new UpdateRoleOperation();

                OperationResult<UpdateRoleOutput> opResult = op.Execute(parameters);
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
    }
}