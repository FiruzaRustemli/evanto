using Evanto.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.UserOperations
{
    public class DeleteRealtimeConnectionOperation : Operation<DeleteRealtimeConnectionInput, DeleteRealtimeConnectionOutput>
    {
        public override void DoExecute()
        {
            RealtimeConnection realtimeConnection = Uow.GetRepository<RealtimeConnection>()
                .Get(s => s.ConnectionId == this.Parameters.ConnectionId);
            if(realtimeConnection != null)
            {
                Uow.GetRepository<RealtimeConnection>().Delete(realtimeConnection);
                Uow.SaveChanges();
            }
        }
    }
}
