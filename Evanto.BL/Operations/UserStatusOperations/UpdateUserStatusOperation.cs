using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.UserStatusOperations
{
    public class UpdateUserStatusOperation:Operation<UpdateUserStatusInput,UpdateUserStatusOutput>
    {
        public override void DoExecute()
        {
            UpdateUserStatusOutput output = new UpdateUserStatusOutput();
            UserStatus userStatus = Uow.GetRepository<UserStatus>().GetById(Parameters.Id);
            userStatus=Mapper.Map(this.Parameters,userStatus);
            this.Uow.GetRepository<UserStatus>().Update(userStatus);
            this.Uow.SaveChanges();

            output.UserStatus = Mapper.Map<UserStatus,UserStatusDto>(userStatus);
            output.IsEdited = true;
            Result.Output = output;
        }
    }
}
