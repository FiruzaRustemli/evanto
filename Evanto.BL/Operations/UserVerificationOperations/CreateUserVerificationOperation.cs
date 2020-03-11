using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evanto.BL.Operations.EmailOperations;
using Evanto.BL.Operations.SmsOperations;
using Evanto.DAL.Context;
using Evanto.Utils;
using Evanto.Utils.Enums;

namespace Evanto.BL.Operations.UserVerificationOperations
{
    public class CreateUserVerificationOperation : Operation<CreateUserVerificationInput, CreateUserVerificationOutput>
    {
        public override void DoExecute()
        {
            var existingUserVerification =
                Uow.GetRepository<UserVerification>().GetAll(uv => uv.UserId == Parameters.UserId
                                                                   && !uv.IsVerified
                                                                   &&
                                                                   uv.VerificationTypeId ==
                                                                   Parameters.VerificationTypeId);

            if (existingUserVerification == null)
            {
                Result.ErrorList.Add(new Error()
                {
                    Type = OperationResultCode.Information,
                    Code = "DuplicateUserVerification",
                    Text = "You have sent a code once."
                });
            }

            CreateUserVerificationOutput output = new CreateUserVerificationOutput();

            var userVerification = new UserVerification()
            {
                UserId = Parameters.UserId,
                VerificationCode = Parameters.VerificationCode,
                VerificationTypeId = Parameters.VerificationTypeId,
                ExpireDate = Parameters.ExpireDate,
                IsVerified = false
            };

            if (Parameters.VerificationTypeId == (int) UserVerificationTypeValue.Phone)
            {
                var smsVerificationResult = SendSmsVerificationMessage(userVerification);
                if (!smsVerificationResult.IsSuccess)
                {
                    Result.ErrorList.Add(new Error()
                    {
                        Type = OperationResultCode.Error,
                        Text = "Sms could not be sent"
                    });
                }
                else
                {
                    Uow.GetRepository<UserVerification>().Add(userVerification);
                    Uow.SaveChanges();
                }
            }

            else if (Parameters.VerificationTypeId == (int) UserVerificationTypeValue.Email)
            {
                var emailVerificationResult = SendEmailVerificationMessage(userVerification);

                if (!emailVerificationResult.IsSuccess)
                {
                    Result.ErrorList.AddRange(emailVerificationResult.ErrorList);
                }
                else
                {
                    Uow.GetRepository<UserVerification>().Add(userVerification);
                    Uow.SaveChanges();
                }
            }

            Result.Output = output;
        }

        public OperationResult<SendSmsOutput> SendSmsVerificationMessage(UserVerification userVerification)
        {
            var sendSmsParameters = new SendSmsInput()
            {
                TypeId = (int) SmsTypeValue.Verification,
                Text = userVerification.VerificationCode,
                Recipient = Parameters.PhoneNumber
            };

            SendSmsOperation sendSmsOperation = new SendSmsOperation();

            var result = sendSmsOperation.Execute(sendSmsParameters);

            return result;
        }

        public OperationResult<SendEmailOutput> SendEmailVerificationMessage(UserVerification userVerification)
        {
            var sendEmailParameters = new SendEmailInput()
            {
                EmailType = EmailType.Verification,
                Content = userVerification.VerificationCode,
                Recipient = Parameters.Email,
                Subject = ""
            };

            SendEmailOperation sendEmailOperation = new SendEmailOperation();

            var result = sendEmailOperation.Execute(sendEmailParameters);

            return result;
        }
    }
}
