using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.UserOperations
{
    public class ChangeEmailUserOperation : Operation<ChangeEmailUserInput, ChangeEmailUserOutput>
    {
        #region Parameters
        #endregion

        #region Constructor
        #endregion

        #region Methods
        #endregion

        public override void DoExecute()
        {
            ChangeEmailUserOutput output = new ChangeEmailUserOutput();

            User user = this.Uow.GetRepository<User>().GetById(this.Parameters.Id);
            user.Username = this.Parameters.Username;
            this.Uow.GetRepository<User>().Update(user);
            this.Uow.SaveChanges();

            output.User = Mapper.Map<User, UserDto>(user);
            output.IsUpdated = true;
            Result.Output = output;
        }
    }
}
