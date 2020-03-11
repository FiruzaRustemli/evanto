using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.FeedbackTypeOperations
{
    public class GetFeedbackTypeOperation : Operation<GetFeedbackTypeInput,GetFeedbackTypeOutput>
    {
        public override void DoExecute()
        {
            GetFeedbackTypeOutput output = new GetFeedbackTypeOutput();
            var feedbackTypes = this.Uow.GetRepository<FeedbackType>().GetAll(ft => ft.Status).ToList();

            output.FeedbackTypes = Mapper.Map<List<FeedbackType>, List<FeedbackTypeDto>>(feedbackTypes);
            Result.Output = output;
        }
    }
    

}
