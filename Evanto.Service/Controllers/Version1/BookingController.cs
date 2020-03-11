using System.Web.Http;
using System.Web.Http.Description;
using Evanto.BL;
using Evanto.BL.Operations.BookingOperations;
using Evanto.BL.Operations.UserOperations;
using Evanto.Service.Attributes;
using Evanto.Service.Extensions;
using Evanto.Service.Helpers;
using Evanto.Service.Routing;
using Newtonsoft.Json;
using Evanto.BL.DTOs.Core;
using Microsoft.AspNet.SignalR;
using Evanto.Service.Hubs;

namespace Evanto.Service.Controllers.Version1
{
    [ApiVersion1RoutePrefix("bookings")]
    public class BookingController : BaseController
    {
        #region Common

        #endregion

        #region User

      //  [EvantoAuthorize(Roles = "User")]
        [Route("user")]
        [ResponseType(typeof(GetBookingByUserOutput))]
        [HttpGet]
        public IHttpActionResult Get([FromUri] GetBookingByUserInput parameters)
        {
            var op = new GetBookingByUserOperation();
            var opResult = op.Execute(parameters.Authorized());
            return Result(opResult);
        }

      //  [EvantoAuthorize(Roles = "User")]
        [Route("user/lastBookings")]
        [ResponseType(typeof(GetLastBookingsByUserOutput))]
        [HttpGet]
        public IHttpActionResult Get([FromUri] GetLastBookingsByUserInput parameters)
        {
            var op = new GetLastBookingsByUserOperation();
            var opResult = op.Execute(parameters.Authorized());
            return Result(opResult);
        }

     //   [EvantoAuthorize(Roles = "User")]
        [Route("user")]
        [ResponseType(typeof(CreateBookingOutput))]
        [HttpPost]
        public IHttpActionResult Post(CreateBookingInput parameters)
        {
            var op = new CreateBookingOperation();
            var opResult = op.Execute(parameters.Authorized());
            if (opResult.IsSuccess)
            {
                GetConnectionIdsOperation conOp = new GetConnectionIdsOperation();
                var conOpResult = conOp.Execute(new GetConnectionIdsInput()
                {
                    UserId = (int)parameters.VendorId
                });
                this.hubContext.Clients.Clients(conOpResult.Output.ConnectionIds).refreshNotifications();
            }
            return Result(opResult);
        }

        #endregion

        #region Vendor

      //  [EvantoAuthorize(Roles = "Vendor")]
        [Route("vendor")]
        [ResponseType(typeof(GetBookingByVendorOutput))]
        [HttpGet]
        public IHttpActionResult GetBookingByVendor([FromUri]GetBookingByVendorInput parameters)
        {
            var op = new GetBookingByVendorOperation();
            var opResult = op.Execute(parameters.Authorized());
            return Result(opResult);
        }

      //  [EvantoAuthorize(Roles = "Vendor")]
        [Route("vendor")]
        [ResponseType(typeof(CreateBookingByVendorOutput))]
        [HttpPost]
        public IHttpActionResult CreateBookingByVendor(CreateBookingByVendorInput parameters)
        {
            var op = new CreateBookingByVendorOperation();
            var opResult = op.Execute(parameters.Authorized());
            return Result(opResult);
        }

       // [EvantoAuthorize(Roles = "Vendor")]
        [Route("vendor/userInfo")]
        [ResponseType(typeof(GetUserInfoByBkngIdByVendorOutput))]
        [HttpPost]
        public IHttpActionResult GetUserInfoByBkngIdByVendor(GetUserInfoByBkngIdByVendorInput parameters)
        {
            var op = new GetUserInfoByBkngIdByVendorOperation();
            var opResult = op.Execute(parameters.Authorized());
            return Result(opResult);
        }

    //    [EvantoAuthorize(Roles = "Vendor")]
        [Route("vendor/changeStatus")]
        [ResponseType(typeof(ChangeStatusBookingByVendorOutput))]
        [HttpPost]
        public IHttpActionResult ChangeStatusByVendor(ChangeStatusBookingByVendorInput parameters)
        {
            var op = new ChangeStatusBookingByVendorOperation();
            var opResult = op.Execute(parameters.Authorized());
            if (opResult.IsSuccess)
            {
                GetConnectionIdsOperation conOp = new GetConnectionIdsOperation();
                var conOpResult = conOp.Execute(new GetConnectionIdsInput()
                {
                    UserId = (int)opResult.Output.Booking.UserId
                });
                this.hubContext.Clients.Clients(conOpResult.Output.ConnectionIds).refreshNotifications();
            }
            return Result(opResult);
        }

        #endregion
    }
}
