using System;
using System.CodeDom;
using System.Linq;
using System.Web.Mvc;
using Evanto.BL;
using Evanto.BL.Operations.CouponTypeOperations;
using Evanto.BL.Operations.DiscountCouponOperations;
using Evanto.BL.Operations.DiscountCouponStatusOperations;
using Evanto.BL.Operations.DiscountTypeOperations;

namespace Evanto.Web.Admin.Controllers
{

    [Authorize(Roles = "Admin")]
    public class DiscountCouponController : Controller
    {
        // GET: DiscountCoupon
        public ActionResult Index()
        {
            ViewBag.Title = "DiscountCoupon";
            return View();
        }

        [HttpGet]
        public JsonResult DiscountCouponList(int jtStartIndex = 0, int jtPageSize = 0)
        {
            try
            {
                //Get data from database
                GetDiscountCouponOperation op = new GetDiscountCouponOperation();
                OperationResult<GetDiscountCouponOutput> opResult = op.Execute(new GetDiscountCouponInput());
                var query = opResult.Output.DiscountCoupons.OrderBy(x => x.CreatedDate);
                var totalCount = query.Count();
                var data = query.Skip(jtStartIndex).Take(jtPageSize).ToList();
                //Return result to jTable
                return Json(new { Result = "OK", Records = data, TotalRecordCount = totalCount }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult CreateDiscountCoupon(CreateDiscountCouponInput parameters)
        {
            try
            {
                CreateDiscountCouponOperation op = new CreateDiscountCouponOperation();
                OperationResult<CreateDiscountCouponOutput> opResult = op.Execute(parameters);
                if (opResult.IsSuccess) return Json(new { Result = "OK", Record = parameters });

                return Json(new { Result = "ERROR", Message = "Failed" });
            }
            catch (Exception ex)
            {
                return Json(new{Result = "ERROR",Message = ex.Message}, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult UpdateDiscountCoupon(UpdateDiscountCouponInput parameters)
        {
            try
            {
                UpdateDiscountCouponOperation op = new UpdateDiscountCouponOperation();
                OperationResult<UpdateDiscountCouponOutput> opResult = op.Execute(parameters);
                if (opResult.IsSuccess) return Json(new { Result = "OK", Record = parameters });

                return Json(new { Result = "ERROR", Message = "Failed" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });

            }
        }

        [HttpPost]
        public JsonResult GetStatusOptions()
        {
            try
            {
                GetDiscountCouponStatusOperation op = new GetDiscountCouponStatusOperation();
                OperationResult<GetDiscountCouponStatusOutput> opResult = op.Execute(new GetDiscountCouponStatusInput());
                var data = opResult.Output.DiscountCouponStatuses.Select(c => new { DisplayText = c.Name, Value = c.Id }).ToList();
                var totalCount = data.Count();
                //Return result to jTable
                return Json(new { Result = "OK", Options = data, TotalRecordCount = totalCount }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult GetCouponTypeOptions()
        {
            try
            {
                GetCouponTypeOperation op = new GetCouponTypeOperation();
                OperationResult<GetCouponTypeOutput> opResult = op.Execute(new GetCouponTypeInput());
                var data = opResult.Output.CouponTypes.Select(c => new { DisplayText = c.Name, Value = c.Id }).ToList();
                var totalCount = data.Count();
                //Return result to jTable
                return Json(new { Result = "OK", Options = data, TotalRecordCount = totalCount }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult GetDiscountTypeOptions()
        {
            try
            {
                GetDiscountTypeOperation op = new GetDiscountTypeOperation();
                OperationResult<GetDiscountTypeOutput> opResult = op.Execute(new GetDiscountTypeInput());
                var data = opResult.Output.DiscountTypes.Select(c => new { DisplayText = c.Name, Value = c.Id }).ToList();
                var totalCount = data.Count();
                //Return result to jTable
                return Json(new { Result = "OK", Options = data, TotalRecordCount = totalCount }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
    }
}