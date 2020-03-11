using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.FeedbackStatusOperations
{
    public class GetFeedbackStatusOperation : Operation<GetFeedbackStatusInput, GetFeedbackStatusOutput>
    {
        public override void DoExecute()
        {
            GetFeedbackStatusOutput output = new GetFeedbackStatusOutput { FeedbackStatuses = new List<FeedbackStatusDto>() };
            var predicate = PredicateBuilder.True<DAL.Context.FeedbackStatus>();
            var feedbackStatuses = this.Uow.GetRepository<DAL.Context.FeedbackStatus>().GetAll(predicate).ToList();
            output.FeedbackStatuses = Mapper.Map<List<FeedbackStatus>, List<FeedbackStatusDto>>(feedbackStatuses);
            Result.Output = output;
        }
    }


}
