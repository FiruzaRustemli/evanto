using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evanto.DAL.Context;
using Evanto.Security;
using Evanto.Utils;
using Evanto.Utils.Enums;

namespace Evanto.BL.Operations.UserOperations
{
    public class ResetPasswordByUserOperation : Operation<ResetPasswordByUserInput, ResetPasswordByUserOutput>
    {
        public override void DoExecute()
        {
            if (Parameters?.Phone == null && Parameters?.Email == null)
            {
                Result.ErrorList.Add(new Error()
                {
                    Type = OperationResultCode.Validation,
                    Text = "Please provide email or phone number."
                });

                return;
            }
            

            ResetPasswordByUserOutput ouput = new ResetPasswordByUserOutput();

            User user = null;

            if (Parameters.Email != null && Parameters.Phone == null)
            {
                user =
                    this.Uow.GetRepository<User>()
                        .GetAll()
                        .FirstOrDefault(u => u.Username == Parameters.Email);

            }

            else if (Parameters.Email == null && Parameters.Phone != null)
            {
                user =
                    this.Uow.GetRepository<User>()
                        .GetAll()
                        .FirstOrDefault(u => u.Username == Parameters.Phone);

            }

            if (user == null)
            {
                Result.ErrorList.Add(new Error()
                {
                    Text = "Sorry, user does not exist in our system."
                });

                return;
            }

            var now = DateTime.UtcNow.AddHours(4);

            var userActivation = Uow.GetRepository<UserActivation>().GetAll(ua => ua.UserId == user.Id
                                                                                 && ua.Status
                                                                                 && ua.ExpireDate > now
                                                                                 && ua.Code == Parameters.Code).FirstOrDefault();
            if (userActivation == null)
            {
                Result.ErrorList.Add(new Error()
                {
                    Text = "Code expired or does not exist."
                });

                return;
            }

            user.Password = CHashing.Hash(user.Salt, Parameters.NewPassword);           
            Uow.GetRepository<User>().Update(user);

            userActivation.ExpireDate = DateTime.UtcNow.AddHours(4);
            userActivation.Status = false;
            Uow.GetRepository<UserActivation>().Update(userActivation);

            Uow.SaveChanges();

            Result.Output = ouput;
        }
    }
}
