using System;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Utils.Enums;

namespace Evanto.BL.Operations.FeedbackOperations
{
    public class CreateFeedbackOperation : Operation<CreateFeedbackInput, CreateFeedbackOutput>
    {
        #region Parameters
        public int StatusId {
            get {
                return (int)FeedbackStatusValue.New;
            }
        }
        #endregion
        #region Constructor
        
        #endregion

        #region Methods
        public override void DoExecute()
        {            
            CreateFeedbackOutput output = new CreateFeedbackOutput();
            FeedbackDto feedbackDtoInput = new FeedbackDto
            {
                StatusId = StatusId,
                Subject = this.Parameters.Subject,
                Text = this.Parameters.Text,
                TypeId = this.Parameters.TypeId,
                Email = this.Parameters.Email
            };
            var feedback = Mapper.Map<FeedbackDto, Feedback>(feedbackDtoInput);
            feedback.CreatedDate = DateTime.UtcNow;                     
            this.Uow.GetRepository<Feedback>().Add(feedback);            
            this.Uow.SaveChanges();            
            output.IsCreated = true;
            Result.Output = output;
        }
        #endregion
    }
}
