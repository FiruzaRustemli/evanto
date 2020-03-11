using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Evanto.Service.Routing;
using System.Web.Http;
using Evanto.Service.Extensions;
using System.Web.Http.Description;
using Evanto.BL.Operations.NotificationOperations;
using Evanto.Service.Attributes;
using Evanto.BL;
using Evanto.Service.Helpers;
using log4net;

namespace Evanto.Service.Controllers.Version1
{
    [ApiVersion1RoutePrefix("notifications")]
    public class NotificationController : BaseController
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(NotificationController));

        #region Common

      //  [EvantoAuthorize(Roles = "User, Vendor")]
        [Route("booking")]
        [ResponseType(typeof(UpdateBookingNotificationOutput))]
        [HttpPut]
        public IHttpActionResult Put(UpdateBookingNotificationInput parameters)
        {
            var op = new UpdateBookingNotificationOperation();
            var opResult = op.Execute(parameters.Authorized());
            return Result(opResult);
        }

        #endregion

        #region User

       // [EvantoAuthorize(Roles = "User")]
        [Route("booking/user")]
        [ResponseType(typeof(GetBookingNotificationByUserOutput))]
        [HttpGet]
        public IHttpActionResult Get(GetBookingNotificationByUserInput parameters)
        {
            var op = new GetBookingNotificationByUserOperation();
            var opResult = op.Execute(parameters.Authorized());
            return Result(opResult);
        }

        #endregion


        #region Vendor

       // [EvantoAuthorize(Roles = "Vendor")]
        [Route("booking/vendor")]
        [ResponseType(typeof(GetBookingNotificationByVendorOutput))]
        [HttpGet]
        public IHttpActionResult Get([FromUri]GetBookingNotificationByVendorInput parameters)
        {
            var op = new GetBookingNotificationByVendorOperation();
            var opResult = op.Execute(parameters.Authorized());
            return Result(opResult);
        }

        #endregion
    }
}
