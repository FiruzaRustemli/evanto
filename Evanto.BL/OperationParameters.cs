using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Evanto.BL
{
    public class OperationParameters
    {
        [JsonProperty(Required = Required.Default)]
        public virtual int CurrentUserId { get; set; }
    }
}
