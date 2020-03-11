using System.Web.Http;
using System.Web.Http.Description;
using Evanto.BL;
using Evanto.BL.Operations.EventTypeOperations;
using Evanto.BL.Operations.UserEventOperations;
using Evanto.Service.Helpers;
using Evanto.Service.Routing;
using Evanto.BL.Operations.UserOperations;
using Evanto.BL.Operations.VendorServiceExceptionalEventOperations;
using System.Security.Claims;
using Evanto.Service.Attributes;
using Evanto.Service.Extensions;

namespace Evanto.Service.Controllers.Version1
{
    [ApiVersion1RoutePrefix("events")]
    public class EventController : BaseController
    {
        #region Common

       // [EvantoAuthorize]
        [Route("types")]
        [ResponseType(typeof(GetEventTypeOutput))]
        [HttpGet]
        public IHttpActionResult Get([FromUri]GetEventTypeInput input)
        {
            var op = new GetEventTypeOperation();

            var opResult = op.Execute(input.Authorized());
            return Result(opResult);
        }

        #endregion

        #region User

      // [EvantoAuthorize(Roles = "User")]
        [Route("types/user")]
        [ResponseType(typeof(GetEventTypeByUserOutput))]
        [HttpGet]
        public IHttpActionResult Get([FromUri]GetEventTypeByUserInput input)
        {
            var op = new GetEventTypeByUserOperation();

            var opResult = op.Execute(input.Authorized());
            return Result(opResult);
        }

       // [EvantoAuthorize(Roles = "User")]
        [Route("user/last")]
        [ResponseType(typeof(GetLastUserEventsByUserOutput))]
        [HttpGet]
        public IHttpActionResult Get([FromUri]GetLastUserEventsByUserInput parameters)
        {
            var op = new GetLastUserEventsByUserOperation();
            var opResult = op.Execute(parameters.Authorized());
            return Result(opResult);

        }

      //  [EvantoAuthorize(Roles = "User")]
        [ResponseType(typeof(GetUserEventByUserOutput))]
        [Route("user")]
        [HttpGet]
        public IHttpActionResult Get([FromUri]GetUserEventByUserInput parameters)
        {
            var op = new GetUserEventByUserOperation();
            var opResult = op.Execute(parameters.Authorized());
            return Result(opResult);
        }

     //   [EvantoAuthorize(Roles = "User")]
        [ResponseType(typeof(CreateUserEventByUserOutput))]
        [Route("user")]
        [HttpPost]
        public IHttpActionResult Post(CreateUserEventByUserInput parameters)
        {
            var op = new CreateUserEventByUserOperation();
            var opResult = op.Execute(parameters.Authorized());
            return Result(opResult);
        }

        //[EvantoAuthorize(Roles = "User")]
        [Route("user")] 
        [ResponseType(typeof(UpdateUserEventOutput))]
        [HttpPut]
        public IHttpActionResult Put(UpdateUserEventInput parameters)
        {
            var op = new UpdateUserEventOperation();
            var opResult = op.Execute(parameters.Authorized());
            return Result(opResult);
        }

      //  [EvantoAuthorize(Roles = "User")]
        [Route("user/eventsBookingsCount")]
        [ResponseType(typeof(GetEventAndBookingsCountByUserOutput))]
        [HttpGet]
        public IHttpActionResult GetEventAndBookingsCount([FromUri] GetEventAndBookingsCountByUserInput input)
        {
            var op = new GetEventAndBookingsCountByUserOperation();
            var opResult = op.Execute(input.Authorized());
            return Result(opResult);
        }

        #endregion

        #region Vendor

     //   [EvantoAuthorize(Roles = "Vendor")] // TODO: Unused method
        [Route("vendor/exceptionalEvent")]
        [ResponseType(typeof(GetVendorServiceExceptionalEventOutput))]
        [HttpGet]
        public IHttpActionResult ExceptionalEvent(GetVendorServiceExceptionalEventInput parameters)
        {
            var op = new GetVendorServiceExceptionalEventOperations();
            var opResult = op.Execute(parameters.Authorized());
            return Result(opResult);
        }

        //[EvantoAuthorize(Roles = "Vendor")] // TODO: Unused method
        [Route("vendor/exceptionalEvent")]
        [ResponseType(typeof(CreateVendorServiceExceptionalEventOutput))]
        [HttpPost]
        public IHttpActionResult ExceptionalEvent(CreateVendorServiceExceptionalEventInput parameters)
        {
            var op = new CreateVendorServiceExceptionalEventOperation();
            var opResult = op.Execute(parameters.Authorized());
            return Result(opResult);
        }


       // [EvantoAuthorize(Roles = "Vendor")] // TODO: Unused method
        [Route("vendor/exceptionalEventType")]
        [ResponseType(typeof(UpdateVendorServiceExceptionalEventOutput))]
        [HttpPut]
        public IHttpActionResult ExceptionalEvent(UpdateVendorServiceExceptionalEventInput parameters)
        {
            var op = new UpdateVendorServiceExceptionalEventOperation();
            var opResult = op.Execute(parameters.Authorized());
            return new CreateResult<UpdateVendorServiceExceptionalEventOutput>(opResult, Request);
        }

        #endregion

    }
}
