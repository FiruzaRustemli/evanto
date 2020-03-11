using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;
using Evanto.Service.Filters;
using Evanto.Service.Handlers;
using Evanto.Service.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Evanto.Service.Configurations
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
            ConfigureHandlers();
            ConfigureServices();
            ConfigureFormatters();
            ConfigureFilters();
        }

        private void ConfigureCors()
        {
            this.EnableCors(new EnableCorsAttribute("*", "*", "*"));
        }

        private void ConfigureRoutes()
        {
            this.MapHttpAttributeRoutes();
        }

        private void ConfigureHandlers()
        {
            MessageHandlers.Add(new CultureHandler());
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
            Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/octet-stream"));
            var json = Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            json.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
        }

        private void ConfigureFilters()
        {
            Filters.Add(new ValidationFilter());
        }
    }
}
