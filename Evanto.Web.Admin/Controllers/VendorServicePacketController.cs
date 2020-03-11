using System;
using System.Linq;
using System.Web.Mvc;
using Evanto.BL;
using Evanto.BL.Operations.DiscountCouponOperations;
using Evanto.BL.Operations.VendorOperations;
using Evanto.BL.Operations.VendorServiceOperations;
using Evanto.BL.Operations.VendorServicePacketOperation;
using Evanto.BL.Operations.VendorServicePacketStatusOperation;
using log4net;

namespace Evanto.Web.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class VendorServicePacketController : Controller
    {
        #region Properties

        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        public ActionResult Index()
        {
            ViewBag.Title = "VendorServicePacket";
            return View();
        }

        [HttpGet]
        public JsonResult VendorServicePacketList(int jtStartIndex = 0, int jtPageSize = 0)
        {
            try
            {
                //Get data from database
                GetVendorServicePacketByAdminOperation op = new GetVendorServicePacketByAdminOperation();
                OperationResult<GetVendorServicePacketByAdminOutput> opResult = op.Execute(new GetVendorServicePacketByAdminInput());
                var query = opResult.Output.VendorServicePackets.OrderBy(x => x.CreatedDate);
                var totalCount = query.Count();
                var data = query.Skip(jtStartIndex).Take(jtPageSize).ToList();
                foreach (var item in data)
                {
                    item.Amount = item.Payment.Amount;
                }
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
        public JsonResult CreateVendorServicePacket(AddVendorServicePacketInput parameters)
        {
            try
            {
                AddVendorServicePacketOperation op = new AddVendorServicePacketOperation();
                OperationResult<AddVendorServicePacketOutput> opResult = op.Execute(parameters);
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
        public JsonResult UpdateVendorServicePacket(UpdateVendorServicePacketByAdminInput parameters)
        {
            try
            {
                UpdateVendorServicePacketByAdminOperation op = new UpdateVendorServicePacketByAdminOperation();
                OperationResult<UpdateVendorServicePacketByAdminOutput> opResult = op.Execute(parameters);
                if (opResult.IsSuccess) return Json(new { Result = "OK", Record = opResult.Output.VendorServicePacketByAdminDto });
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
        public JsonResult GetStatusOptions()
        {
            try
            {
                GetVendorServicePacketStatusByAdminOperations op = new GetVendorServicePacketStatusByAdminOperations();
                OperationResult<GetVendorServicePacketStatusByAdminOutput> opResult = op.Execute(new GetVendorServicePacketStatusByAdminInput());
                var data = opResult.Output.VendorServicePacketStatus.Select(c => new { DisplayText = c.Name, Value = c.Id }).ToList();
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
        public JsonResult GetDiscountCouponOptions()
        {
            try
            {
                GetDiscountCouponOperation op = new GetDiscountCouponOperation();
                OperationResult<GetDiscountCouponOutput> opResult = op.Execute(new GetDiscountCouponInput());
                var data = opResult.Output.DiscountCoupons.Select(c => new { DisplayText = c.CouponNumber, Value = c.Id }).ToList();
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
        public JsonResult GetVendorOptions()
        {
            try
            {
                GetVendorOperation op = new GetVendorOperation();
                OperationResult<GetVendorOutput> opResult = op.Execute(new GetVendorInput());
                var data = opResult.Output.Vendors.Select(c => new { DisplayText = c.User.FirstName+" "+c.User.LastName, Value = c.UserId }).ToList();
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

        //[HttpPost]
        //public JsonResult GetPaymentOptions()
        //{
        //    try
        //    {
        //        GetPaymentOperation op = new GetPaymentOperation();
        //        OperationResult<GetPaymentOutput> opResult = op.Execute(new GetPaymentInput());
        //        var data = opResult.Output.Payments.Select(c => new { DisplayText = c.Name, Value = c.Id }).ToList();
        //        var totalCount = data.Count();
        //        //Return result to jTable
        //        return Json(new { Result = "OK", Options = data, TotalRecordCount = totalCount }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Result = "ERROR", Message = ex.Message });
        //    }
        //}

        [HttpPost]
        public JsonResult GetVendorServiceOptions(GetVendorServiceInput parameters)
        {
            try
            {
                GetVendorServiceOperation op = new GetVendorServiceOperation();
                OperationResult<GetVendorServiceOutput> opResult = op.Execute(parameters);
                var data = opResult.Output.VendorServices.ToList();
                var totalCount = data.Count();
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
    }
}