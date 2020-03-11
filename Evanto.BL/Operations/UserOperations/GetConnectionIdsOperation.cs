using Evanto.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.UserOperations
{
    public class GetConnectionIdsOperation : Operation<GetConnectionIdsInput, GetConnectionIdsOutput>
    {
        public override void DoExecute()
        {
            var output = new GetConnectionIdsOutput();
            List<string> connectionIds = Uow.GetRepository<RealtimeConnection>()
                .GetAll(s => s.UserId == this.Parameters.UserId)
                .Select(s => s.ConnectionId)
                .ToList();
            output.ConnectionIds = connectionIds;
            Result.Output = output;
        }
    }
}
