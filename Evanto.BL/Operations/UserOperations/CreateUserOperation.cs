using System;
using System.Linq;
using AutoMapper;
using Evanto.BL.Mapping;
using Evanto.BL.Operations.UserVerificationOperations;
using Evanto.DAL.Context;
using Evanto.Security;
using Evanto.Utils;
using Evanto.Utils.Enums;

namespace Evanto.BL.Operations.UserOperations
{
    public class CreateUserOperation : Operation<CreateUserInput, CreateUserOutput>
    {
        #region Parameters
        #endregion

        #region Constructor
        #endregion

        #region Methods
        public override void DoExecute()
        {
            CreateUserOutput output = new CreateUserOutput();
            User user = Mapper.Map<CreateUserInput, User>(this.Parameters);


            //TODO: Do ErrorResult implementation here.
            if (this.Uow.GetRepository<User>().GetAll().Any(u => u.Username == user.Username))
            {
                Result.ErrorList.Add(new Error
                {
                    Text = "Sorry, Your email is already registered.",
                    Code = "DuplicateEmail"
                });

                return;
            }

            if (this.Uow.GetRepository<User>().GetAll().Any(u => u.Phone == user.Phone))
            {
                Result.ErrorList.Add(new Error
                {
                    Text = "Sorry, Your phone number is already registered.",
                    Code = "DuplicatePhone"
                });

                return;
            }

            user.Salt = CHashing.RandomSalt();
            user.Password = CHashing.Hash(user.Salt, this.Parameters.PasswordString);
            user.RegistrationDate = DateTime.UtcNow.AddHours(4);
            user.CreatedDate = DateTime.UtcNow.AddHours(4);
            user.LastLoginDate = DateTime.UtcNow.AddHours(4);
            user.RoleId = (byte)RoleValue.User;  
            user.TypeId = (byte)UserTypeValue.User;
            user.StatusId = (byte)UserStatusValue.Active;
            user.GenderId = Parameters.GenderId;
            user.LoginCount = 1;
            user.PhoneVerified = false;
            user.EmailVerified = false;

            this.Uow.GetRepository<User>().Add(user);
            this.Uow.SaveChanges();

            var userVerificationparameters = new CreateUserVerificationInput()
            {
                VerificationTypeId = Parameters.VerificationTypeId,
                UserId = user.Id,
                VerificationCode = CodeGenerator.GetCode(6, false),
                PhoneNumber = user.Phone,
                Email = user.Username,
                ExpireDate = DateTime.UtcNow.AddHours(4).AddMonths(1)
            };

            CreateUserVerificationOperation createUserVerificationOperation = new CreateUserVerificationOperation();
            var userVerificationResult =  createUserVerificationOperation.Execute(userVerificationparameters);

            if (!userVerificationResult.IsSuccess)
            {
                Result.ErrorList.AddRange(userVerificationResult.ErrorList);
            }

            output.UserId = user.Id;
            output.IsCreated = true;
            Result.Output = output;
        }
        #endregion
    }
}
 