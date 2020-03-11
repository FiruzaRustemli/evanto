using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evanto.BL;
using Evanto.BL.Operations.EventTypeOperations;
using log4net;

namespace Evanto.Web.Admin.Controllers
{

    [Authorize(Roles = "Admin")]
    public class EventTypeController : Controller
    {
        #region Properties

        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        public ActionResult Index()
        {
            ViewBag.Title = "EventType";
            return View();
        }

        #region EventType Index

        [HttpGet]
        public JsonResult EventTypeList(int jtStartIndex = 0, int jtPageSize = 0)
        {
            try
            {
                //Get data from database
                GetEventTypeOperation op = new GetEventTypeOperation();
                OperationResult<GetEventTypeOutput> opResult = op.Execute(new GetEventTypeInput());
                var query = opResult.Output.EventTypes.OrderBy(x => x.CreatedDate);
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

        #region EventType Create

        [HttpPost]
        public JsonResult CreateEventType(CreateEventTypeInput parameters)
        {
            try
            {
                CreateEventTypeOperation op = new CreateEventTypeOperation();
                OperationResult<CreateEventTypeOutput> opResult = op.Execute(parameters);
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

        #region EventType Edit

        [HttpPost]
        public JsonResult UpdateEventType(UpdateEventInput parameters)
        {
            try
            {
                UpdateEventTypeOperation op = new UpdateEventTypeOperation();
                OperationResult<UpdateEventOutput> opResult = op.Execute(parameters);
                if (!opResult.IsSuccess) return Json(new {Result = "ERROR", Message = "Failed"});
                parameters.Name = opResult.Output.EventType.Name;
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

        #region EventType Delete

        [HttpPost]
        public JsonResult DeleteEventType(int id)
        {
            try
            {
                //UpdateEventStatusOperations op = new UpdateEventStatusOperations();
                //OperationResult<UpdateEventStatusOutput> opResult = op.Execute(parameters);
                //if (!opResult.IsSuccess)
                //{
                //    return Json(new { Result = "ERROR", Message = "Failed" });

                //}
                return Json(new { Result = "OK", Record = "Saka lan saka silemezsin bunu" });


            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });

            }
        }


        #endregion
    }
}