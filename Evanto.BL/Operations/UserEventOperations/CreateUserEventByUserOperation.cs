using Evanto.DAL.Context;

namespace Evanto.BL.Operations.UserEventOperations
{
    public class CreateUserEventByUserOperation : Operation<CreateUserEventByUserInput, CreateUserEventByUserOutput>
    {
        public override void DoExecute()
        {
            CreateUserEventByUserOutput output = new CreateUserEventByUserOutput();
            UserEvent userEvent = Mapper.Map<CreateUserEventByUserInput, UserEvent>(this.Parameters);
            userEvent.Status = true; //TODO: Setting event status active when creating
            this.Uow.GetRepository<UserEvent>().Add(userEvent);
            this.Uow.SaveChanges();
            output.Id = userEvent.Id;
            Result.Output = output;
        }
    }
}
