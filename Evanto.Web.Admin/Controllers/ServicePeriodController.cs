using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evanto.BL;
using Evanto.BL.Operations.ServicePeriodOperations;
using log4net;

namespace Evanto.Web.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServicePeriodController : Controller
    {
        #region Properties

        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region ServicePeriod Index

        public ActionResult Index()
        {
            ViewBag.Title = "ServicePeriod";
            return View();
        }

        [HttpGet]
        public JsonResult ServicePeriodList(int jtStartIndex = 0, int jtPageSize = 0)
        {
            try
            {
                //Get data from database
                GetServicePeriodOperation op = new GetServicePeriodOperation();
                OperationResult<GetServicePeriodOutput> opResult = op.Execute(new GetServicePeriodInput());
                var query = opResult.Output.Periods.OrderBy(x => x.CreatedDate);
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

        #region ServicePeriod Create

        [HttpPost]
        public JsonResult CreateServicePeriod(CreateServicePeriodInput parameters)
        {
            try
            {
                CreateServicePeriodOperations op = new CreateServicePeriodOperations();
                OperationResult<CreateServicePeriodOutput> opResult = op.Execute(parameters);
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
        #endregion

        #region ServicePeriod Edit

        [HttpPost]
        public JsonResult UpdateServicePeriod(UpdateServicePeriodInput parameters)
        {
            try
            {
                UpdateServicePeriodOperations op = new UpdateServicePeriodOperations();
                OperationResult<UpdateServicePeriodOutput> opResult = op.Execute(parameters);
                if (!opResult.IsSuccess)
                {
                    return Json(new { Result = "ERROR", Message = "Failed" });

                }
                parameters.Name = opResult.Output.Period?.Name;
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

        #region ServicePeriod Delete

        [HttpPost]
        public JsonResult DeleteServicePeriod(int id)
        {
            try
            {
                //UpdateServicePeriodOperations op = new UpdateServicePeriodOperations();
                //OperationResult<UpdateServicePeriodOutput> opResult = op.Execute(parameters);
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