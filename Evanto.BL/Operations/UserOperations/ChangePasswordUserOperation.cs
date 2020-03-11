using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Security;
using Evanto.Utils;

namespace Evanto.BL.Operations.UserOperations
{
    public class ChangePasswordUserOperation : Operation<ChangePasswordUserInput, ChangePasswordUserOutput>
    {
        #region Parameters
        #endregion

        #region Constructor
        #endregion

        #region Methods
        #endregion

        public override void DoExecute()
        {
            ChangePasswordUserOutput output = new ChangePasswordUserOutput();

            User user = this.Uow.GetRepository<User>().GetById(this.Parameters.CurrentUserId);

            if (!CHashing.Equals(user.Salt, this.Parameters.CurrentPassword, user.Password))
            {
                Result.ErrorList.Add(new Error
                {
                    Text = "Please enter your current password correct."
                });

                return;
            }

            if (this.Parameters.CurrentPassword == this.Parameters.NewPassword)
            {
                Result.ErrorList.Add(new Error
                {
                    Text = "Please enter new password as different from the current one."
                });

                return;
            }

            user.Password = CHashing.Hash(user.Salt, this.Parameters.NewPassword);
            this.Uow.GetRepository<User>().Update(user);
            this.Uow.SaveChanges();


            Result.Output = output;
        }
    }
}
