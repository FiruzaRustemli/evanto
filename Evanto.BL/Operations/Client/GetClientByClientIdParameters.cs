using Evanto.BL.DTOs.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.Client
{
    public class GetClientByClientIdInput : OperationParameters
    {
        public string ClientId { get; set; }
    }

    public class GetClientByClientIdOutput : OperationParameters
    {
        public ClientDto Client { get; set; }
    }
}
