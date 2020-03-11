using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using static Evanto.Service.Helpers.SupportedLanguages;

namespace Evanto.Service.Handlers
{
    public class CultureHandler : DelegatingHandler
    {
        private readonly List<string> _supportedlangs = GetSupportedLanguagesNocCodes();

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            SetCulture(request);
            var response = await base.SendAsync(request, cancellationToken);
            return response;
        }

        private void SetCulture(HttpRequestMessage request)
        {
            var selectedLang = request.Headers.AcceptLanguage.FirstOrDefault();

            selectedLang = ((selectedLang == null) || (!_supportedlangs.Contains(selectedLang.Value)))
                                ? new System.Net.Http.Headers.StringWithQualityHeaderValue(_supportedlangs.FirstOrDefault())
                                : selectedLang;

            Thread.CurrentThread.CurrentCulture = new CultureInfo(selectedLang.Value);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLang.Value);
        }
    }
}