using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.UserOperations
{
    public class ChangeStatusUserOperation : Operation<ChangeStatusUserInput, ChangeStatusUserOutput>
    {
        #region Parameters
        #endregion

        #region Constructor
        #endregion

        #region Methods
        #endregion

        public override void DoExecute()
        {
            ChangeStatusUserOutput output = new ChangeStatusUserOutput();
            User user = this.Uow.GetRepository<User>().GetById(this.Parameters.Id);
            user.StatusId = this.Parameters.StatusId;
            this.Uow.GetRepository<User>().Update(user);
            this.Uow.SaveChanges();

            output.User = Mapper.Map<User, UserDto>(user);
            output.IsUpdated = true;
            Result.Output = output;
        }
    }
}
