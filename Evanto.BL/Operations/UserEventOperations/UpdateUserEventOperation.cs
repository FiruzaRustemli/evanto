using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.UserEventOperations
{
    public class UpdateUserEventOperation : Operation<UpdateUserEventInput, UpdateUserEventOutput>
    {
        public override void DoExecute()
        {
            UpdateUserEventOutput output = new UpdateUserEventOutput();
            UserEvent userEvent = this.Uow.GetRepository<UserEvent>()
                .Get(ue => ue.Id == this.Parameters.Id && ue.UserId == this.Parameters.CurrentUserId);
            userEvent.Budget = this.Parameters.Budget;
            userEvent.EventDate = this.Parameters.EventDate;

            this.Uow.GetRepository<UserEvent>().Update(userEvent);
            this.Uow.SaveChanges();

            output.UserEvent = Mapper.Map<UserEvent, UserEventDto>(userEvent);
            output.IsUpdated = true;
            Result.Output = output;
        }
    }
}
