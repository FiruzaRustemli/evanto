using Evanto.BL.DTOs.Admin;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.UserVerificationOperations
{
    public class UpdateUserVerificationOperation : Operation<UpdateUserVerificationInput, UpdateUserVerificationOutput>
    {
        #region Parameters
        #endregion
        #region Constructor
        #endregion
        #region Methods
        #endregion
        public override void DoExecute()
        {
            UpdateUserVerificationOutput output = new UpdateUserVerificationOutput();

            UserVerification userVerification = this.Uow.GetRepository<UserVerification>().GetById(this.Parameters.Id);

            userVerification.IsVerified = this.Parameters.IsVerified;
            
            this.Uow.GetRepository<UserVerification>().Update(userVerification);
            this.Uow.SaveChanges();

            output.UserVerification = Mapper.Map<UserVerification, UserVerificationAdminDto>(userVerification);
            output.IsUpdated = true;
            Result.Output = output;
        }
    }
}
