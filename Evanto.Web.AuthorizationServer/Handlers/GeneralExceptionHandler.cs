using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace Evanto.Service.Handlers
{
    public class GeneralExceptionHandler : IExceptionHandler
    {
        public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            context.Result = new InternalServerErrorResult(context.Request);
            return Task.FromResult(0);
        }
    }
}