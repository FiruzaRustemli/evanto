using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;

namespace Evanto.BL.Operations.UserActivationOperations
{
    public class UpdateUserActivationOperation : Operation<UpdateUserActivationInput, UpdateUserActivationOutput>
    {
        #region Parameters
        #endregion
        #region Constructor
        #endregion
        #region Methods
        #endregion
        public override void DoExecute()
        {
            UpdateUserActivationOutput output = new UpdateUserActivationOutput();

            UserActivation userActivation = this.Uow.GetRepository<UserActivation>().GetById(this.Parameters.Id);

            userActivation.Status = this.Parameters.Status;
            
            this.Uow.GetRepository<UserActivation>().Update(userActivation);
            this.Uow.SaveChanges();

            output.UserActivation = Mapper.Map<UserActivation, UserActivationDto>(userActivation);
            output.IsUpdated = true;
            Result.Output = output;
        }
    }
}
