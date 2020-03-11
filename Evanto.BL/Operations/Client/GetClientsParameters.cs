using Evanto.BL.DTOs.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.Client
{
    public class GetClientsInput : OperationParameters
    {
    }

    public class GetClientsOutput : OperationParameters
    {
        public List<ClientDto> Clients { get; set; }
    }
}
