using Evanto.BL.DTOs.Core;
using Evanto.BL.DTOs.User;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.UserOperations
{
    public class UpdateGeneralInfoByUserUserOperation : Operation<UpdateGeneralInfoByUserUserInput, UpdateGeneralInfoByUserUserOutput>
    {
        #region Parameters
        #endregion

        #region Constructor
        #endregion

        #region Methods

        public override void DoExecute()
        {
            UpdateGeneralInfoByUserUserOutput output = new UpdateGeneralInfoByUserUserOutput();
            User user = this.Uow.GetRepository<User>().GetById(this.Parameters.CurrentUserId);

            user = Mapper.Map(this.Parameters, user);

            this.Uow.GetRepository<User>().Update(user);
            this.Uow.SaveChanges();

            output.User = Mapper.Map<User, UserUserDto>(user);
            Result.Output = output;
        }

        #endregion
    }
}
