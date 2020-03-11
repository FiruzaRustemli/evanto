using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.Client
{
    public class ClientValidationInput : OperationParameters
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }
    }

    public class ClientValidationOutput : OperationParameters
    {
        public bool IsValid { get; set; } = false;
    }
}
