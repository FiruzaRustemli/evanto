using Evanto.BL.DTOs.Vendor;
using Evanto.DAL.Context;
using Evanto.Utils;
using Evanto.Utils.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evanto.BL.Operations.FileOperations
{
    public class InsertBulkImagesByVendorOperation: Operation<InsertBulkImagesByVendorInput , InsertBulkImagesByVendorOutput>
    {
        public override void DoExecute()
        {
            InsertBulkImagesByVendorOutput output = new InsertBulkImagesByVendorOutput();
            List<DAL.Context.File> files = new List<DAL.Context.File>();
            Parameters.Images.ForEach(image =>
            {
                if(Convert.FromBase64String(image.Container).Length < 1048576)
                {
                    string fileName = Guid.NewGuid().ToString();
                    string filePathToSave = $"{ConfigHelper.GetAppSetting("FileSavePath")}{fileName}.{image.Extension}";
                    Directory.CreateDirectory(Path.GetDirectoryName(filePathToSave));
                    try
                    {
                        System.IO.File.WriteAllBytes(ConfigHelper.GetAppSetting("FileSaveServer") + filePathToSave, Convert.FromBase64String(image.Container));
                        var file = new DAL.Context.File
                        {
                            Path = filePathToSave,
                            Name = fileName,
                            Status = true,
                            ContentTypeId = 1,
                            TypeId = 3,
                            RelationalId = Parameters.VendorServiceId,
                            MediaType = image.MediaType,
                            Extension = image.Extension
                        };
                        files.Add(file);
                    }
                    catch (Exception ex)
                    {
                        output.FailedImages.Add(image);
                    }
                }
                else
                {
                    output.FailedImages.Add(image);
                    Result.ErrorList.Add(new Error
                    {
                        Type = OperationResultCode.Exception,
                        Text = "There are files that are more than 2 mb",
                        Code = "400"
                    });
                }
            });

            this.Uow.GetRepository<DAL.Context.File>().AddRange(files);
            this.Uow.SaveChanges();
            output.Images = Mapper.Map<List<DAL.Context.File>, List<FileVendorDto>>(files);
            if(output.Images.Count > 0)
            {
                output.Images.ForEach(image =>
                {
                    string filePathToSave = $"{ConfigHelper.GetAppSetting("FileSavePath")}{image.Name}.{image.Extension}";
                    image.Container = filePathToSave != null && System.IO.File.Exists(ConfigHelper.GetAppSetting("FileSaveServer") + filePathToSave) ? Convert.ToBase64String(System.IO.File.ReadAllBytes(ConfigHelper.GetAppSetting("FileSaveServer") + filePathToSave)) : null;
                });
            }
            Result.Output = output; 
        }
    }
}
