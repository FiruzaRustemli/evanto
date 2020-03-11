using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Hosting;
using Evanto.BL;
using Evanto.Utils.Enums;

namespace Evanto.Service.Helpers
{
    public class CreateResult<TResult> : IHttpActionResult where TResult : class
    {
        private readonly HttpStatusCode _statusCode;
        private readonly OperationResult<TResult> _result;
        private readonly HttpRequestMessage _request;

        public CreateResult(OperationResult<TResult> result, HttpRequestMessage request)
        {
            _result = result;
            _request = request;
            _statusCode = (result.ErrorList.Exists(error => result.ErrorList.Count > 0))
                ? HttpStatusCode.BadRequest
                : HttpStatusCode.OK;
        }

        public HttpResponseMessage CreateResponse(HttpStatusCode statusCode, OperationResult<TResult> result)
        {   
            var response = _request.CreateResponse(statusCode, result);
            return response;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(CreateResponse(_statusCode, _result));
        }
    }
}
