using Evanto.BL.DTOs.User;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.UserServiceOperations
{
    public class CreateUserServiceOperationByUser : Operation<CreateUserServiceByUserInput, CreateUserServiceByUserOutput>
    {
        public override void DoExecute()
        {
            CreateUserServiceByUserOutput output = new CreateUserServiceByUserOutput();

            var existingUserService =
                this.Uow.GetRepository<UserService>()
                    .Get(s => s.UserId.Equals(Parameters.CurrentUserId) 
                    && s.ServiceId.Equals(Parameters.ServiceId)
                    && s.UserEventId.Equals(Parameters.UserEventId));

            if (existingUserService != null)
            {
                if (existingUserService.Status)
                {
                    //TODO: DO Error implemetation here
                    Result.ErrorList.Add(new Error
                    {
                        Text = "You cannot add the same service."
                    });
                    return;
                }

                existingUserService.Status = true;
                this.Uow.GetRepository<UserService>().Update(existingUserService);
                this.Uow.SaveChanges();
                output.UserService = Mapper.Map<UserServiceUserDto>(existingUserService);
                Result.Output = output;
            }
            else
            {
                UserService userService = Mapper.Map<CreateUserServiceByUserInput, UserService>(this.Parameters);
                userService.Status = true;
                this.Uow.GetRepository<UserService>().Add(userService);
                this.Uow.SaveChanges();
                output.UserService = Mapper.Map<UserServiceUserDto>(userService);
                Result.Output = output;
            }

        }
    }
}
