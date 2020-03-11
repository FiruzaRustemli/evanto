using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evanto.DAL.Context;
using Evanto.Utils;
using Evanto.Utils.Enums;

namespace Evanto.BL.Operations.UserOperations
{
    public class VerifyUserAccountOperation : Operation<VerifyUserAccountInput, VerifyUserAccountOutput>
    {
        public override void DoExecute()
        {
            var user = Uow.GetRepository<User>().GetAll(u => u.Username == Parameters.Username).FirstOrDefault();

            if (user == null)
            {
                // Set error
                Result.ErrorList.Add(new Error()
                {
                    Type = OperationResultCode.Validation,
                    Code = "UserNotExists",
                    Text = "User does not exist"
                });

                // Return
                return;
            }

            var now = DateTime.UtcNow.AddHours(4);

            var userVerification =
                Uow.GetRepository<UserVerification>().GetAll(uv => uv.VerificationCode == Parameters.VerificationCode
                                                                   && uv.UserId == user.Id
                                                                   && uv.ExpireDate > now
                                                                   && !uv.IsVerified).FirstOrDefault();

            if (userVerification == null)
            {
                // Set error
                Result.ErrorList.Add(new Error()
                {
                    Type = OperationResultCode.Validation,
                    Code = "UserVerificationNotExists",
                    Text = "Verification code is not valid."
                });

                // Return
                return;
            }

            userVerification.ExpireDate = now;
            userVerification.IsVerified = true;
            
            Uow.GetRepository<UserVerification>().Update(userVerification);

            if (userVerification.VerificationTypeId == (byte) UserVerificationTypeValue.Email)
            {
                user.EmailVerified = true;
            }

            else if (userVerification.VerificationTypeId == (byte) UserVerificationTypeValue.Phone)
            {
                user.PhoneVerified = true;
            }

            Uow.GetRepository<User>().Update(user);

            Uow.SaveChanges();
        }
    }
}
