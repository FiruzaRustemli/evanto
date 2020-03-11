using System;
using System.Collections.Generic;
using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.FeedbackOperations
{
    public class GetFeedbackOperation : Operation<GetFeedbackInput, GetFeedbackOutput>
    {
        public override void DoExecute()
        {
            GetFeedbackOutput output = new GetFeedbackOutput();
            output.Feedbacks = new List<FeedbackDto>();
            var predicate = PredicateBuilder.True<Feedback>();

            if(this.Parameters.Id != null)
            {
                predicate = predicate.And(f => f.Id == this.Parameters.Id);
            }
            if (this.Parameters.TypeId != null)
            {
                predicate = predicate.And(f => f.TypeId == this.Parameters.TypeId);
            }
            if (this.Parameters.StatusId != null)
            {
                predicate = predicate.And(f => f.StatusId == this.Parameters.StatusId);
            }
            if (!String.IsNullOrEmpty(this.Parameters.Subject))
            {
                predicate = predicate.And(f => f.Subject == this.Parameters.Subject);
            }
            if (!String.IsNullOrEmpty(this.Parameters.Text))
            {
                predicate = predicate.And(f => f.Text == this.Parameters.Text);
            }
            if (!String.IsNullOrEmpty(this.Parameters.Email))
            {
                predicate = predicate.And(f => f.Email == this.Parameters.Email);
            }
            if (this.Parameters.CreatedTime != DateTime.MinValue)
            {
                predicate = predicate.And(f => f.CreatedDate == this.Parameters.CreatedTime);
            }
            var feedbacks = this.Uow.GetRepository<Feedback>().GetAll(predicate).ToList();
             output.Feedbacks = Mapper.Map<List<Feedback>, List<FeedbackDto>>(feedbacks);
            Result.Output = output;
        }
    }
}
