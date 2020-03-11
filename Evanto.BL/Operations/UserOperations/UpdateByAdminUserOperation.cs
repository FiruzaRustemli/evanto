using System;
using System.IO;
using System.Linq;
using Evanto.BL.DTOs.Admin;
using Evanto.DAL.Context;
using Evanto.Utils;
using Evanto.Utils.Enums;

namespace Evanto.BL.Operations.UserOperations
{
    public class UpdateByAdminUserOperation : Operation<UpdateByAdminUserInput, UpdateByAdminUserOutput>
    {
        #region Parameters
        #endregion

        #region Constructor
        #endregion

        #region Methods

        public override void DoExecute()
        {
            UpdateByAdminUserOutput output = new UpdateByAdminUserOutput{User = new UserAdminDto()};

            if (Parameters.Container != null)
            {
                if (Convert.FromBase64String(Parameters.Container).Length < 1048576)
                {


                    string fileName = Guid.NewGuid().ToString();
                    //// Saves file to path
                    string filePath = ConfigHelper.GetAppSetting("FileSavePath") + fileName + Parameters.FileExtension;
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                    System.IO.File.WriteAllBytes(ConfigHelper.GetAppSetting("FileSaveServer") + filePath, Convert.FromBase64String(Parameters.Container));

                    DAL.Context.File file = Uow.GetRepository<DAL.Context.File>()
                        .GetAll()
                        .FirstOrDefault(x => x.ContentTypeId == 1 && x.RelationalId == Parameters.Id && x.TypeId == 1);
                    bool fileExsist = true;
                    if (file == null)
                    {
                        fileExsist = false;
                        file = new DAL.Context.File();
                    }

                    file.Path = filePath;
                    file.Name = fileName;
                    file.Status = true; //TODO
                    file.ContentTypeId = 1;
                    file.TypeId = 1;
                    file.RelationalId = Parameters.Id;
                    file.MediaType = Parameters.MediaType;
                    file.Extension = Parameters.FileExtension;
                    if (fileExsist)
                    {
                        this.Uow.GetRepository<DAL.Context.File>().Update(file);
                    }
                    else
                    {
                        this.Uow.GetRepository<DAL.Context.File>().Add(file);
                    }

                    Uow.SaveChanges();
                }
                else
                {
                    Result.ErrorList.Add(new Error
                    {
                        Type = OperationResultCode.Exception,
                        Text = "File size is greater than 2 mb ",
                        Code = "400"
                    });
                }
            }
            User user = Uow.GetRepository<User>().GetById(Parameters.Id);

            //user.RoleId = Parameters.RoleId;
            //user.TypeId = Parameters.TypeId;
            user.StatusId = Parameters.StatusId;
            user.GenderId = Parameters.GenderId;
            // user.MaritalStatus = this.Parameters.MaritalStatus;
            user.FirstName = Parameters.FirstName;
            user.LastName = Parameters.LastName;
            user.Birthday = Parameters.Birthday;
            user.Phone = Parameters.Phone;
            user.Username = Parameters.Username;
            user.Description = Parameters.Description;
            if (user.Vendor != null)
                user.Vendor.Name = Parameters.VendorName;


            Uow.GetRepository<User>().Update(user);
            Uow.SaveChanges();

            output.User = Mapper.Map<User, UserAdminDto>(user);
            output.User.Image = Parameters.Container;
            output.IsUpdated = true;
            Result.Output = output;
        }

        #endregion


    }
}
