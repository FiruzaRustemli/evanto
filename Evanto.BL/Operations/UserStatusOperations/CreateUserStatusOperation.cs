using Evanto.DAL.Context;
using Evanto.Utils;
using Evanto.Utils.Enums;

namespace Evanto.BL.Operations.UserStatusOperations
{
    public class CreateUserStatusOperation:Operation<CreateUserStatusInput,CreateUserStatusOutput>
    {
        public override void DoExecute()
        {
            CreateUserStatusOutput output=new CreateUserStatusOutput();
            var oldUserStatus = Uow.GetRepository<UserStatus>().GetById(Parameters.Id);
            if (oldUserStatus == null)
            {
                UserStatus userStatus = Mapper.Map<CreateUserStatusInput, UserStatus>(this.Parameters);
                this.Uow.GetRepository<UserStatus>().Add(userStatus);
                this.Uow.SaveChanges();
                output.IsCreated = true;
            }
            else
            {
                output.IsCreated = false;
                Result.ErrorList.Add(new Error
                {
                    Type = OperationResultCode.Exception,
                    Text = "Id is exsist",
                    Code = "400"
                });
            }
            Result.Output = output;

        }
    }
}
