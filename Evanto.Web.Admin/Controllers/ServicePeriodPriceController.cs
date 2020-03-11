using System;
using System.Linq;
using System.Web.Mvc;
using Evanto.BL;
using Evanto.BL.Operations.ServiceOperations;
using Evanto.BL.Operations.ServicePeriodOperations;
using Evanto.BL.Operations.ServicePeriodPriceOperations;
using log4net;

namespace Evanto.Web.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServicePeriodPriceController : Controller
    {
        #region Properties

        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        public ActionResult Index()
        {
            ViewBag.Title = "ServicePeriodPrice";
            return View();
        }

        [HttpGet]
        public JsonResult ServicePeriodPriceList(int jtStartIndex = 0, int jtPageSize = 0)
        {
            try
            {
                //Get data from database
                GetServicePeriodPriceByAdminOperation op = new GetServicePeriodPriceByAdminOperation();
                OperationResult<GetServicePeriodPriceByAdminOutput> opResult = op.Execute(new GetServicePeriodPriceByAdminInput());
                var query = opResult.Output.ServicePeriodPrices.OrderBy(x => x.CreatedDate);
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
        public JsonResult CreateServicePeriodPrice(CreateServicePeriodPriceInput parameters)
        {
            try
            {
                CreateServicePeriodPriceOperation op = new CreateServicePeriodPriceOperation();
                OperationResult<CreateServicePeriodPriceOutput> opResult = op.Execute(parameters);
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
        public JsonResult UpdateServicePeriodPrice(UpdateServicePeriodPriceInput parameters)
        {
            try
            {
                UpdateServicePeriodPriceOperation op = new UpdateServicePeriodPriceOperation();
                OperationResult<UpdateServicePeriodPriceOutput> opResult = op.Execute(parameters);
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
        public JsonResult GetServiceOptions()
        {
            try
            {
                GetServiceOperation op = new GetServiceOperation();
                OperationResult<GetServiceOutput> opResult = op.Execute(new GetServiceInput());
                var data = opResult.Output.Services.Select(c => new { DisplayText = c.Name, Value = c.Id }).ToList();
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
        public JsonResult GetPeriodOptions()
        {
            try
            {
                GetServicePeriodOperation op = new GetServicePeriodOperation();
                OperationResult<GetServicePeriodOutput> opResult = op.Execute(new GetServicePeriodInput());
                var data = opResult.Output.Periods.Select(c => new { DisplayText = c.Name, Value = c.Id }).ToList();
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
    }
}