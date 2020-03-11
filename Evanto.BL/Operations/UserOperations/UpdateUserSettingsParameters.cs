using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Core;
using Newtonsoft.Json;

namespace Evanto.BL.Operations.UserOperations
{
    public class UpdateUserSettingsInput : OperationParameters
    {
        [MinLength(2)]
        [MaxLength(2)]
        public string LangCode { get; set; }

        [JsonProperty(Required = Required.Default)]
        public int LangId { get; set; }

        public string Theme { get; set; }
    }
    public class UpdateUserSettingsOutput
    {
    } 
}
