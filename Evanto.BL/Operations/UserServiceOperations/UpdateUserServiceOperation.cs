using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.UserServiceOperations
{
    public class UpdateUserServiceOperation : Operation<UpdateUserServiceInput, UpdateUserServiceOutput>
    {
        public override void DoExecute()
        {
            UpdateUserServiceOutput output = new UpdateUserServiceOutput();
            UserService userService = this.Uow.GetRepository<UserService>().Get(us => us.Id == this.Parameters.Id && us.UserId == this.Parameters.CurrentUserId);
            userService = Mapper.Map(this.Parameters, userService);

            this.Uow.GetRepository<UserService>().Update(userService);
            this.Uow.SaveChanges();

            output.IsUpdated = true;
            Result.Output = output;
        }
    }
}
