using System;
using Evanto.DAL.Context;
using Evanto.Security;
using Evanto.Utils;
using System.Linq;
using Evanto.BL.Operations.UserOperations;
using Evanto.Utils.Enums;
using Evanto.BL.Operations.UserVerificationOperations;

namespace Evanto.BL.Operations.VendorOperations
{
    public class CreateVendorOperation : Operation<CreateVendorInput, CreateVendorOutput>
    {
        #region Parameters

        #endregion

        #region Constructor

        #endregion

        #region Methods

        #endregion

        public override void DoExecute()
        {
            CreateVendorOutput output = new CreateVendorOutput();
            Vendor vendor = Mapper.Map<CreateVendorInput, Vendor>(this.Parameters);
            User user = Mapper.Map<CreateUserInput, User>(this.Parameters.UserInput);


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
            user.Password = CHashing.Hash(user.Salt, this.Parameters.UserInput.PasswordString);
            user.RegistrationDate = DateTime.UtcNow.AddHours(4);
            user.CreatedDate = DateTime.UtcNow.AddHours(4);
            user.LastLoginDate = DateTime.UtcNow.AddHours(4);
            user.RoleId = 2;  //TODO: Create user input must be read from enums or any other data provider.
            user.TypeId = 2;
            user.StatusId = 1;
            user.GenderId = 1;
            this.Uow.GetRepository<User>().Add(user);
            this.Uow.SaveChanges();

            vendor.UserId = user.Id;
            vendor.Address = string.Empty;
            vendor.Name = this.Parameters.Name;
            vendor.CreatedDate = DateTime.UtcNow.AddHours(4);

            this.Uow.GetRepository<Vendor>().Add(vendor);
            this.Uow.SaveChanges();

            var createuserSettingsOperation = new CreateUserSettingsOperation();
            var createUserSettingsInput = new CreateUserSettingsInput
            {
                LangCode = "az",
                Theme = "default",
                CurrentUserId = vendor.UserId
            };
            var createUserSettingsResult = createuserSettingsOperation.Execute(createUserSettingsInput);
            if(!createUserSettingsResult.IsSuccess)
            {
                Result.ErrorList.AddRange(createUserSettingsResult.ErrorList);
            }

            //var userVerificationparameters = new CreateUserVerificationInput()
            //{
            //    VerificationTypeId = Parameters.UserInput.VerificationTypeId,
            //    UserId = user.Id,
            //    VerificationCode = CodeGenerator.GetCode(6, false),
            //    PhoneNumber = user.Phone,
            //    Email = user.Username,
            //    ExpireDate = DateTime.UtcNow.AddHours(4).AddMonths(1)
            //};

            //CreateUserVerificationOperation createUserVerificationOperation = new CreateUserVerificationOperation();
            //var userVerificationResult = createUserVerificationOperation.Execute(userVerificationparameters);

            //if (!userVerificationResult.IsSuccess)
            //{
            //    Result.ErrorList.AddRange(userVerificationResult.ErrorList);
            //}

            output.IsCreated = true;
            Result.Output = output;
        }
    }
}

