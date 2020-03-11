using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.UserOperations
{
    public class CreateRealtimeConnectionInput: OperationParameters
    {
        public int UserId { get; set; }
        public string ConnectionId { get; set; }
    }

    public class CreateRealtimeConnectionOutput
    {
    }
}
