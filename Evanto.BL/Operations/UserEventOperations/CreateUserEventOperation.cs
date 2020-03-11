using Evanto.DAL.Context;

namespace Evanto.BL.Operations.UserEventOperations
{
    public class CreateUserEventOperation : Operation<CreateUserEventInput, CreateUserEventOutput>
    {
        public override void DoExecute()
        {
            CreateUserEventOutput output = new CreateUserEventOutput();
            UserEvent userEvent = Mapper.Map<CreateUserEventInput, UserEvent>(this.Parameters);
            this.Uow.GetRepository<UserEvent>().Add(userEvent);
            this.Uow.SaveChanges();
            output.IsCreated = true;
            Result.Output = output;
        }
    }
}
