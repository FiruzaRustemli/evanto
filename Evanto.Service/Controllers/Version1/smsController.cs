using System.Web.Http;
using Evanto.BL.Operations.SmsOperations;
using Evanto.Service.Routing;

namespace Evanto.Service.Controllers.Version1
{
    [ApiVersion1RoutePrefix("SMS")]
    public class SmsController : BaseController
    {
        [Route("SMS/Send")]
        [HttpPost]
        public IHttpActionResult SendSms(SendSmsInput parameters)
        {
            var op = new SendSmsOperation();
            var opResult = op.Execute(parameters);
            return Result(opResult);
        }
     
    }
   
}
