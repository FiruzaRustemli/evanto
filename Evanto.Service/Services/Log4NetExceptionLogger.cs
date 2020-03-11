using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.ExceptionHandling;
using log4net;

namespace Evanto.Service.Services
{
    public class Log4NetExceptionLogger : ExceptionLogger
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(Log4NetExceptionLogger));
         
        public override async Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken)
        {
            var content = await context.Request.Content.ReadAsStringAsync();
            _logger.Fatal(
                            $"{Environment.NewLine}" +
                            "Unhandled Exception! Exception: " +  //TODO: Exception must be illustrative!!
                            $"{Environment.NewLine}" +
                            $"{context.Exception}," +
                            $"{Environment.NewLine}" +
                            $"Method: {context.Request.Method}" +
                            $"{Environment.NewLine}" +
                            $"Content: {content}" +
                            $"{Environment.NewLine}" +
                            $"Uri: {context.Request.RequestUri}" +
                            $"{Environment.NewLine}" +
                            $"Headers: {context.Request.Headers}" +
                            $"{Environment.NewLine}" +
                            $"Properties: {context.Request.Properties}"
                        );
        }

        public override void Log(ExceptionLoggerContext context)
        {
            var content = context.Request.Content.ReadAsStringAsync();
            _logger.Fatal(
                           $"{Environment.NewLine}," +
                           "Unhandled Exception! Exception: " +
                          $"{Environment.NewLine}" +
                            $"{context.Exception}," +
                            $"{Environment.NewLine}" +
                            $"Method: {context.Request.Method}" +
                            $"{Environment.NewLine}" +
                            $"Content: {content}" +
                            $"{Environment.NewLine}" +
                            $"Uri: {context.Request.RequestUri}" +
                            $"{Environment.NewLine}" +
                            $"Headers: {context.Request.Headers}" +
                            $"{Environment.NewLine}" +
                            $"Properties: {context.Request.Properties}"
                        );
        }
    }
}