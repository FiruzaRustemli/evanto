using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.UserOperations
{
    public class GetConnectionIdsInput: OperationParameters
    {
        public int UserId { get; set; }
    }

    public class GetConnectionIdsOutput
    {
        public List<string> ConnectionIds { get; set; }
    }
}
