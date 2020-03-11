using Evanto.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.UserOperations
{
    public class CreateRealtimeConnectionOperation : Operation<CreateRealtimeConnectionInput, CreateRealtimeConnectionOutput>
    {
        public override void DoExecute()
        {
            RealtimeConnection realtimeConnection = new RealtimeConnection();
            realtimeConnection.UserId = this.Parameters.UserId;
            realtimeConnection.ConnectionId = this.Parameters.ConnectionId;

            Uow.GetRepository<RealtimeConnection>().Add(realtimeConnection);
            Uow.SaveChanges();
        }
    }
}
