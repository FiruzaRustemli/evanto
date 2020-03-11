using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.Service.Helpers
{
    public static class SupportedLanguages
    {
        public static List<string> GetSupportedLanguagesNocCodes()
        {
            return new List<string>
            {
                "en",
                "az",
                "ru"
            };
        }
    }
}
