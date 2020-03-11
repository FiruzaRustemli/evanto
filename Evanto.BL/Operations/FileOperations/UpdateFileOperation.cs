using System.Linq;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;
using System.IO;
using System;
using Evanto.Utils;

namespace Evanto.BL.Operations.FileOperations
{
    public class UpdateFileOperation : Operation<UpdateFileInput, UpdateFileOutput>
    {
        #region Parameters
        #endregion
        #region Constructor
        #endregion
        #region Methods
        #endregion
        public override void DoExecute()
        {
            string fileName = Guid.NewGuid().ToString();
            string filePathToSave = $"{ConfigHelper.GetAppSetting("FileSavePath")}{fileName}.{Parameters.Extension}";
            Directory.CreateDirectory(Path.GetDirectoryName(filePathToSave));
            System.IO.File.WriteAllBytes(ConfigHelper.GetAppSetting("FileSaveServer") + filePathToSave, Convert.FromBase64String(Parameters.Container));
            UpdateFileOutput output = new UpdateFileOutput();

            DAL.Context.File file = Uow.GetRepository<DAL.Context.File>()
             .Get(x => x.ContentTypeId == 1 && x.RelationalId == Parameters.CurrentUserId && x.TypeId == 1);

            bool fileExist = true;

            if (file == null)
            {
                fileExist = false;
                file = new DAL.Context.File();
            }

            file.Path = filePathToSave;
            file.Name = fileName;
            file.Status = true;
            file.ContentTypeId = 1;
            file.TypeId = 1;
            file.RelationalId = Parameters.CurrentUserId;
            file.MediaType = Parameters.MediaType;
            file.Extension = Parameters.Extension;

            if (fileExist)
            {
                this.Uow.GetRepository<DAL.Context.File>().Update(file);
            }
            else
            {
                this.Uow.GetRepository<DAL.Context.File>().Add(file);
            }

            this.Uow.SaveChanges();
            output.File = Mapper.Map<DAL.Context.File, FileDto>(file);
            Result.Output = output;
        }
    }
}
