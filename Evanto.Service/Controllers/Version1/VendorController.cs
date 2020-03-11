using System.Web.Http;
using System.Web.Http.Description;
using Evanto.BL;
using Evanto.BL.Operations.ServicePeriodPriceOperations;
using Evanto.BL.Operations.VendorOperations;
using Evanto.BL.Operations.VendorServiceExceptionalEventOperations;
using Evanto.BL.Operations.VendorServiceOperations;
using Evanto.BL.Operations.VendorServicePacketOperation;
using Evanto.Service.Attributes;
using Evanto.Service.Extensions;
using Evanto.Service.Helpers;
using Evanto.Service.Routing;

namespace Evanto.Service.Controllers.Version1
{
    [ApiVersion1RoutePrefix("vendors")]
    public class VendorController : BaseController
    {
        #region Common

        #endregion

        #region User

       // [EvantoAuthorize(Roles = "User")]
        [Route("user")]
        [ResponseType(typeof(GetVendorByUserOutput))]
        [HttpGet]
        public IHttpActionResult Get([FromUri]GetVendorByUserInput parameters)
        {
            var op = new GetVendorByUserOperation();
            var opResult = op.Execute(parameters.Authorized());
            return Result(opResult);
        }

    //    [EvantoAuthorize(Roles = "User")]
        [Route("user/used")]
        [ResponseType(typeof(GetUsedVendorsByUserOutput))]
        [HttpGet]
        public IHttpActionResult Get([FromUri]GetUsedVendorsByUserInput parameters)
        {
            var op = new GetUsedVendorsByUserOperation();
            var opResult = op.Execute(parameters.Authorized());
            return Result(opResult);
        }

        #endregion

        #region Vendor

        [Route("vendor")]
        [ResponseType(typeof(CreateVendorOutput))]
        [HttpPost]
        public IHttpActionResult CreateVendor(CreateVendorInput input)
        {
            var op = new CreateVendorOperation();
            var opResult = op.Execute(input.Authorized());
            return Result(opResult);
        }

       // [EvantoAuthorize(Roles = "Vendor")]
        [Route("vendor/info/description")]
        [ResponseType(typeof(UpdateVendorDescriptionOutput))]
        [HttpPost]
        public IHttpActionResult UpdateVendorDescription(UpdateVendorDescriptionInput input)
        {
            var op = new UpdateVendorDescriptionOperation();
            var opResult = op.Execute(input.Authorized());
            return Result(opResult);
        }

       // [EvantoAuthorize(Roles = "Vendor")]
        [Route("vendor/info/basic")]
        [ResponseType(typeof(UpdateVendorBasicInformationOutput))]
        [HttpPost]
        public IHttpActionResult UpdateVendorBasicInformation(UpdateVendorBasicInformationInput input)
        {
            var op = new UpdateVendorBasicInformationOperation();
            var opResult = op.Execute(input.Authorized());
            return Result(opResult);
        }

      //  [EvantoAuthorize(Roles = "Vendor")]
        [Route("vendor/info/contact")]
        [ResponseType(typeof(UpdateVendorContactInformationsOutput))]
        [HttpPost]
        public IHttpActionResult UpdateVendorContactInformations(UpdateVendorContactInformationsInput input)
        {
            var op = new UpdateVendorContactInformationsOperation();
            var opResult = op.Execute(input.Authorized());
            return Result(opResult);
        }

   //     [EvantoAuthorize(Roles = "Vendor")]
        [Route("vendor")]
        [ResponseType(typeof(GetVendorByIdByVendorOutput))]
        [HttpGet]
        public IHttpActionResult GetById([FromUri]GetVendorByIdByVendorInput parameters)
        {
            var op = new GetVendorByIdByVendorOperation();
            var opResult = op.Execute(parameters.Authorized());
            return Result(opResult);
        }

    //    [EvantoAuthorize(Roles = "Vendor")]
        [Route("vendor")]
        [ResponseType(typeof(UpdateVendorOutput))]
        [HttpPut]
        public IHttpActionResult Post(UpdateVendorInput parameters)
        {
            var op = new UpdateVendorOperation();
            var opResult = op.Execute(parameters.Authorized());
            return Result(opResult);
        }

     //   [EvantoAuthorize(Roles = "Vendor")]
        [Route("vendorServices")]
        [ResponseType(typeof(GetActiveVendorServicesByVendorOutput))]
        [HttpGet]
        public IHttpActionResult Post([FromUri]GetActiveVendorServicesByVendorInput parameters)
        {
            var op = new GetActiveVendorServicesByVendorOperation();
            var opResult = op.Execute(parameters.Authorized());
            return Result(opResult);
        }


      //  [EvantoAuthorize(Roles = "Vendor")]
        [Route("vendorServices")]
        [ResponseType(typeof(UpdateVendorServiceOutput))]
        [HttpPut]
        public IHttpActionResult UpdateVendorService(UpdateVendorServiceInput input)
        {
            var op = new UpdateVendorServiceOperation();
            var opResult = op.Execute(input.Authorized());
            return Result(opResult);
        }

        #endregion
    }
}
