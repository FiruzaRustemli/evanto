using Evanto.DAL.Context;
using Evanto.Utils.Enums;

namespace Evanto.BL.Operations.FeedbackOperations
{
    public class UpdateFeedbackOperation : Operation<UpdateFeedbackInput, UpdateFeedbackOutput>
    {
        #region Parameters
        public int StatusId => (int)FeedbackStatusValue.New;

        #endregion
        #region Constructor
        
        #endregion

        #region Methods
        public override void DoExecute()
        {            
            UpdateFeedbackOutput output = new UpdateFeedbackOutput();
            Feedback feedback = Uow.GetRepository<Feedback>().GetById(Parameters.Id);
            feedback.StatusId = Parameters.StatusId;
            this.Uow.GetRepository<Feedback>().Update(feedback);            
            this.Uow.SaveChanges();            
            output.IsUpdated = true;
            output.Email = feedback.Email;
            Result.Output = output;
        }
        #endregion
    }
}
