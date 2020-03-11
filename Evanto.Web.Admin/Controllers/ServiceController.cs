using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evanto.BL;
using Evanto.BL.Operations.ServiceOperations;
using Evanto.Web.Admin.Filter;
using log4net;

namespace Evanto.Web.Admin.Controllers
{

    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        #region Properties

        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        public ActionResult Index()
        {
            ViewBag.Title = "Service";
            return View();
        }
        
        [HttpGet]
        public JsonResult ServiceList(int jtStartIndex = 0, int jtPageSize = 0)
        {
            try
            {
                //Get data from database
                GetServiceOperation op = new GetServiceOperation();
                OperationResult<GetServiceOutput> opResult = op.Execute(new GetServiceInput());
                var query = opResult.Output.Services.OrderBy(x => x.CreatedDate);
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
        public JsonResult CreateService(CreateServiceInput parameters)
        {
            try
            {
                CreateServiceOperation op = new CreateServiceOperation();
                OperationResult<CreateServiceOutput> opResult = op.Execute(parameters);
                if (opResult.IsSuccess) return Json(new { Result = "OK", Record = parameters });
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
        public JsonResult UpdateService(UpdateServiceInput parameters)
        {
            try
            {
                UpdateServiceOperation op= new UpdateServiceOperation();
                OperationResult<UpdateServiceOutput> opResult = op.Execute(parameters);
                if (!opResult.IsSuccess)
                {
                    return Json(new { Result = "ERROR", Message = "Failed" });
                }
                parameters.Name = opResult.Output.Service.Name;
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
    }
}