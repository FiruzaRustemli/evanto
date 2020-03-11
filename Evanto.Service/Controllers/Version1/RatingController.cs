using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Evanto.BL.Operations.BookingOperations;
using Evanto.BL.Operations.RatingOperations;
using Evanto.BL.Operations.VendorOperations;
using Evanto.Service.Attributes;
using Evanto.Service.Extensions;
using Evanto.Service.Routing;

namespace Evanto.Service.Controllers.Version1
{
    [ApiVersion1RoutePrefix("ratings")]
    public class RatingController : BaseController
    {
        #region Common

        #endregion

        #region User

    //    [EvantoAuthorize(Roles = "User")]
        [Route("user")]
        [ResponseType(typeof(CreateRatingOutput))]
        [HttpPost]
        public IHttpActionResult Get(CreateRatingInput parameters)
        {
            var op = new CreateRatingOperation();
            var opResult = op.Execute(parameters.Authorized());
            return Result(opResult);
        }

      //  [EvantoAuthorize(Roles = "User")]
        [Route("user")]
        [ResponseType(typeof(GetUserRatingsByUserOutput))]
        [HttpGet]
        public IHttpActionResult Get([FromUri] GetUserRatingsByUserInput parameters)
        {
            var op = new GetUserRatingsByUserOperation();
            var opResult = op.Execute(parameters.Authorized());
            return Result(opResult);
        }


        #endregion

        #region Vendor

        #endregion
    }
}
