using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Security;
using Evanto.Utils;
using Evanto.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.UserOperations
{
    public class UserValidationOperation : Operation<UserValidationInput, UserValidationOutput>
    {
        public override void DoExecute()
        {
            UserValidationOutput output = new UserValidationOutput();

            User user = this.Uow.EvantoContext.SearchUser(null,
                    Parameters.Username,
                    null, null, null, null)
                    .FirstOrDefault();


            if (user == null || !user.Password.SequenceEqual(CHashing.Hash(user.Salt, this.Parameters.Password)))
            {
                // Set error
                Result.ErrorList.Add(new Error()
                {
                    Type = OperationResultCode.Validation,
                    Code = "UsernameOrPasswordWrong",
                    Text = "Username or password is wrong."
                });

                // Return
                return;
            }

            if (user.StatusId == (byte) UserStatusValue.Blocked)
            {
                // Set error
                Result.ErrorList.Add(new Error()
                {
                    Type = OperationResultCode.Validation,
                    Code = "UserIsBlocked",
                    Text = "User is blocked"
                });

                // Return
                return;
            }

            if (user.EmailVerified == false && user.PhoneVerified == false)
            {
                // Set error
                Result.ErrorList.Add(new Error()
                {
                    Type = OperationResultCode.Validation,
                    Code = "UserAccountNotVerified",
                    Text = "User account not verified"
                });

                // Return
                return;
            }

            user.LoginCount++;
            user.LastLoginDate = DateTime.UtcNow.AddHours(4);

            output.User = Mapper.Map<User, UserValidationDto>(user);

            Result.Output = output;
        }
    }
}
