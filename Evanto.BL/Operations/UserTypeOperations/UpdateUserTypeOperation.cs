using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.UserTypeOperations
{
    public class UpdateUserTypeOperation:Operation<UpdateUserTypeInput,UpdateUserTypeOutput>
    {
        public override void DoExecute()
        {
            UpdateUserTypeOutput output = new UpdateUserTypeOutput();
            UserType userType = Uow.GetRepository<UserType>().GetById(Parameters.Id);
            userType=Mapper.Map(this.Parameters,userType);
            this.Uow.GetRepository<UserType>().Update(userType);
            this.Uow.SaveChanges();

            output.UserType = Mapper.Map<UserType, UserTypeDto>(userType);
            output.IsEdited = true;
            Result.Output = output;
        }
    }
}
