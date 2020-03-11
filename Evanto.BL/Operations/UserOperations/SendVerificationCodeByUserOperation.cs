using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evanto.BL.Operations.UserVerificationOperations;
using Evanto.DAL.Context;
using Evanto.Utils;
using Evanto.Utils.Enums;

namespace Evanto.BL.Operations.UserOperations
{
    public class SendVerificationCodeByUserOperation : Operation<SendVerificationCodeByUserInput, SendVerificationCodeByUserOutput>
    {
        public override void DoExecute()
        {
            SendVerificationCodeByUserOutput output = new SendVerificationCodeByUserOutput();

            // User authenticated
            if (Parameters.CurrentUserId != 0)
            {
                var user = Uow.GetRepository<User>().GetById(Parameters.CurrentUserId);

                var userVerificationparameters = new CreateUserVerificationInput()
                {
                    VerificationTypeId = Parameters.VerificationType,
                    UserId = user.Id,
                    VerificationCode = CodeGenerator.GetCode(6, false),
                    PhoneNumber = user.Phone,
                    Email = user.Username,
                    ExpireDate = DateTime.UtcNow.AddHours(4).AddMonths(1)
                };

                CreateUserVerificationOperation createUserVerificationOperation = new CreateUserVerificationOperation();
                var userVerificationResult = createUserVerificationOperation.Execute(userVerificationparameters);

                if (!userVerificationResult.IsSuccess)
                {
                    Result.ErrorList.AddRange(userVerificationResult.ErrorList);
                }
            }
            else
            {
                if ((Parameters.Phone == null && Parameters.Email == null) || (Parameters.Phone != null && Parameters.Email != null))
                {
                    Result.ErrorList.Add(new Error()
                    {
                        Type = OperationResultCode.Validation,
                        Text = "Please define email or phone number."
                    });

                    return;
                }
                if (Parameters.Phone != null && Parameters.VerificationType == (byte)UserVerificationTypeValue.Phone)
                {
                    var user = Uow.GetRepository<User>().Get(u => u.Phone == Parameters.Phone);

                    if (user == null)
                    {
                        Result.ErrorList.Add(new Error()
                        {
                            Type = OperationResultCode.Error,
                            Text = "User is not found with this phone number."
                        });

                        return;
                    }

                    if (user.PhoneVerified == true)
                    {
                        Result.ErrorList.Add(new Error()
                        {
                            Type = OperationResultCode.Error,
                            Text = "You have already verified your phone number."
                        });

                        return;
                    }

                    var userVerificationparameters = new CreateUserVerificationInput()
                    {
                        VerificationTypeId = Parameters.VerificationType,
                        UserId = user.Id,
                        VerificationCode = CodeGenerator.GetCode(6, false),
                        PhoneNumber = user.Phone,
                        Email = user.Username,
                        ExpireDate = DateTime.UtcNow.AddHours(4).AddMonths(1)
                    };

                    CreateUserVerificationOperation createUserVerificationOperation = new CreateUserVerificationOperation();
                    var userVerificationResult = createUserVerificationOperation.Execute(userVerificationparameters);

                    if (!userVerificationResult.IsSuccess)
                    {
                        Result.ErrorList.AddRange(userVerificationResult.ErrorList);
                    }

                    Result.Output = output;

                    return;
                }

                if (Parameters.Email != null && Parameters.VerificationType == (byte)UserVerificationTypeValue.Email)
                {
                    var user = Uow.GetRepository<User>().Get(u => u.Username == Parameters.Email);

                    if (user == null)
                    {
                        Result.ErrorList.Add(new Error()
                        {
                            Type = OperationResultCode.Error,
                            Text = "User is not found with this phone number"
                        });

                        return;
                    }

                    if (user.EmailVerified == true)
                    {
                        Result.ErrorList.Add(new Error()
                        {
                            Type = OperationResultCode.Error,
                            Text = "You have already verified your phone number."
                        });

                        return;
                    }

                    var userVerificationparameters = new CreateUserVerificationInput()
                    {
                        VerificationTypeId = Parameters.VerificationType,
                        UserId = user.Id,
                        VerificationCode = CodeGenerator.GetCode(6, false),
                        PhoneNumber = user.Phone,
                        Email = user.Username,
                        ExpireDate = DateTime.UtcNow.AddHours(4).AddMonths(1)
                    };

                    CreateUserVerificationOperation createUserVerificationOperation = new CreateUserVerificationOperation();
                    var userVerificationResult = createUserVerificationOperation.Execute(userVerificationparameters);

                    if (!userVerificationResult.IsSuccess)
                    {
                        Result.ErrorList.AddRange(userVerificationResult.ErrorList);
                    }

                    Result.Output = output;

                    return;
                }
            }


            Result.Output = output;
        }
    }
}
