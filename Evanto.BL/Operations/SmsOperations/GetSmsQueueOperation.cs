using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Admin;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.SmsOperations
{
    public class GetSmsQueueOperation : Operation<GetSmsQueueInput, GetSmsQueueOutput>
    {
        public override void DoExecute()
        {
            GetSmsQueueOutput output = new GetSmsQueueOutput { SmsQueues = new List<SmsQueueAdminDto>() };
            var predicate = PredicateBuilder.True<SmsQueue>();
            if (this.Parameters.Id != null)
            {
                predicate = predicate.And(p => p.Id == this.Parameters.Id);
            }
            if (!string.IsNullOrEmpty(this.Parameters.Text))
            {
                predicate = predicate.And(p => p.Recipient == this.Parameters.Recipient);
            }
            if (!string.IsNullOrEmpty(this.Parameters.Description))
            {
                predicate = predicate.And(p => p.Description == this.Parameters.Description);
            }
            if (this.Parameters.StatusId != null)
            {
                predicate = predicate.And(p => p.StatusId == this.Parameters.StatusId);
            }
            var smsQueues = this.Uow.GetRepository<SmsQueue>().GetAll(predicate).ToList();
            var returnedData = Mapper.Map<List<SmsQueue>, List<SmsQueueAdminDto>>(smsQueues);
            output.SmsQueues = returnedData;
            Result.Output = output;
        }
    }
}
