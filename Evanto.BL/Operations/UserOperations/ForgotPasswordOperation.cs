using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evanto.BL.Operations.EmailOperations;
using Evanto.BL.Operations.SmsOperations;
using Evanto.BL.Operations.UserActivationOperations;
using Evanto.DAL.Context;
using Evanto.Utils;
using Evanto.Utils.Enums;

namespace Evanto.BL.Operations.UserOperations
{
    public class ForgotPasswordOperation : Operation<ForgotPasswordInput, ForgotPasswordOutput>
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
            }

            ForgotPasswordOutput output = new ForgotPasswordOutput();

            User user = null;

            if (Parameters.Email != null && Parameters.Phone == null)
            {
                user =
               this.Uow.GetRepository<User>()
                   .GetAll()
                   .FirstOrDefault(u => u.Username == Parameters.Email && u.EmailVerified == true);

                if (user == null)
                {
                    Result.ErrorList.Add(new Error()
                    {
                        Text = "Sorry, there is not a user with this email verified in our system."
                    });

                    return;
                }


                string verificationCode = CodeGenerator.GetCode(6, false);

                var sendEmailParameters = new SendEmailInput()
                {
                    Content = verificationCode,
                    EmailType = EmailType.ResetPassword,
                    Subject = "",
                    Recipient = user.Username
                };

                SendEmailOperation sendSmsOperation = new SendEmailOperation();

                var sendEmailResult = sendSmsOperation.Execute(sendEmailParameters);

                if (!sendEmailResult.IsSuccess)
                {
                    Result.ErrorList.AddRange(sendEmailResult.ErrorList);

                    return;
                }


                var createUserActivationParameters = new CreateUserActivationInput()
                {
                    UserId = user.Id,
                    Code = verificationCode,
                    ExpireDate = DateTime.UtcNow.AddHours(4).AddMonths(1),
                    Status = true
                };

                CreateUserActivationOperation createUserActivationOperation = new CreateUserActivationOperation();

                var userActivationResult = createUserActivationOperation.Execute(createUserActivationParameters);

                if (!userActivationResult.IsSuccess)
                {
                    Result.ErrorList.AddRange(userActivationResult.ErrorList);

                    return;
                }

                Result.Output = output;
            }
            
            else if (Parameters.Email == null && Parameters.Phone != null)
            {
                user = this.Uow.GetRepository<User>()
                 .GetAll()
                 .FirstOrDefault(u => u.Phone == Parameters.Phone && u.PhoneVerified == true);

                if (user == null)
                {
                    Result.ErrorList.Add(new Error()
                    {
                        Text = "Sorry, there is not a user with this phone number verified in our system."
                    });

                    return;
                }

                string verificationCode = CodeGenerator.GetCode(6, false);

                var sendSmsParameters = new SendSmsInput()
                {
                    Text = verificationCode,
                    TypeId = (byte)SmsTypeValue.ResetPassword,
                    Recipient = user.Phone
                };

                SendSmsOperation sendSmsOperation = new SendSmsOperation();

                var sendSmsResult = sendSmsOperation.Execute(sendSmsParameters);

                if (!sendSmsResult.IsSuccess)
                {
                    Result.ErrorList.Add(new Error()
                    {
                        Type = OperationResultCode.Error,
                        Text = "Sms could not be sent"
                    });

                    return;
                }


                var createUserActivationParameters = new CreateUserActivationInput()
                {
                    UserId = user.Id,
                    Code = verificationCode,
                    ExpireDate = DateTime.UtcNow.AddHours(4).AddMonths(1),
                    Status = true
                };

                CreateUserActivationOperation createUserActivationOperation = new CreateUserActivationOperation();

                var userActivationResult = createUserActivationOperation.Execute(createUserActivationParameters);

                if (!userActivationResult.IsSuccess)
                {
                    Result.ErrorList.AddRange(userActivationResult.ErrorList);

                    return;
                }

                Result.Output = output;
            }
        }
    }
}
