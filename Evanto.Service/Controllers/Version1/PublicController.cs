using Evanto.Service.Routing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Evanto.BL.Operations.BookingOperations;
using Evanto.BL.Operations.PaymentOperations;
using Evanto.BL.Operations.PublicOperations;
using Evanto.BL.Operations.UserOperations;
using Evanto.Service.Attributes;
using Evanto.Service.Extensions;

namespace Evanto.Service.Controllers.Version1
{
    [ApiVersion1RoutePrefix("public")]
    public class PublicController : BaseController
    {
        #region Common

        #endregion

        #region User

        [Route("services")]
        [ResponseType(typeof(GetAllServicesOutput))]
        [HttpGet]
        public IHttpActionResult Get([FromUri] GetAllServicesInput parameters)
        {
            var op = new GetAllServicesOperation();
            var opResult = op.Execute(parameters);
            return Result(opResult);
        }

        [Route("eventTypes")]
        [ResponseType(typeof(GetAllEventTypesOutput))]
        [HttpGet]
        public IHttpActionResult Get([FromUri] GetAllEventTypesInput parameters)
        {
            var op = new GetAllEventTypesOperation();
            var opResult = op.Execute(parameters);
            return Result(opResult);
        }

        [Route("vendorServices")]
        [ResponseType(typeof(GetAllVendorServicesOutput))]
        [HttpGet]
        public IHttpActionResult Get([FromUri] GetAllVendorServicesInput parameters)
        {
            var op = new GetAllVendorServicesOperation();
            var opResult = op.Execute(parameters);
            return Result(opResult);
        }

        [Route("vendorService")]
        [ResponseType(typeof(GetVendorServiceOutput))]
        [HttpGet]
        public IHttpActionResult GetById([FromUri] GetVendorServiceInput parameters)
        {
            var op = new GetVendorServiceOperation();
            var opResult = op.Execute(parameters);
            return Result(opResult);
        }

        [Route("images/vendorService")]
        [CheckModelForNull]
        [ResponseType(typeof(GetVendorServiceImageOutput))]
        [HttpGet]
        public IHttpActionResult Get([FromUri] GetVendorServiceImageInput parameters)
        {
            var op = new GetVendorServiceImageOperation();
            var opResult = op.Execute(parameters);
            return Result(opResult);
        }

        #endregion

        #region Vendor


        #endregion
    }
}
