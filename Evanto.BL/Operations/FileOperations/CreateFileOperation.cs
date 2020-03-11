using System;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using Evanto.Utils;
using System.IO;
using System.Web.Hosting;
using System.Web;
using System.Runtime;
using Evanto.Utils.Enums;

namespace Evanto.BL.Operations.FileOperations
{
    public class CreateFileOperation : Operation<CreateFileInput, CreateFileOutput>
    {
        #region Parameters
        #endregion
        #region Constructor
        #endregion
        #region Methods

        public override void DoExecute()
        {
            CreateFileOutput output = new CreateFileOutput();
            if (Convert.FromBase64String(Parameters.Container).Length < 1048576)
            {
                string fileName = Guid.NewGuid().ToString();
                string filePathToSave = $"{ConfigHelper.GetAppSetting("FileSavePath")}{fileName}.{Parameters.Extension}";
                Directory.CreateDirectory(Path.GetDirectoryName(filePathToSave));
                System.IO.File.WriteAllBytes(ConfigHelper.GetAppSetting("FileSaveServer") + filePathToSave, Convert.FromBase64String(Parameters.Container));
                
               var  file = new DAL.Context.File
                {
                    Path = filePathToSave,
                    Name = fileName,
                    Status = true,
                    ContentTypeId = 1,
                    TypeId = Parameters.TypeId,
                    RelationalId = (int) Parameters.RelationalId,
                    MediaType = Parameters.MediaType,
                    Extension = Parameters.Extension,
                    ParentId = Parameters.ParentId
                };


                this.Uow.GetRepository<DAL.Context.File>().Add(file);
                this.Uow.SaveChanges();

                output.Container = Convert.ToBase64String(System.IO.File.ReadAllBytes(ConfigHelper.GetAppSetting("FileSaveServer") + filePathToSave));
                output.File = Mapper.Map<DAL.Context.File, FileDto>(file);
                Result.Output = output;
            }
            else
            {
                output.Container = Parameters.Container;
                Result.ErrorList.Add(new Error
                {
                    Type = OperationResultCode.Exception,
                    Text = "File size is greater than 2 mb",
                    Code = "400"
                });
            }
            Result.Output = output;
        }

        #endregion
    }
}
