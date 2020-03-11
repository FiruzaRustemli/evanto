using Evanto.DAL.Context;
using Evanto.Utils;
using Evanto.Utils.Enums;

namespace Evanto.BL.Operations.UserActivationOperations
{
    public class CreateUserActivationOperation : Operation<CreateUserActivationInput, CreateUserActivationOutput>
    {
        #region Parameters
        #endregion
        #region Constructor
        #endregion
        #region Methods
        #endregion
        public override void DoExecute()
        {
            CreateUserActivationOutput output = new CreateUserActivationOutput();

            var exisitingUserActivation =
                Uow.GetRepository<UserActivation>().GetAll(ua => ua.UserId == Parameters.UserId
                                                                 && ua.Status);

            if (exisitingUserActivation == null)
            {
                Result.ErrorList.Add(new Error()
                {
                    Type = OperationResultCode.Validation,
                    Code = "DuplicateUserActivation",
                    Text = "You have already requested reset password."
                });

                return;
            }

            UserActivation userActivation = Mapper.Map<CreateUserActivationInput, UserActivation>(this.Parameters);

            this.Uow.GetRepository<UserActivation>().Add(userActivation);
            this.Uow.SaveChanges();

            output.IsCreated = true;
            Result.Output = output;
        }
    }
}
