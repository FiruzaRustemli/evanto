using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Security;
using Evanto.BL;
using Evanto.BL.Operations.EventServiceOperations;
using Evanto.BL.Operations.ServiceOperations;
using Evanto.BL.Operations.ServicePeriodPriceOperations;
using Evanto.BL.Operations.UserServiceOperations;
using Evanto.BL.Operations.VendorServiceExceptionalEventOperations;
using Evanto.BL.Operations.VendorServiceOperations;
using Evanto.BL.Operations.VendorServicePacketOperation;
using Evanto.Service.Attributes;
using Evanto.Service.Extensions;
using Evanto.Service.Helpers;
using Evanto.Service.Routing;

namespace Evanto.Service.Controllers.Version1
{
    [ApiVersion1RoutePrefix("services")]
    public class ServiceController : BaseController
    {
        #region Common

        #endregion

        #region User

        //[EvantoAuthorize(Roles = "User")]
        [Route("user")]
        [ResponseType(typeof(GetServiceByUserOutput))]
        [HttpGet]

        public IHttpActionResult GetByUser(GetServiceByUserInput parameters)
        {
            var op = new GetServiceByUserOperation();
            var opResult = op.Execute(parameters.Authorized());;
            return Result(opResult);
        }

        //[EvantoAuthorize(Roles = "User")]
        [Route("user/vendorServices")]
        [ResponseType(typeof(GetVendorServiceByUserOutput))]
        [HttpGet]
        public IHttpActionResult Get([FromUri]GetVendorServiceByUserInput parameters)
        {
            var op = new GetVendorServiceByUserOperation();
            var opResult = op.Execute(parameters.Authorized());
            return Result(opResult);
        }

        //[EvantoAuthorize(Roles = "User")]
        [Route("user/topVendorServices")]
        [ResponseType(typeof(GetTopVendorServicesByUserOutput))]
        [HttpGet]
        public IHttpActionResult Get([FromUri]GetTopVendorServicesByUserInput parameters)
        {
            var op = new GetTopVendorServicesByUserOperation();
            var opResult = op.Execute(parameters.Authorized());;
            return Result(opResult);
        }

  //    [EvantoAuthorize(Roles = "User")]
        [Route("user/userService")]
        [ResponseType(typeof(CreateUserServiceByUserOutput))]
        [HttpPost]
        public IHttpActionResult UserService(CreateUserServiceByUserInput input)
        {
            var op = new CreateUserServiceOperationByUser();
            var opResult = op.Execute(input.Authorized());
            return Result(opResult);
        }

      //[EvantoAuthorize(Roles = "User")]
        [Route("user/userService")]
        [ResponseType(typeof(GetUserServiceByUserOutput))]
        [HttpGet]
        public IHttpActionResult UserService([FromUri]GetUserServiceByUserInput input)
        {
            var op = new GetUserServiceByUserOperation();
            var opResult = op.Execute(input.Authorized());
            return Result(opResult);
        }

        //[EvantoAuthorize(Roles = "User")]
        [Route("user/userService")]
        [ResponseType(typeof(UpdateUserServiceOutput))]
        [HttpPut]
        public IHttpActionResult UserService(UpdateUserServiceInput input)
        {
            var op = new UpdateUserServiceOperation();
            var opResult = op.Execute(input.Authorized());
            return Result(opResult);
        }

        //[EvantoAuthorize(Roles = "User")]
        [Route("user/eventServices")]
        [ResponseType(typeof(GetEventServiceByUserOutput))]
        [HttpGet]
        public IHttpActionResult GetByUser([FromUri]GetEventServiceByUserInput parameters)
        {
            var op = new GetEventServiceByUserOperation();
            var opResult = op.Execute(parameters.Authorized());
            return Result(opResult);
        }

        #endregion

        #region Vendor

        [EvantoAuthorize(Roles = "Vendor")]
        [Route("vendor/servicePacket")]
        [ResponseType(typeof(GetVendorServicePacketByVendorOutput))]
        [HttpPost]
        public IHttpActionResult GetVendorServicePacketsByVendor([FromUri]GetVendorServicePacketByVendorInput input)
        {
            var op = new GetVendorServicePacketByVendorOperation();
            var opResult = op.Execute(input.Authorized());
            return new CreateResult<GetVendorServicePacketByVendorOutput>(opResult, Request);
        }

        [EvantoAuthorize(Roles = "Vendor")] // TODO: Temporarily unused method.
        [Route("vendor/servicePacket/deactivate")]
        [ResponseType(typeof(DeactivateStatusVSPByVendorOutput))]
        [HttpPost]
        public IHttpActionResult DeactivateStatusVSPByVendor(DeactivateStatusVSPByVendorInput parameters)
        {
            var op = new DeactivateStatusVCPByVendorOperation();
            var opResult = op.Execute(parameters.Authorized());
            return Result(opResult);
        }

        [EvantoAuthorize(Roles = "Vendor")]
        [Route("vendor/services/changeStatus")]
        [ResponseType(typeof(ChangeStatusVendorServiceByVendorOutput))]
        [HttpPost]
        public IHttpActionResult ChangeStatusVendorServiceByVendor(ChangeStatusVendorServiceByVendorInput parameters)
        {
            var op = new ChangeStatusVendorServiceByVendorOperation();
            var opResult = op.Execute(parameters.Authorized());
            return Result(opResult);
        }

        [EvantoAuthorize(Roles = "Vendor")]
        [Route("vendor/services")]
        [ResponseType(typeof(GetVendorServiceByVendorOutput))]
        [HttpGet]
        public IHttpActionResult GetVendorServicesByVendor([FromUri]GetVendorServiceByVendorInput parameters)
        {
            var op = new GetVendorServiceByVendorOperation();
            var opResult = op.Execute(parameters.Authorized());
            return Result(opResult);
        }

        [EvantoAuthorize(Roles = "Vendor")]
        [Route("vendor/servicePeriodPrice")]
        [ResponseType(typeof(GetServicePeriodPriceOutput))]
        [HttpGet]
        public IHttpActionResult GetServicePeriodPrice([FromUri]GetServicePeriodPriceInput input)
        {
            var op = new GetServicePeriodPriceOperation();
            var opResult = op.Execute(input.Authorized());
            return Result(opResult);
        }

        [EvantoAuthorize(Roles = "Vendor")]
        [Route("vendor/services")]
        [ResponseType(typeof(AddVendorServicesOutput))]
        [HttpPost]
        public IHttpActionResult AddVendorServices(AddVendorServicesInput parameters)
        {
            var op = new AddVendorServicesOperation();
            var opResult = op.Execute(parameters.Authorized());
            return Result(opResult);
        }

        [EvantoAuthorize(Roles = "Vendor")]
        [Route("vendor/servicePacket")]
        [ResponseType(typeof(GetVendorServicePacketOutput))]
        [HttpGet]
        public IHttpActionResult GetVendorServicePackets([FromUri] GetVendorServicePacketInput input)
        {
            var op = new GetVendorServicePacketOperation();
            var opResult = op.Execute(input.Authorized());
            return Result(opResult);
        }

        [EvantoAuthorize(Roles = "Vendor")]
        [Route("vendor/vendorService")]
        [ResponseType(typeof(GetVendorServiceByIdByVendorOutput))]
        [HttpGet]
        public IHttpActionResult GetVendorServiceByIdByVendor([FromUri] GetVendorServiceByIdByVendorInput input)
        {
            var op = new GetVendorServiceByIdByVendorOperation();
            var opResult = op.Execute(input.Authorized());
            return Result(opResult);
        }


        #endregion
    }
}
