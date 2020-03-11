using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.UserOperations
{
    public class DeleteRealtimeConnectionInput: OperationParameters
    {
        public string ConnectionId { get; set; }
    }

    public class DeleteRealtimeConnectionOutput
    {

    }
}
