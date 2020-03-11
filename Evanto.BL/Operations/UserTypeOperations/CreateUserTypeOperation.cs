using Evanto.Utils;
using Evanto.Utils.Enums;
using UserType = Evanto.DAL.Context.UserType;

namespace Evanto.BL.Operations.UserTypeOperations
{
    public class CreateUserTypeOperation:Operation<CreateUserTypeInput,CreateUserTypeOutput>
    {
        public override void DoExecute()
        {
            CreateUserTypeOutput output=new CreateUserTypeOutput();
            var oldUserType = Uow.GetRepository<UserType>().GetById(Parameters.Id);
            if (oldUserType == null)
            {
                UserType usertype = Mapper.Map<CreateUserTypeInput, UserType>(this.Parameters);
                this.Uow.GetRepository<UserType>().Add(usertype);
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
