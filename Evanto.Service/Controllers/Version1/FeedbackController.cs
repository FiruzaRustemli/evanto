using System.Web.Http;
using System.Web.Http.Description;
using Evanto.BL;
using Evanto.BL.Operations.FeedbackOperations;
using Evanto.BL.Operations.FeedbackTypeOperations;
using Evanto.Service.Attributes;
using Evanto.Service.Extensions;
using Evanto.Service.Helpers;
using Evanto.Service.Routing;

namespace Evanto.Service.Controllers.Version1
{
    [ApiVersion1RoutePrefix("feedbacks")]
    public class FeedbackController : BaseController
    {
        #region Common

     //   [EvantoAuthorize]
        [Route("")]
        [ResponseType(typeof(CreateFeedbackOutput))]
        [HttpPost]
        public IHttpActionResult Create([FromBody]CreateFeedbackInput parameters)
        {
            var op = new CreateFeedbackOperation();
            var opResult = op.Execute(parameters.Authorized());
            return Result(opResult);
        }

       // [EvantoAuthorize]
        [Route("types")]
        [HttpGet]
        public IHttpActionResult Get(GetFeedbackTypeInput parameters)
        {
            var op = new GetFeedbackTypeOperation();
            var opResult = op.Execute(parameters.Authorized());
            return Result(opResult);
        }

        #endregion

        #region User

        #endregion

        #region Vendor


        #endregion
    }
   
}
