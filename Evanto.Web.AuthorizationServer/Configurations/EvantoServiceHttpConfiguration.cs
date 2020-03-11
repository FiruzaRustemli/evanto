using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;
using Evanto.Service.Handlers;
using Evanto.Service.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Evanto.Web.AuthorizationServer.Configurations
{
    /// <summary>
    /// Evanto API Http configurations.
    /// </summary>
    public class EvantoServiceHttpConfiguration : HttpConfiguration
    {
        public EvantoServiceHttpConfiguration()
        {
            ConfigureCors();
            ConfigureRoutes();
            ConfigureServices();
            ConfigureFormatters();
        }

        private void ConfigureCors()
        {
            this.EnableCors(new EnableCorsAttribute("*", "*", "*"));
        }

        private void ConfigureRoutes()
        {
            this.MapHttpAttributeRoutes();
        }

        private void ConfigureServices()
        {
            Services.Replace(typeof(IExceptionLogger), new Log4NetExceptionLogger());
            Services.Replace(typeof(IExceptionHandler), new GeneralExceptionHandler());
        }

        private void ConfigureFormatters()
        {
            Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            Formatters.JsonFormatter.MediaTypeMappings
                .Add(new QueryStringMapping("type", "json", new MediaTypeHeaderValue("application/json")));
            var json = Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            json.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
        }
    }
}
