using System.Web.Http;
using System.Web.Http.Description;
using Evanto.BL;
using Evanto.BL.Operations.DiscountCouponOperations;
using Evanto.Service.Attributes;
using Evanto.Service.Extensions;
using Evanto.Service.Helpers;
using Evanto.Service.Routing;

namespace Evanto.Service.Controllers.Version1
{
    [ApiVersion1RoutePrefix("promos")]
    public class PromoController : BaseController
    {
        #region Common

        #endregion

        #region User

        #endregion

        #region Vendor

     //   [EvantoAuthorize(Roles = "Vendor")]
        [Route("vendor/total")]
        [ResponseType(typeof(CalculateTotalDiscountByVendorOutput))]
        [HttpPost]
        public IHttpActionResult CalculateTotalDiscount(CalculateTotalDiscountByVendorInput parameters)
        {
            var op = new CalculateTotalDiscountByVendorOperation();
            var opResult = op.Execute(parameters.Authorized());
            return Result(opResult);
        }

        #endregion
    }
}
