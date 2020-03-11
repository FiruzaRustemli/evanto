using Evanto.DAL.Context;
using Evanto.Security;

namespace Evanto.BL.Operations.UserOperations
{
    public class ResetPasswordbyAdminUserOperation : Operation<ResetPasswordbyAdminUserInput, ResetPasswordbyAdminUserOutput>
    {
        #region Parameters
        #endregion

        #region Constructor
        #endregion

        #region Methods
        #endregion

        public override void DoExecute()
        {
            ResetPasswordbyAdminUserOutput output = new ResetPasswordbyAdminUserOutput();

            User user = this.Uow.GetRepository<User>().GetById(this.Parameters.Id);

            // generate new password here 
            user.Password = CHashing.Hash(user.Salt, this.Parameters.NewPassword);
            Uow.GetRepository<User>().Update(user);
            this.Uow.SaveChanges();
                output.IsCreated = true;
            Result.Output = output;
        }
    }
}
